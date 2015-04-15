using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using HAMS.Models;
using Newtonsoft.Json.Linq;

namespace HAMS.Controllers
{
    [RoutePrefix("admin/participants")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminDevicesController : ApiController
    {
        private HAMSContext db = new HAMSContext();

        // GET: admin/participants/5/devices
        [Route("{participantId:Guid}/devices")]
        [ResponseType(typeof(JObject))]
        public async Task<IHttpActionResult> GetDevices(Guid participantId)
        {
            Participant participant = await db.Participants.FindAsync(participantId);
            if (participant == null)
            {
                return NotFound();
            }

            JArray devices = new JArray(
                new JObject(
                    new JProperty("id", Devices.Nest.DeviceId.ToString()),
                    new JProperty("vendor", "Nest"),
                    new JProperty("picture", HV.AppSettings.DeploymentUrl + "/assets/nest.png"),
                    new JProperty("sensors", new JArray(
                            new JObject(
                                new JProperty("name", "Thermostat"),
                                new JProperty("status", participant.NestAuthCode == null ? 0 : 2)
                            )
                        )
                   ),
                    new JProperty("authorised", participant.NestAuthCode != null)
                )
            );

            return Ok(devices);
        }

        
        // PUT: admin/participants/5/devices/5
        [Route("{participantId:Guid}/devices/{deviceId:Guid}")]
        [ResponseType(typeof(JObject))]
        public async Task<IHttpActionResult> PutDeviceActivation(Guid participantId, Guid deviceId)
        {
            Participant participant = await db.Participants.FindAsync(participantId);
            if (participant == null)
            {
                return BadRequest();
            }

            if (deviceId == Devices.Nest.DeviceId)
            {
                JObject response = new JObject(
                    new JProperty("authUrl", Devices.Nest.GetAuthenticationUrl(participant.ParticipantId.ToString()))
                );
                return Ok(response);
            }

            return BadRequest();
        }

        // DELETE: admin/participants/5/devices/5
        [Route("{participantId:Guid}/devices/{deviceId:Guid}")]
        [ResponseType(typeof(JObject))]
        public async Task<IHttpActionResult> DeleteDeviceActivation(Guid participantId, Guid deviceId)
        {
            Participant participant = await db.Participants.FindAsync(participantId);
            if (participant == null)
            {
                return NotFound();
            }

            if (deviceId == Devices.Nest.DeviceId)
            {
                if (participant.NestAuthCode == null)
                {
                    return BadRequest();
                }
                else
                {
                    participant.NestAuthCode = null;
                    participant.NestAuthorized = false;
                    db.SaveChanges();
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }

            return BadRequest();
        }
    }
}
