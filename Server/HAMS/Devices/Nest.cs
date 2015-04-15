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

        public static double? GetTemperature(string accessToken)
        {
            var client = new HttpClient();
            string url = String.Format("https://developer-api.nest.com/?auth={0}", accessToken);

            string responseString = client.GetStringAsync(url).Result;
            JObject response = JObject.Parse(responseString);
            
            if (response["devices"] == null)
            {
                return null;
            }
            JObject devices = (JObject) response["devices"];

            if (devices["thermostats"] == null)
            {
                return null;
            }
            JObject thermostats = (JObject)devices["thermostats"];

            foreach (var thermostat in thermostats)
            {
                JObject id = (JObject)thermostat.Value;
                double temperature = (double)id["ambient_temperature_c"];
                return temperature;
            }

            return null;
        }

        public static void PushThings()
        {
            using (var db = new HAMSContext())
            {
                foreach (var participant in db.Participants.Where(p => p.NestAuthCode != null))
                {
                    double? temperature = GetTemperature(participant.NestAuthCode);
                    if (!temperature.HasValue)
                    {
                        continue;
                    }

                    if (!participant.HVPersonId.HasValue || !participant.HVRecordId.HasValue)
                    {
                        continue;
                    }

                    HV.AmbientTemperature temperatureObject = new HV.AmbientTemperature
                    {
                        Value = temperature.Value,
                        Time = DateTime.Now
                    };

                    HV.Methods.PostCustomThing(
                        temperatureObject,
                        new Microsoft.Health.ItemTypes.HealthServiceDateTime(DateTime.Now),
                        participant.HVPersonId.Value,
                        participant.HVRecordId.Value
                    );
                }
            }
        }
    }
}