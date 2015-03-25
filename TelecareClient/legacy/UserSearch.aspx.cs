using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnregister_Click(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = "SELECT [user_name], [user_id], [user_gender], [user_age], [user_city] FROM [telecare_master] where user_name like '%" + txtname.Value + "%'";        
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="btndel")
        {
            DBManager db = new DBManager();
            db.InlineQuery("delete from telecare_master where user_id=" + e.CommandArgument.ToString());
            GridView1.DataBind();
        }
    }
}