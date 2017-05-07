using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;

public partial class images : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
 
            ValidateNumber s = new ValidateNumber();
            string str = s.CreateValidateNumber(4);             
            memcached.Add("Vnumber" + memcached.GetIP(), str);
            s.CreateValidateGraphic(this, str);
 
    }

}


