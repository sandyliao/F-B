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
using Maticsoft.BLL;

public partial class user_index : System.Web.UI.Page
{
    protected DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


        }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string vstr, userName, userPass, userPassmd5;
        userName = PageValidate.GetSafeStr(this.txtUserName.Text.Trim());
        userPass = PageValidate.GetSafeStr(this.txtUserPass.Text.Trim());
        userPassmd5 = MD5.Hash(userPass);
        vstr = PageValidate.GetSafeStr(this.TextBox3.Text);         
        if (vstr.CompareTo(memcached.Find("Vnumber" + memcached.GetIP()).ToString()) != 0)
        {
            MessageBox.Show(this, "您输入的验证码不正确，请重新输入！");
            return;
        }
        user objuser = new user();
        if (objuser.Exists(userName, userPassmd5))
        {
            memcached.Add("userName" + memcached.GetIP(), userName);    
            Response.Redirect("welcome.htm");
        }
        else
        {
            MessageBox.Show(this, "用户名或者密码错误，请重新输入！");
            this.txtUserName.Text = "";
            this.txtUserPass.Text = "";
            this.TextBox3.Text = "";
            MessageBox.SetFocus(this.txtUserName, this.Page);
            return;
        }
    }
}
