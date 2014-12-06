using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using HVProxy.Models;
using System.Web.ModelBinding;
using System.Data.Entity;

public partial class Participants : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public IQueryable<Participant> GetParticipants()
    {
        var db = new HVProxy.Models.ParticipantContext();
        IQueryable<Participant> query = db.Participants;
        return query;
    }
}