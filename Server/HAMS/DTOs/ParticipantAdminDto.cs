using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HAMS.DTOs
{
    public class ParticipantAdminDto
    {
        [Key]
        public Guid participantId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }
        public DateTime enrollmentDate { get; set; }
        public bool activated { get; set; }
        public string activationCode { get; set; }
        public string secretQuestion { get; set; }
        public string secretAnswer { get; set; }
    }
}