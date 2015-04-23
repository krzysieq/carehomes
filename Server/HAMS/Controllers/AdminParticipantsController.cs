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
using HAMS.Models;
using HAMS.DTOs;
using System.Web.Http.Cors;

namespace HAMS.Controllers
{
    [RoutePrefix("admin/participants")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AdminAuthentication]
    public class AdminParticipantsController : ApiController
    {
        private HAMSContext db = new HAMSContext();

        private static readonly Expression<Func<Participant, ParticipantAdminDto>> AsParticipantAdminDto =
            x => new ParticipantAdminDto
            {
                participantId = x.ParticipantId,
                firstName = x.FirstName,
                lastName = x.LastName,
                dob = x.Dob,
                gender = x.Gender,
                enrollmentDate = x.EnrollmentDate,
                activated = x.Activated,
                activationCode = x.ActivationCode,
                secretQuestion = x.SecretQuestion,
                secretAnswer = x.SecretAnswer
            };

        private static readonly Func<Participant, ParticipantAdminDto> ToParticipantAdminDto =
            x => new ParticipantAdminDto
            {
                participantId = x.ParticipantId,
                firstName = x.FirstName,
                lastName = x.LastName,
                dob = x.Dob,
                gender = x.Gender,
                enrollmentDate = x.EnrollmentDate,
                activated = x.Activated,
                activationCode = x.ActivationCode,
                secretQuestion = x.SecretQuestion,
                secretAnswer = x.SecretAnswer
            };

        private static readonly Func<ParticipantAdminDto, Participant> ToParticipant =
            x => new Participant
            {
                ParticipantId = x.participantId,
                FirstName = x.firstName,
                LastName = x.lastName,
                Dob = x.dob,
                Gender = x.gender,
                EnrollmentDate = x.enrollmentDate,
                Activated = x.activated,
                ActivationCode = x.activationCode,
                SecretQuestion = x.secretQuestion,
                SecretAnswer = x.secretAnswer
            };

        // GET: api/Participants
        [Route("")]
        public IQueryable<ParticipantAdminDto> GetParticipants()
        {
            return db.Participants.Select(AsParticipantAdminDto);
        }

        // GET: api/Participants/5
        [Route("{id:Guid}", Name="GetParticipantAdminDto")]
        [ResponseType(typeof(ParticipantAdminDto))]
        public async Task<IHttpActionResult> GetParticipant(Guid id)
        {
            ParticipantAdminDto participant = await db.Participants.Select(AsParticipantAdminDto)
                .Where(p => p.participantId == id)
                .FirstOrDefaultAsync();
            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }

        // PUT: api/Participants/5
        [Route("{id:Guid}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParticipant(Guid id, ParticipantAdminDto participantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantDto.participantId)
            {
                return BadRequest();
            }

            Participant participant = await db.Participants.FindAsync(participantDto);
            if (participant == null)
            {
                return BadRequest();
            }

            participant.FirstName = participantDto.firstName;
            participant.LastName = participantDto.lastName;
            participant.Dob = participantDto.dob;
            participant.Gender = participantDto.gender;

            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Participants
        [Route("")]
        [ResponseType(typeof(ParticipantAdminDto))]
        public async Task<IHttpActionResult> PostParticipant(ParticipantAdminDto participantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Participant participant = ToParticipant(participantDto);

            participant.ParticipantId = Guid.NewGuid();
            participant.ActivationCode = HV.Connections.CreateParticipantIdentityCode(
                participant.FirstName + ' ' + participant.LastName,
                participant.SecretQuestion,
                participant.SecretAnswer,
                participant.ParticipantId.ToString()
            );
            participant.EnrollmentDate = DateTime.Now;

            db.Participants.Add(participant);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParticipantExists(participant.ParticipantId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetParticipantAdminDto", new { id = participant.ParticipantId }, ToParticipantAdminDto(participant));
        }

        // DELETE: api/Participants/5
        [Route("{id:Guid}")]
        [ResponseType(typeof(ParticipantAdminDto))]
        public async Task<IHttpActionResult> DeleteParticipant(Guid id)
        {
            Participant participant = await db.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            db.Participants.Remove(participant);
            await db.SaveChangesAsync();

            return Ok(ToParticipantAdminDto(participant));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantExists(Guid id)
        {
            return db.Participants.Count(e => e.ParticipantId == id) > 0;
        }
    }
}