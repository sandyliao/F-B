using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Maticsoft.DBUtility;

public partial class user_Addcareeas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!memcached.CheckLogin())
        {
            Response.Redirect("index.aspx");
        }
        
    }
  
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string _cpmc = cpmctxt.Text;
        string _jjjl = jjjltxt.Text;
        string _clrq = clrqtxt.Text;
        string _gxrq = gxrqtxt.Text;
        string _jz = jztxt1.Text;
        string _ljzzl = ljzzltxt1.Text;
        string _bz = bztxt.Text;
        string _jnzzl = jnzzltxt.Text;
        string _jz1 = jztxt2.Text;
        string _ljzzl1 = ljzzltxt2.Text;
       
            string _xtmc = xtmctxt.Text;
            string _xtlx = xtlxtxt.Text;
            string _xtjg = xtjg.Text;
            string _str = str.Text;
            string _xtyh = xtyh.Text;
            string _xtzh = xtzh.Text;
            string _zqjjs = zqjjs.Text;
            string _tzgw = tzgw.Text;
            string _xtkh = xtkh.Text;
            string _rgje = rgjgtxt.Text;
            string _rgfl = rgfltxt.Text;
            string _fbq = fbq.Text;
            string _kfq = kfr.Text;
            string _zjje = zjje.Text;
            string _glfl = glfl.Text;
            string _shfl = shfl.Text;
            string _fdglfl = fdglfl.Text;
            string _wddm = wddm.Text;
            string _pbdm = pbdm.Text;
  
        
        Maticsoft.Model.qxcp model = new Maticsoft.Model.qxcp();

        model.cpmc = _cpmc;
        model.jjjl = _jjjl;
        model.clrq = _clrq;
        model.gxrq = _gxrq;
        model.jz = _jz;
        model.ljzzl = _ljzzl;
        model.bz = _bz;
        model.jnzzl = _jnzzl;

        model.jz1 = _jz1;
        model.ljzzl1 = _ljzzl1;

        model.xtmc =_xtmc ;
        model.xtlx =_xtlx ;
        model.xtjg =_xtjg ;
        model.str =_str ;
        model.xtyh =_xtyh ;
        model.xtzh =_xtzh ;
        model.zqjjs =_zqjjs;
        model.tzgw =_tzgw ;
        model.xtkh =_xtkh ; 
        model.rgje =_rgje ;
        model.rgfl =_rgfl ;
        model.fbq =_fbq ;
        model.kfq =_kfq ;
        model.zjje =_zjje ;
        model.glfl =_glfl ;
        model.shfl =_shfl ;
        model.fdglfl =_fdglfl;
        model.wddm =_wddm ;
        model.pbdm = _pbdm;
        Add(model);
        return;
        //string strErr = "";



        //if (this.WE_NewsContent.Text == "")
        //{
        //    strErr += "请输入内容！\\n";
        //}

        //if (strErr != "")
        //{
        //    MessageBox.Show(this, strErr);
        //    return;
        //}

        //int id = Convert.ToInt32(DB.SQLReplace(Request.QueryString["id"]));

        //string content = this.WE_NewsContent.Text;


        //Maticsoft.Model.gsclass model = new Maticsoft.Model.gsclass();
        //model.id = id;
        //model.content = content;

        //Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
        //bll.Update(model);
        //MessageBox.Show(this, "更新成功");
        //return;
    }

    public void Add(Maticsoft.Model.qxcp model)
    {
        StringBuilder strSql = new StringBuilder();
        StringBuilder strSql1 = new StringBuilder();
        StringBuilder strSql2 = new StringBuilder();
        if (model.id != null)
        {
            strSql1.Append("id,");
            strSql2.Append("" + model.id + ",");
        }
        if (model.cpmc != null)
        {
            strSql1.Append("cpmc,");
            strSql2.Append("'" + model.cpmc + "',");
        }
        if (model.jjjl != null)
        {
            strSql1.Append("jjjl,");
            strSql2.Append("'" + model.jjjl + "',");
        }
        if (model.clrq != null)
        {
            strSql1.Append("clrq,");
            strSql2.Append("'" + model.clrq + "',");
        }
        if (model.gxrq != null)
        {
            strSql1.Append("gxrq,");
            strSql2.Append("'" + model.gxrq + "',");
        }
        if (model.jz != null)
        {
            strSql1.Append("jz,");
            strSql2.Append("'" + model.jz + "',");
        }
        if (model.ljzzl != null)
        {
            strSql1.Append("ljzzl,");
            strSql2.Append("'" + model.ljzzl + "',");
        }
        if (model.bz != null)
        {
            strSql1.Append("bz,");
            strSql2.Append("'" + model.bz + "',");
        } if (model.jnzzl != null)
        {
            strSql1.Append("jnzzl,");
            strSql2.Append("'" + model.jnzzl + "',");
        } if (model.jz1 != null)
        {
            strSql1.Append("jz1,");
            strSql2.Append("'" + model.jz1 + "',");
        }
        if (model.ljzzl1 != null)
        {
            strSql1.Append("ljzzl1,");
            strSql2.Append("'" + model.ljzzl1 + "',");
        } 
        if (model.xtmc != null)
        {
            strSql1.Append("xtmc,");
            strSql2.Append("'" + model.xtmc + "',");
        }
        if (model.xtlx != null)
        {
            strSql1.Append("xtlx,");
            strSql2.Append("'" + model.xtlx + "',");
        }
        if (model.xtjg != null)
        {
            strSql1.Append("xtjg,");
            strSql2.Append("'" + model.xtjg + "',");
        } if (model.str != null)
        {
            strSql1.Append("str,");
            strSql2.Append("'" + model.str + "',");
        }
        if (model.rgfl != null)
        {
            strSql1.Append("rgfl,");
            strSql2.Append("'" + model.rgfl + "',");
        }
        if (model.xtyh != null)
        {
            strSql1.Append("xtyh,");
            strSql2.Append("'" + model.xtyh + "',");
        }
        if (model.xtzh != null)
        {
            strSql1.Append("xtzh,");
            strSql2.Append("'" + model.xtzh + "',");
        }
        if (model.zqjjs != null)
        {
            strSql1.Append("zqjjs,");
            strSql2.Append("'" + model.zqjjs + "',");
        }
        if (model.tzgw != null)
        {
            strSql1.Append("tzgw,");
            strSql2.Append("'" + model.tzgw + "',");
        }
        if (model.xtkh != null)
        {
            strSql1.Append("xtkh,");
            strSql2.Append("'" + model.xtkh + "',");
        }
        if (model.rgje != null)
        {
            strSql1.Append("rgje,");
            strSql2.Append("'" + model.rgje + "',");
        }
        if (model.fbq != null)
        {
            strSql1.Append("fbq,");
            strSql2.Append("'" + model.fbq + "',");
        }
        if (model.kfq != null)
        {
            strSql1.Append("kfq,");
            strSql2.Append("'" + model.kfq + "',");
        }
        if (model.zjje != null)
        {
            strSql1.Append("zjje,");
            strSql2.Append("'" + model.zjje + "',");
        }
        if (model.glfl != null)
        {
            strSql1.Append("glfl,");
            strSql2.Append("'" + model.glfl + "',");
        }
        if (model.shfl != null)
        {
            strSql1.Append("shfl,");
            strSql2.Append("'" + model.shfl + "',");
        }
        if (model.fdglfl != null)
        {
            strSql1.Append("fdglfl,");
            strSql2.Append("'" + model.fdglfl + "',");
        }
        if (model.wddm != null)
        {
            strSql1.Append("wddm,");
            strSql2.Append("'" + model.wddm + "',");
        }
        if (model.pbdm != null)
        {
            strSql1.Append("pbdm,");
            strSql2.Append("'" + model.pbdm + "',");
        }
        strSql.Append("insert into qxcp(");
        strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
        strSql.Append(")");
        strSql.Append(" values (");
        strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
        strSql.Append(")");
        DbHelperOleDb.ExecuteSql(strSql.ToString());
        GridView1.DataBind();
    }
}
