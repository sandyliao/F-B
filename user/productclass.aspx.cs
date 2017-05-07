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
public partial class user_productclass : System.Web.UI.Page
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
        
        string productname = this.txtcontent.Text;
        int productid = 0;

        Maticsoft.Model.productclass model = new Maticsoft.Model.productclass();
        
        model.productname = productname;
        model.productid = productid;

        Maticsoft.BLL.productclass bll = new Maticsoft.BLL.productclass();
        bll.Add(model);
        MessageBox.Show(this, "添加成功");
        this.txtcontent.Text = "";
        BindClass(); 
        return;
    }
    void BindClass()
    {
        List<productclass> list = Maticsoft.BLL.productclass.get_List();
        foreach (productclass model in list)
        {
            ListItem li = new ListItem();
            li.Text = "╋" + model.productname;
            li.Value = model.id.ToString();
            DropDownList1.Items.Add(li);
            BindChild(model.id.ToString(), "├──");
        }
    }

    void BindChild(string ParentID, string separator)
    {
        List<productclass> list = Maticsoft.BLL.productclass.get_List(ParentID);
        foreach (productclass model in list)
        {
            ListItem li = new ListItem();
            li.Text = separator + model.productname;
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

        string productname = this.TextBox1.Text;
        int productid =Convert.ToInt32(DropDownList1.SelectedValue);

        Maticsoft.Model.productclass model = new Maticsoft.Model.productclass();
        
        model.productname = productname;
        model.productid = productid;

        Maticsoft.BLL.productclass bll = new Maticsoft.BLL.productclass();
        bll.Add(model);
        MessageBox.Show(this, "添加成功");
        this.txtcontent.Text = "";
        BindClass();
        return;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(this.DropDownList1.SelectedValue);
        string sql = "DELETE FROM [productclass] WHERE [id] = " + id + "";
        DB.execnonsql(sql);
        MessageBox.ShowAndRedirect(this, "删除成功", "welcome.htm");
    }
}
