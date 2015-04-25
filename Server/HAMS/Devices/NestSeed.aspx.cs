using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HAMS.Models;
using HAMS.HV;

namespace HAMS.Devices
{
    public partial class NestSeed : System.Web.UI.Page
    {
        public string response;
        protected void Page_Load(object sender, EventArgs e)
        {
            double[] baseTemps = { 20.4, 20.5, 20.8, 20.4, 19.9, 20.5, 21.0, 21.4, 22.1, 22.9, 22.3, 21.8,
                                   21.5, 21.6, 21.8, 21.1, 20.7, 20.9, 20.5, 21.0, 20.8, 20.6, 20.5, 20.3};

            using (var db = new HAMSContext())
            {
                foreach (var participant in db.Participants.Where(p => p.Activated))
                {
                    Guid personId = participant.HVPersonId.Value;
                    Guid recordId = participant.HVRecordId.Value;

                    response += String.Format("Seeding: {0} {1}{2}", participant.FirstName, participant.LastName, Environment.NewLine);

                    Methods.PurgeCustomData(personId, recordId);

                    response += String.Format("Old data purged.{0}", Environment.NewLine);

                    if (participant.NestAuthCode == null)
                    {
                        response += String.Format("No access code, skipping.{0}", Environment.NewLine);
                        continue;
                    }

                    DateTime current = DateTime.Now.Subtract(new TimeSpan(24 * 7, 0, 0));
                    Random random = new Random();

                    double baseHumidity = random.Next(20, 60);

                    for (int day = 0; day < 7; day++)
                    {
                        for (int time = 0; time < 24; time++)
                        {
                            Nest.NestData data = new Nest.NestData{
                                Temperature = Math.Round(baseTemps[time] + random.NextDouble() * 0.5 * RandomSign(), 1),
                                Humidity = baseHumidity + random.Next(5) * RandomSign(),
                                CoState = RandomState(),
                                SmokeState = RandomState()
                            };
                            Nest.PushDataToHV(data, personId, recordId, current);

                            current = current.AddHours(1.0);
                        }
                    }

                    response += String.Format("New data pushed.{0}", Environment.NewLine);
                }
            }

        }

        private int RandomSign()
        {
            Random random = new Random();
            return (int) random.Next(0, 2) * 2 - 1;
        }

        private string RandomState()
        {
            int random = (new Random()).Next(100);
            if (random < 95)
            {
                return "ok";
            }
            else if (random < 99)
            {
                return "warning";
            }
            else
            {
                return "emergency";
            }
        }
    }
}