using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace HVProxy.Models
{

    public class Participant
    {
        public int ParticipantId { get; set; }

        [StringLength(100)]
        public string ParticipantName { get; set; }

        public DateTime TimeTokenGenerated { get; set; }

        [StringLength(100)]
        public string ParticipantCode { get; set; }

        [StringLength(100)]
        public string SecurityQuestion { get; set; }

        [StringLength(100)]
        public string SecurityAnswer { get; set; }

        public bool HasAuthorised { get; set; }

        public Guid PersonId { get; set; }

        public Guid RecordId { get; set; }
    }
}