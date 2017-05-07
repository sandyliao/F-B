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

public partial class about1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = 1;
            Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
            DataTable dt = bll.GetAll(id);
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
            int aboutid = Convert.ToInt32(DB.replace((Request.QueryString["id"]), ""));
            if (Convert.ToInt32(DB.FindString("select count(*) from [gsclass] where id=" + aboutid + "")) > 0)
            {
                Maticsoft.BLL.gsclass bll1 = new Maticsoft.BLL.gsclass();

                Maticsoft.Model.gsclass model = bll1.GetModel(aboutid);
                this.Label1.Text = model.classname;
                bind();

            }
            else
            {
                MessageBox.Show(this, "没有找到你要的内容");
                return;
            }
        }
    }
    void bind()
    {
        int aboutid = Convert.ToInt32(DB.replace((Request.QueryString["id"]), ""));
        if (Convert.ToInt32(DB.FindString("select count(*) from [gscontent] where classid=" + aboutid + "")) > 0)
        {
            string sql = "select * from [gscontent] where classid=" + aboutid + "";
            DataView dv = DB.getdataset(sql).Tables[0].DefaultView;
            PagedDataSource pds = new PagedDataSource();

            AspNetPager1.RecordCount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            this.Repeater2.DataSource = pds;
            this.Repeater2.DataBind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind();
    }
}
