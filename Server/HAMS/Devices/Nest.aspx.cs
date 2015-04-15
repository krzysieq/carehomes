using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HAMS.Models;

namespace HAMS
{
    public partial class Nest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string authCode = Request.QueryString["code"];
            string participantId = Request.QueryString["state"];

            if (authCode == null || participantId == null)
            {
                throw new Exception("Invalid parameters");
            }

            string token = HAMS.Devices.Nest.GetToken(authCode);

            if (token == null)
            {
                throw new Exception("Invalid auth code");
            }

            Guid participantIdAsGuid;
            try
            {
                participantIdAsGuid = Guid.Parse(participantId);
            }
            catch (FormatException ex)
            {
                throw new Exception("Invalid parameters");
            }

            using (var db = new HAMSContext())
            {
                Participant participant = db.Participants.Find(participantIdAsGuid);
                if (participant == null)
                {
                    throw new Exception("Can't find participant: " + participantId);
                }
                participant.NestAuthorized = true;
                participant.NestAuthCode = token;
                db.SaveChanges();
            }
        }
    }
}