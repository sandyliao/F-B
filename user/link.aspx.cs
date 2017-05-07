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

public partial class user_link : System.Web.UI.Page
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
        string sql = "INSERT INTO [lianjie] ([linkname], [link]) VALUES ( '" + TextBox1.Text + "', '" + TextBox2.Text + "')";
        DB.execnonsql(sql);
        MessageBox.Show(this, "添加成功");
        this.GridView1.DataBind();
        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
        return;
    }
}
