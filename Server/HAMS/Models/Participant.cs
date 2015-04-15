using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HAMS.Models
{
    public class Participant
    {
        [Key]
        public Guid ParticipantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool Activated { get; set; }
        public string ActivationCode { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public Guid? HVPersonId { get; set; }
        public Guid? HVRecordId { get; set; }

        // Nest API-specific
        public Guid? NestDeviceId { get; set; }
        public string NestAuthCode { get; set; }
        public bool? NestAuthorized { get; set; }
    }
}