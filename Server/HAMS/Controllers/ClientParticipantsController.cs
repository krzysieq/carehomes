using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HAMS.DTOs;
using HAMS.Models;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace HAMS.Controllers
{
    [RoutePrefix("client/participants")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ClientAuthentication]
    public class ClientParticipantsController : ApiController
    {
        private HAMSContext db = new HAMSContext();

        private static readonly Expression<Func<Participant, ParticipantClientDto>> AsParticipantClientDto =
            x => new ParticipantClientDto
            {
                participantId = x.ParticipantId,
                firstName = x.FirstName,
                lastName = x.LastName,
                dob = x.Dob,
                gender = x.Gender
            };

        [Route("")]
        // GET: client/participants
        public IQueryable<ParticipantClientDto> GetParticipants()
        {
            return db.Participants.Where(p => p.Activated).Select(AsParticipantClientDto);
        }

        [Route("{id:Guid}", Name = "GetParticipantClientDto")]
        // GET: client/participants/5
        [ResponseType(typeof(ParticipantClientDto))]
        public async Task<IHttpActionResult> GetParticipant(Guid id)
        {
            ParticipantClientDto participant = await db.Participants.Select(AsParticipantClientDto)
                .Where(p => p.participantId == id)
                .FirstOrDefaultAsync();

            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }

        [Route("{participantId:Guid}/things")]
        // GET: client/participants/5/things
        [ResponseType(typeof(JObject))]
        public async Task<IHttpActionResult> GetThings(Guid participantId)
        {
            Participant participant = await db.Participants
                .Where(p => p.ParticipantId == participantId)
                .FirstOrDefaultAsync();

            if (participant == null)
            {
                return NotFound();
            }

            if (!participant.HVPersonId.HasValue || !participant.HVRecordId.HasValue)
            {
                return NotFound();
            }

            JObject things = HV.Methods.GetAllThings(participant.HVPersonId.Value, participant.HVRecordId.Value);
            return Ok(things);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}