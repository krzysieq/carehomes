using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HAMS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HAMS.Devices
{
    public static class Nest
    {
        private const string clientId = "1f89f98c-bb8c-4151-a963-1e4278daefc6";
        private const string clientSecret = "j61Os7yiYWrnwx7tYvJbnAYJ6";

        public static Guid DeviceId = new Guid("40BD8320-9040-4C3C-BA0E-509AA046BA85");

        public static string GetAuthenticationUrl(string participantId)
        {
            return String.Format("https://home.nest.com/login/oauth2?client_id={0}&state={1}", clientId, participantId);
        }

        public static string GetToken(string authCode)
        {
            string url = String.Format(
                "https://api.home.nest.com/oauth2/access_token?code={0}&client_id={1}&client_secret={2}&grant_type=authorization_code",
                authCode,
                clientId,
                clientSecret
            );
            using (var httpClient = new HttpClient())
            {
                using (var responseContent = httpClient.PostAsync(url, content: null).Result)
                {
                    var accessToken = JsonConvert.DeserializeObject(responseContent.Content.ReadAsStringAsync().Result);
                    return (accessToken as dynamic).access_token;
                }
            }
        }

        public class NestData
        {
            public double? Temperature { get; set; }
            public double? Humidity { get; set; }
            public string CoState { get; set; }
            public string SmokeState { get; set; }
        }

        public static NestData GetData(string accessToken)
        {
            NestData data = new NestData();

            var client = new HttpClient();
            string url = String.Format("https://developer-api.nest.com/?auth={0}", accessToken);

            string responseString = client.GetStringAsync(url).Result;
            JObject response = JObject.Parse(responseString);
            
            if (response["devices"] == null)
            {
                return data;
            }
            JObject devices = (JObject) response["devices"];

            if (devices["thermostats"] != null)
            {
                JObject thermostats = (JObject)devices["thermostats"];
                foreach (var thermostat in thermostats)
                {
                    JObject id = (JObject)thermostat.Value;
                    data.Temperature = (double)id["ambient_temperature_c"];
                    data.Humidity = (double)id["humidity"];
                    break; // ignore other devices
                }
            }
            
            if (devices["smoke_co_alarms"] != null)
            {
                JObject smokeAlarms = (JObject)devices["smoke_co_alarms"];
                foreach (var smokeAlarm in smokeAlarms)
                {
                    JObject id = (JObject)smokeAlarm.Value;
                    data.CoState = (string)id["co_alarm_state"];
                    data.SmokeState = (string)id["smoke_alarm_state"];
                    break; // ignore other devices
                }
            }

            return data;
        }

        public static void CollectAndPushThings()
        {
            using (var db = new HAMSContext())
            {
                foreach (var participant in db.Participants.Where(p => p.NestAuthCode != null))
                {
                    if (!participant.HVPersonId.HasValue || !participant.HVRecordId.HasValue)
                    {
                        continue;
                    }

                    NestData data = GetData(participant.NestAuthCode);

                    PushDataToHV(data, participant.HVPersonId.Value, participant.HVRecordId.Value);
                }
            }
        }

        public static void PushDataToHV(NestData data, Guid personId, Guid recordId, DateTime time)
        {
            if (data.Temperature.HasValue)
            {
                HV.AmbientTemperature temperatureObject = new HV.AmbientTemperature
                {
                    Value = data.Temperature.Value,
                    Time = time
                };
                HV.Methods.PostCustomThing(
                    temperatureObject,
                    new Microsoft.Health.ItemTypes.HealthServiceDateTime(time),
                    personId,
                    recordId
                );
            }

            if (data.Humidity.HasValue)
            {
                HV.Humidity humidityObject = new HV.Humidity
                {
                    Value = data.Humidity.Value,
                    Time = time
                };
                HV.Methods.PostCustomThing(
                    humidityObject,
                    new Microsoft.Health.ItemTypes.HealthServiceDateTime(time),
                    personId,
                    recordId
                );
            }

            if (data.CoState != null)
            {
                HV.CoState coStateObject = new HV.CoState
                {
                    Value = data.CoState,
                    Time = time
                };
                HV.Methods.PostCustomThing(
                    coStateObject,
                    new Microsoft.Health.ItemTypes.HealthServiceDateTime(time),
                    personId,
                    recordId
                );
            }

            if (data.SmokeState != null)
            {
                HV.SmokeState smokeStateObject = new HV.SmokeState
                {
                    Value = data.SmokeState,
                    Time = time
                };
                HV.Methods.PostCustomThing(
                    smokeStateObject,
                    new Microsoft.Health.ItemTypes.HealthServiceDateTime(time),
                    personId,
                    recordId
                );
            }
        }

        public static void PushDataToHV(NestData data, Guid personId, Guid recordId)
        {
            PushDataToHV(data, personId, recordId, DateTime.Now);
        }
    }
}