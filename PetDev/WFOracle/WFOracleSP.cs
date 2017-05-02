using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace PetDev
{
    public partial class WFOracleSP : Form
    {
        private CommonAccess objAccess = new CommonAccess();
        private string strPath = "";
        private string strSysSetPath = "";
        private string strSPPath = "";
        private string strSPWebPath = "";
        public WFOracleSP()
        {
            InitializeComponent();
        }

        private void WFOracleSP_Load(object sender, EventArgs e)
        {
            strPath = GetPath();
            strSysSetPath = strPath + "SetXML//DB.xml";
            strSPPath = strPath + "SetClass//SP.txt";
            strSPWebPath = strPath + "SetClass//SPWeb.txt";


            string strDBOwner = GetOwer();


            DataTable dtTableName = new DataTable();

            objAccess.strSql = "select OBJECT_NAME as table_name from dba_procedures  where owner='" + strDBOwner + "' order by object_name";
            objAccess.IsSP = false;
            objAccess.SqlParams = null;
            dtTableName = objAccess.getDataSet();
            treeData.Nodes.Clear();
            FillTree(dtTableName);
        }
        /// <summary>
        /// 获取表的所有者
        /// </summary>
        /// <returns></returns>
        private string GetOwer()
        {
            string strDBOwner = "";
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strSysSetPath);
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node2 in node.ChildNodes)
            {
                switch (node2.Name.ToString())
                {
                    case "strDBName":
                        strDBOwner = node2.InnerText.ToString();
                        break;
                    default:
                        break;
                }
            }

            return strDBOwner;
        }

        /// <summary>
        /// 填充数据库表结构
        /// </summary>
        /// <param name="A_dtbTableName"></param>
        private void FillTree(DataTable A_dtbTableName)
        {
            string strDBOwner = GetOwer();
            foreach (DataRow dr in A_dtbTableName.Rows)
            {

                TreeNode trn = new TreeNode();
                trn.Text = dr["table_name"].ToString();
                treeData.Nodes.Add(trn);
                treeData.SelectedNode = trn;
                objAccess.strSql = "select ARGUMENT_NAME AS ColName ,IN_OUT from all_arguments where owner = '" + strDBOwner + "' and OBJECT_NAME= '" + dr["table_name"].ToString() + "' order by IN_OUT ";
                objAccess.IsSP = false;
                objAccess.SqlParams = null;
                DataTable dtTableNameCol = new DataTable();
                dtTableNameCol = objAccess.getDataSet();

                foreach (DataRow dr1 in dtTableNameCol.Rows)
                {
                    TreeNode trn1 = new TreeNode();
                    trn1.Text = dr1["ColName"].ToString() + "(" + dr1["IN_OUT"].ToString()+")";
                    treeData.SelectedNode.Nodes.Add(trn1);
                }

            }
        }
        /// <summary>
        /// 获取当前应用程序了物理路径
        /// </summary>
        /// <returns></returns>
        private string GetPath()
        {
            string str = System.Windows.Forms.Application.ExecutablePath.ToString();
            string strPath = str.ToUpper().Replace("TOMDEV.EXE", "");
            return strPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextWriter tmp = Console.Out;

            FileStream OutFile = new FileStream(strSPPath, FileMode.Create);

            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);
            //生成模板		  									  
            GetSP();
            objWriter.Close();
            Console.SetOut(tmp);
            OpenFile(strSPPath);
            MessageBox.Show("调用方法生成成功,可以到SetClass文件夹下查看SP.txt文件");
        }
        /// <summary>
        /// 生成select 查询函数方法
        /// </summary>
        private void GetSP()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// 根据条件获取查询数据");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\"p_hasParameter\">");
            Console.WriteLine("/// 查询条件HashTable的Key为:");
            string strDBOwner = GetOwer();
            objAccess.strSql = "select ARGUMENT_NAME AS ColName ,IN_OUT,DATA_TYPE AS Type  from all_arguments where owner = '" + strDBOwner + "' and OBJECT_NAME= '" + this.treeData.SelectedNode.Text.ToString() + "' order by POSITION  ";
            objAccess.IsSP = false;
            objAccess.SqlParams = null;
            DataTable dtTableNameCol = new DataTable();
            dtTableNameCol = objAccess.getDataSet();

            foreach (DataRow dr1 in dtTableNameCol.Rows)
            {

                Console.WriteLine("///" + dr1["ColName"].ToString() + "--" + dr1["IN_OUT"].ToString()); ;
                 
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>返回查询结果结合</returns>");

            Console.WriteLine("public int Exc" + this.treeData.SelectedNode.Text.ToString() + "(Hashtable p_hasParameter)");
            Console.WriteLine("{");
            Console.WriteLine("	string strSQL =\"\";");
            //*****************************************************************查询语句
            Console.WriteLine("	strSQL =\""+this.treeData.SelectedNode.Text.ToString()+ "\";");
            int intCount = dtTableNameCol.Rows.Count;
            int i = 0;
            Console.WriteLine("OracleParameter[] objParameter = new OracleParameter[" + intCount.ToString() + "];");
            Console.WriteLine("");
            foreach (DataRow dr in dtTableNameCol.Rows)
            {
                string strCol1 = dr["ColName"].ToString();
                string strIn = "";
                string strLength = "";
                string strOutType = "";
                string strOutSqlType = "";
                string strOutValue = "";
                string strDefault = "";
                GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), "", "", out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue, out strDefault);
                if (dr["IN_OUT"].ToString() == "IN")
                {
                    Console.WriteLine(" objParameter[" + i + "] = new OracleParameter(\":" + strCol1.ToString() + "\", System.Data.OracleClient.OracleType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine(" objParameter[" + i + "].Value = p_hasParameter[\"" + strCol1.ToString() + "\"];");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine(" objParameter[" + i + "] = new OracleParameter(\":" + strCol1.ToString() + "\", System.Data.OracleClient.OracleType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ", ParameterDirection.Output, false, 0, 0, String.Empty, DataRowVersion.Default, "+strDefault+");");
                    Console.WriteLine(" objParameter[" + i + "].Value =  ParameterDirection.Output ;");
                    Console.WriteLine("");
                }

                i++;
            }

            Console.WriteLine("	return this.ExecuteSP(strSQL, objParameter);");
            Console.WriteLine("}");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            TextWriter FileSQLDAL = Console.Out;

            FileStream OutFile = new FileStream(strSPWebPath, FileMode.Create);

            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);

            GetSPWeb();

            objWriter.Close();
            Console.SetOut(FileSQLDAL);
            OpenFile(strSPWebPath);
            MessageBox.Show("WEB中Hashtable值组织函数生成成功,可以到SetClass文件夹下查看SPWeb.txt文件");
        }

        private void GetSPWeb()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// 生成Hastable");
            Console.WriteLine("/// </summary>");
            string strDBOwner = GetOwer();
            Console.WriteLine("public HashMap Get" + this.treeData.SelectedNode.Text.ToString() + "Info()");
            Console.WriteLine("{");

            //*****************************************************************查询语句
            Console.WriteLine(" Hashtale objHas = new Hashtale();");

            objAccess.strSql = "select ARGUMENT_NAME AS ColName ,IN_OUT,DATA_TYPE AS Type  from all_arguments where owner = '" + strDBOwner + "' and OBJECT_NAME= '" + this.treeData.SelectedNode.Text.ToString() + "' order by POSITION  ";
            objAccess.IsSP = false;
            objAccess.SqlParams = null;
            DataTable dtTableNameCol = new DataTable();
            dtTableNameCol = objAccess.getDataSet();

            foreach (DataRow dr in dtTableNameCol.Rows)
            {
                Console.WriteLine("objHas.Add(\"" + dr["ColName"].ToString() + "\", txt" + dr["ColName"].ToString() + ".Text);//" + dr["IN_OUT"].ToString());
            }
            Console.WriteLine(" return objHas;");
            Console.WriteLine("}");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 根据数据表中的列的类型得到前缀 sqltye。。。
        /// </summary>
        /// <param name="strColName"></param>
        /// <param name="strType"></param>
        /// <param name="strInLength"></param>
        /// <param name="strOut"></param>
        /// <param name="strOutLength"></param>
        /// <param name="stroutType"></param>
        /// <param name="strOutSqlType"></param>
        private void GetColInfo(string strColName, string strType, string strInLength, string strNumberLength, out string strOut, out string strOutLength, out string stroutType, out string strOutSqlType, out string strOutValue, out string strDefault)
        {

            strOut = "";
            strOutLength = "";
            stroutType = "";
            strOutSqlType = "";
            strOutValue = "";
            strDefault = "\"\"";

            switch (strType.ToLower())
            {
                case "float":
                    strOutLength = "8";
                    strOut = "flt" + strColName;
                    stroutType = "float";
                    strOutSqlType = "Float";
                    strOutValue = "=float.MinValue";
                    strDefault = "-1";
                    break;
                case "date":
                    strOutLength = "8";
                    strOut = "dtm" + strColName;
                    stroutType = "DateTime";
                    strOutSqlType = "DateTime";
                    strOutValue = "=DateTime.MinValue";
                    strDefault = "DateTime.MinValue";
                    break;
                case "uniqueidentifier":
                    strOutLength = "16";
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "=UniqueIdentifier";
                    strOutValue = "";
                    strDefault = "\"\"";
                    break;
                case "number":
                    strOutLength = "10";
                    strOut = "int" + strColName;
                    stroutType = "int";
                    strOutSqlType = "Int";
                    strOutValue = "=int.MinValue";
                    strDefault = "-1";
                    break;
                case "smalldatetime":
                    strOutLength = "4";
                    strOut = "dtm" + strColName;
                    stroutType = "DateTime";
                    strOutSqlType = "SmallDateTime";
                    strOutValue = "=DateTime.MinValue";
                    break;
                case "bit":
                    strOutLength = "1";
                    strOut = "bit" + strColName;
                    stroutType = "bit";
                    strOutSqlType = "Bit";
                    strOutValue = "";
                    break;
                case "smallint":
                    strOutLength = "2";
                    strOut = "int" + strColName;
                    stroutType = "int";
                    strOutSqlType = "=SmallInt";
                    break;
                case "real":
                    strOutLength = "4";
                    strOut = "rel" + strColName;
                    stroutType = "float";
                    strOutSqlType = "=Real";
                    break;
                case "money":
                    strOutLength = "8";
                    strOut = "moy" + strColName;
                    stroutType = "Decimal";
                    strOutSqlType = "Money";
                    break;
                case "char":
                    strOutLength = "50";
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "Char";
                    strOutValue = "";
                    strDefault = "' '";
                    break;
                case "nvarchar":
                    strOutLength = "50";
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "NVarChar";
                    strOutValue = "";
                    strDefault = "\"\"";
                    break;
                case "varchar2":
                    strOutLength = "50";
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "VarChar";
                    strOutValue = "";
                    strDefault = "\"\"";
                    break;
                case "nchar":
                    strOutLength = "50";
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "NChar";
                    strOutValue = "";
                    strDefault = "\"\"";
                    break;
                case "image":
                    strOutLength = "50";
                    strOut = "Img" + strColName;
                    stroutType = "byte[]";
                    strOutSqlType = "Image";

                    break;


                default:
                    strOutLength = "50";
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "NVarChar";
                    strOutValue = "";
                    break;
            }
        }

        /// <summary>
        /// 获取Oracle数据类型
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        private string GetOracleType(string strType)
        {
            string strTypeValue;
            switch (strType.ToLower())
            {

                case "char":
                    strTypeValue = "Char";

                    break;
                case "number":
                    strTypeValue = "Number";

                    break;
                case "varchar2":
                    strTypeValue = "VarChar";

                    break;
                case "date":
                    strTypeValue = "DateTime";

                    break;
                case "float":
                    strTypeValue = "Double";
                    break;
                case "nvarchar":
                    strTypeValue = "VarChar";
                    break;
                default:
                    strTypeValue = "VarChar";

                    break;

            }
            return strTypeValue;
        }

        /// <summary>
        /// 打开xml文件 
        /// </summary>
        private void OpenFile(string strFileName)
        {

            TextWriter stringWriter = new StringWriter();

            TextReader stringReader =
                new StringReader(stringWriter.ToString());
            using (TextReader streamReader =
                      new StreamReader(strFileName))
            {
                txtCSMorSQLDAL.Text = streamReader.ReadToEnd();
            }

        }

    }
}