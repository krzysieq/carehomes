using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data.Entity;

namespace HVProxy.Models
{
    public class ParticipantDatabaseInitializer : DropCreateDatabaseIfModelChanges<ParticipantContext>
    {
        protected override void Seed(ParticipantContext context)
        {
            GetParticipants().ForEach(p => context.Participants.Add(p));
        }

        private static List<Participant> GetParticipants()
        {
            var participants = new List<Participant> {
                        new Participant {
                            ParticipantId = 1,
                            ParticipantName = "John Smith",
                            TimeTokenGenerated = new TimeSpan(),
                            ParticipantCode = "AAAABBBBCCCCDDDDEEEEE",
                            SecurityQuestion = "A very secret question",
                            SecurityAnswer = "A very secret answer",
                            HasAuthorised = false,
                            PersonId = new Guid(),
                            RecordId = new Guid()
                        }
            };
            return participants;
        }
    }
}