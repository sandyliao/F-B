using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class WebUserControl_left : System.Web.UI.UserControl
{
    protected string jianjie;
    protected string touzilinian;
    protected string qixiachanpin;
    protected string hexintuandui;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int jjid = 7;
            Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
            Maticsoft.Model.gsclass model = bll.GetModel(jjid);

            jianjie = model.content;

            int newsid = 1;
            Maticsoft.DAL.newscontent bll1 = new Maticsoft.DAL.newscontent();
            //DataTable dt = bll1.GetAll(newsid, 6);
            //this.Repeater1.DataSource = dt;
            //this.Repeater1.DataBind();

            int tzlnid = 23;
            Maticsoft.Model.gsclass model_tzln = bll.GetModel(tzlnid);

            touzilinian = getSubString(model_tzln.content);

            int qxcpid = 26;
            Maticsoft.Model.gsclass model_qxcp = bll.GetModel(qxcpid);

            qixiachanpin = model_qxcp.content;
            int hxtdid = 28;
            Maticsoft.Model.gsclass model_hxtd = bll.GetModel(hxtdid);
            
            hexintuandui = getSubString(model_hxtd.content); 
        }
    }

    private string getSubString(string text) {
        if (text.IndexOf(@"<span") == -1) {
            return text.Length > 150 ? text.Substring(0, 150) : text;
        }
        int start = text.IndexOf("<span");
        int end = text.IndexOf("</span>") + "</span>".Length;
        if (end < start) {
            end = text.Length;
        }
        return text.Substring(start, end - start);
    }
   }