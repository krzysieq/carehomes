using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HAMS.DTOs
{
    public class ParticipantClientDto
    {
        [Key]
        public Guid participantId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }
    }
}