using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserRegistration : System.Web.UI.Page
{
    DBManager db = new DBManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["user_id"] != null && Request.QueryString["user_id"].ToString() != "")
            {
                BindUser(Request.QueryString["user_id"].ToString());
            }
        }
    }

    public void BindUser(string id)
    {
        DataTable dtuser = db.RetrieveDatatableIL("select * from telecare_master where user_id=" + id);
        if (dtuser != null && dtuser.Rows.Count > 0)
        {
            txtname.Value = dtuser.Rows[0]["user_name"].ToString();
            txtage.Value = dtuser.Rows[0]["user_age"].ToString();
            txtcondition.Value = dtuser.Rows[0]["conditions"].ToString();
            txtmedication.Value = dtuser.Rows[0]["medications"].ToString();
            txtallergies.Value = dtuser.Rows[0]["allergies"].ToString();

            ddlcitys.Items.FindByText(dtuser.Rows[0]["user_city"].ToString()).Selected = true;
            ddlGender.Items.FindByText(dtuser.Rows[0]["user_gender"].ToString()).Selected = true;
            btnregister.Text = "Update";
        }
    }
    protected void btnregister_Click(object sender, EventArgs e)
    {
        DBManager db = new DBManager();

        string query = string.Empty;
        string msg = string.Empty;

        if (Request.QueryString["user_id"] != null && Request.QueryString["user_id"].ToString() != "")
        {
            query = @"update telecare_master set user_name='" + txtname.Value + "',user_gender='" + ddlGender.SelectedItem.Text + "',user_age=" + txtage.Value + ",user_city='" + ddlcitys.Value.ToString() +"',conditions='" + txtcondition.Value.Replace("'", "''") + "',allergies='" + txtallergies.Value.Replace("'", "''") + "',medications='" + txtmedication.Value.Replace("'", "''") + "' where user_id=" + Request.QueryString["user_id"].ToString();
            db.InlineQuery(query);
            Response.Redirect("UserSearch.aspx");
        }
        else
        {
            query = @"insert into telecare_master(user_name,user_gender,user_age,user_city,conditions,allergies,medications,isactive) 
values ('" + txtname.Value + "','" + ddlGender.SelectedItem.Text + "','" + txtage.Value + "','" + ddlcitys.Value.ToString() + "','" + txtcondition.Value.Replace("'", "''") + "','" + txtallergies.Value.Replace("'", "''") + "','" + txtmedication.Value.Replace("'", "''") + "',1)";
            db.InlineQuery(query);
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert",
"<script>alert('User Added successfully. ');</script>", false);
        

        txtname.Value = "";
        ddlcitys.SelectedIndex = 0;
        ddlGender.SelectedIndex = 0;
        txtage.Value = "";
        txtcondition.Value = "";
        txtmedication.Value = "";
        txtallergies.Value = "";
    }
}