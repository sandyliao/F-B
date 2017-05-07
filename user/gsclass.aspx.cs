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
public partial class user_gsclass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Convert.ToString(Session["userName"]);

        //=Convert.ToString(Session["qx"]);
        if (userName == "")
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
            BindClass();
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

        int classid = Convert.ToInt32(this.DropDownList1.SelectedValue);
        string content = this.TextBox1.Text;

        Maticsoft.Model.gsclass model = new Maticsoft.Model.gsclass();

        model.classid = classid;
        model.classname = content;

        Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
        bll.Add(model);
        MessageBox.ResponseScript("top.main.location.href='gsclass.aspx'"); 
        return;
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
       
        int classid = 0;
        string content = this.txtcontent.Text;

        Maticsoft.Model.gsclass model = new Maticsoft.Model.gsclass();
       
        model.classid = classid;
        model.classname = content;

        Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
        bll.Add(model);
        MessageBox.Show(this, "添加成功");
        txtcontent.Text = "";
        return;
        
    
  
    }
    void BindClass()
    {
        List<gsclass> list = Maticsoft.BLL.gsclass.get_List();
        foreach (gsclass model in list)
        {
            ListItem li = new ListItem();
            li.Text = "╋" + model.classname;
            li.Value = model.id.ToString();
            DropDownList1.Items.Add(li);
            BindChild(model.id.ToString(), "├──");
        }
    }

    void BindChild(string ParentID, string separator)
    {
        List<gsclass> list = Maticsoft.BLL.gsclass.get_List(ParentID);
        foreach (gsclass model in list)
        {
            ListItem li = new ListItem();
            li.Text = separator + model.classname;
            li.Value = model.id.ToString();
            DropDownList1.Items.Add(li);
            string separator_ = separator + "───";
            BindChild(model.id.ToString(), separator_);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.DropDownList1.SelectedValue);
        string sql = "DELETE FROM [gsclass] WHERE [id] = " + id + "";
        DB.execnonsql(sql);
        MessageBox.ShowAndRedirect(this, "删除成功", "welcome.htm");
    }
}
