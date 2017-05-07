using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class user_Editcustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Convert.ToString(Session["userName"]);

        //=Convert.ToString(Session["qx"]);
        if (userName == "")
        {
            Response.Redirect("index.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("CheckBox1");
            if (chk.Checked)
            {
                int id = Convert.ToInt32(((Label)gr.Cells[5].FindControl("Label1")).Text);
                DB.execnonsql("DELETE FROM [gscontent] WHERE id = " + id + "");



            }
            GridView1.DataBind();
            return;
        }
    }
}
