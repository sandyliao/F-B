using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_newscontent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = memcached.Find("userName" + memcached.GetIP().ToString());
        if (userName == "")
        {
            Response.Redirect("index.aspx");
        }

        if (!IsPostBack)
        { 
           DataTable dt = new DataTable();           
           Maticsoft.BLL.newscontent objnewscontent = new Maticsoft.BLL.newscontent();

           dt = objnewscontent.GetAllList();
           
           GridView1.DataSource = dt;
           GridView1.DataBind();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Addnews.aspx");
    }
}
