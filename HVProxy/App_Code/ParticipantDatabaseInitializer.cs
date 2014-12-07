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
                            ParticipantId = Guid.NewGuid(),
                            ParticipantName = "John Smith",
                            TimeTokenGenerated = DateTime.Parse("2014-10-01"),
                            ParticipantCode = "AAAA-BBBB-CCCC-DDDD-EEEE",
                            SecurityQuestion = "A very secret question",
                            SecurityAnswer = "A very secret answer",
                            HasAuthorised = false,
                            PersonId = null,
                            RecordId = null
                        },
                        new Participant {
                            ParticipantId = Guid.NewGuid(),
                            ParticipantName = "Lisa Jackson",
                            TimeTokenGenerated = DateTime.Parse("2014-12-06"),
                            ParticipantCode = "1234-1234-1234-1234-1234",
                            SecurityQuestion = "Favourite restaurant",
                            SecurityAnswer = "Chipotle",
                            HasAuthorised = false,
                            PersonId = null,
                            RecordId = null
                        }
            };
            return participants;
        }
    }
}