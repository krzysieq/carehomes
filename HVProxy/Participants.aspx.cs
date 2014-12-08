using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using HVProxy.Models;
using System.Web.ModelBinding;
using System.Data.Entity;
using Microsoft.Health.PatientConnect;

public partial class Participants : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetValidatedConnectionsBtn.Click += new EventHandler(CheckForValidatedConnections);
    }

    private void CheckForValidatedConnections(Object sender, EventArgs e)
    {
        Collection<ValidatedPatientConnection> connectionList = HVHelper.GetValidatedConnectionsInPastDays(0);
        using (var db = new ParticipantContext())
        {
            try {
                foreach (ValidatedPatientConnection connection in connectionList)
                {
                    Guid participantId = Guid.Parse(connection.ApplicationPatientId);
                    Participant participant = db.Participants.Find(participantId);
                    if (participant.HasAuthorised)
                    {
                        continue;
                    }
                    participant.HasAuthorised = true;
                    participant.PersonId = connection.PersonId;
                    participant.RecordId = connection.RecordId;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Unable to update Participants information: " + ex.Message.ToString(), ex);
            }
            
        }
    }

    public IQueryable<Participant> GetParticipants()
    {
        var db = new HVProxy.Models.ParticipantContext();
        IQueryable<Participant> query = db.Participants.OrderByDescending(item => item.TimeTokenGenerated);
        return query;
    }
}