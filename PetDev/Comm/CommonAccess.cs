using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading;

namespace PetDev
{
    /// <summary>
    /// CommonAccess 的摘要说明。
    /// </summary>
    public class CommonAccess
    {

        private string _strSql = string.Empty;
        public string strSql
        {
            get
            {
                return _strSql;
            }
            set
            {
                _strSql = value;
            }
        }

        private bool _IsSP;
        public bool IsSP
        {
            get
            {
                return _IsSP;
            }
            set
            {
                _IsSP = value;
            }
        }


        private string _SqlParams = string.Empty;
        public string SqlParams
        {
            get
            {
                return _SqlParams;
            }
            set
            {
                _SqlParams = value;
            }
        }


        private string GetConnStr()
        {
            string strPath = GetPath();
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strPath + "SetXML//DB.xml");
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            string strPcName = "";
            string strDataName = "";
            string strUserName = "";
            string strPassWord = "";
            foreach (XmlNode node2 in node.ChildNodes)
            {
                switch (node2.Name.ToString())
                {
                    case "strPCName":
                        strPcName = node2.InnerText.ToString();
                        break;
                    case "strDBName":
                        strDataName = node2.InnerText.ToString();
                        break;
                    case "strUserName":
                        strUserName = node2.InnerText.ToString();
                        break;
                    case "strPassWord":
                        strPassWord = node2.InnerText.ToString();
                        break;

                    default:
                        break;
                }
            }
            return "Password=" + strPassWord + ";Persist Security Info=True;User ID=" + strUserName + ";Initial Catalog=" + strDataName + ";Data Source=" + strPcName;



            //return "Password=111111;Persist Security Info=True;User ID=sa;Initial Catalog=BBS;Data Source=.";

        }

        public DataTable getDataSet()
        {
            DataTable dtb = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                

                System.Data.SqlClient.SqlConnection cn = new SqlConnection();
                System.Data.SqlClient.SqlCommand cm = new SqlCommand();
                cn.ConnectionString = GetConnStr();
                cn.Open();
                cm.CommandText = strSql;
                System.Data.SqlClient.SqlDataAdapter sda = new SqlDataAdapter(cm.CommandText, cn);

                sda.Fill(ds);
                cn.Close();
                cm.Dispose();
            }
            catch (Exception ex)
            {
                string strerror = ex.Message;
                return dtb;
            }
            return ds.Tables[0];
        }
        private string GetPath()
        {
            string str = System.Windows.Forms.Application.ExecutablePath.ToString();
            string strPath = str.ToUpper().Replace("TOMDEV.EXE", "");
            return strPath;

        }

    }
}
