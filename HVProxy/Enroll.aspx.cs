using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HVProxy.Models;

public partial class Enroll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SubmitBtn.Click += new EventHandler(SubmitForm);
    }

    void SubmitForm(Object sender, EventArgs e)
    {
        string name = NameTextBox.Text;
        string question = QuestionTextBox.Text;
        string answer = AnswerTextBox.Text;

        Guid id = Guid.NewGuid();

        string code = HVHelper.CreateParticipantIdentityCode(name, question, answer, id.ToString());

        CodeTextBox.Text = code;

        Participant participant = new Participant
        {
            ParticipantId = id,
            ParticipantName = name,
            TimeTokenGenerated = DateTime.Now,
            ParticipantCode = code,
            SecurityQuestion = question,
            SecurityAnswer = answer,
            HasAuthorised = false,
            PersonId = null,
            RecordId = null
        };

        using (var db = new ParticipantContext())
        {
            try
            {
                db.Participants.Add(participant);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Unable to save a new Participant: " + ex.Message.ToString(), ex);
            }
        }
        
    }
}