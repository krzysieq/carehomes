using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace HVProxy.Models
{
    public class ParticipantContext : DbContext
    {
        public ParticipantContext() : base("HVProxy")
        {
        }

        public DbSet<Participant> Participants { get; set; }
    }
}