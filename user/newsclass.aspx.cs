using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Maticsoft.Model;

public partial class user_newsclass : System.Web.UI.Page
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
            BindClass();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strErr = "";

        if (this.txtcontent.Text == "")
        {
            strErr += "内容不能为空！\\n";
        }
        

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        
        string newsclass = this.txtcontent.Text;
        int newsid = 0;

        Maticsoft.Model.newsbig model = new Maticsoft.Model.newsbig();
        
        model.newsclass = newsclass;
        model.newsid = newsid;

        Maticsoft.BLL.newsbig bll = new Maticsoft.BLL.newsbig();
        bll.Add(model);
        MessageBox.Show(this, "添加成功");
        this.txtcontent.Text = "";
        BindClass();
    }
    void BindClass()
    {
        List<newsbig> list = Maticsoft.BLL.newsbig.get_List();
        foreach (newsbig model in list)
        {
            ListItem li = new ListItem();
            li.Text = "╋" + model.newsclass;
            li.Value = model.id.ToString();
            DropDownList1.Items.Add(li);
            BindChild(model.id.ToString(), "├──");
        }
    }

    void BindChild(string ParentID, string separator)
    {
        List<newsbig> list = Maticsoft.BLL.newsbig.get_List(ParentID);
        foreach (newsbig model in list)
        {
            ListItem li = new ListItem();
            li.Text = separator + model.newsclass;
            li.Value = model.id.ToString();
            DropDownList1.Items.Add(li);
            string separator_ = separator + "───";
            BindChild(model.id.ToString(), separator_);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string strErr = "";

        if (this.TextBox1.Text == "")
        {
            strErr += "内容不能为空！\\n";
        }


        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }

        string newsclass = this.TextBox1.Text;
        int newsid =Convert.ToInt32(DropDownList1.SelectedValue);

        Maticsoft.Model.newsbig model = new Maticsoft.Model.newsbig();

        model.newsclass = newsclass;
        model.newsid = newsid;

        Maticsoft.BLL.newsbig bll = new Maticsoft.BLL.newsbig();
        bll.Add(model);
        MessageBox.Show(this, "添加成功");
        this.txtcontent.Text = "";
        BindClass();
    }
}
