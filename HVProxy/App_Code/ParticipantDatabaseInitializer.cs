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
                            TimeTokenGenerated = DateTime.Parse("2014-10-01"),
                            ParticipantCode = "AAAABBBBCCCCDDDDEEEEE",
                            SecurityQuestion = "A very secret question",
                            SecurityAnswer = "A very secret answer",
                            HasAuthorised = false,
                            PersonId = Guid.NewGuid(),
                            RecordId = Guid.NewGuid()
                        },
                        new Participant {
                            ParticipantId = 2,
                            ParticipantName = "Lisa Jackson",
                            TimeTokenGenerated = DateTime.Parse("2014-12-06"),
                            ParticipantCode = "12341234123412341234",
                            SecurityQuestion = "Favourite restaurant",
                            SecurityAnswer = "Chipotle",
                            HasAuthorised = false,
                            PersonId = Guid.NewGuid(),
                            RecordId = Guid.NewGuid()
                        }
            };
            return participants;
        }
    }
}