using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;

namespace PetDev
{
    public partial class WFSPSet : Form
    {
         #region"变量定义"
        private CommonAccess objAccess = new CommonAccess();

        private string strPath = "";
        private string strSysSetPath ="";
        private string strSelectPath = "";
        private string strInsertPath = "";
        private string strUpdatePath = "";
        private string strDeletePath = "";
        private string strBLLPath = "";
        private string strWebPath = "";
        private string strSPPath = "";


        private string strModulesPath = "";
        #endregion

        public WFSPSet()
        {
            InitializeComponent();
        }

        private void FillTree(DataTable A_dtbTableName)
        {
            foreach (DataRow dr in A_dtbTableName.Rows)
            {

                TreeNode trn = new TreeNode();
                trn.Text = dr["name"].ToString();
                trn.Tag = dr["id"].ToString();

                treeData.Nodes.Add(trn);

                treeData.SelectedNode = trn;
                objAccess.strSql = "SELECT NAME AS [ColName] from syscolumns  WHERE id = '" + dr["id"].ToString() + "' ";
                objAccess.IsSP = false;
                objAccess.SqlParams = null;
                DataTable dtTableNameCol = new DataTable();
                dtTableNameCol = objAccess.getDataSet();

                foreach (DataRow dr1 in dtTableNameCol.Rows)
                {
                    TreeNode trn1 = new TreeNode();
                    trn1.Text = dr1["ColName"].ToString();

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

        private void WFSPSet_Load(object sender, EventArgs e)
        {
            strPath = GetPath();
            strSysSetPath = strPath + "SetXML//DB.xml";
            strSelectPath = strPath + "SetClass//SQL//Select.txt";
            strUpdatePath = strPath + "SetClass//SQL//Update.txt";
            strDeletePath = strPath + "SetClass//SQL//Delete.txt";
            strInsertPath = strPath + "SetClass//SQL//Insert.txt";
            strBLLPath = strPath + "SetClass//SQL//BLL.txt";
            strWebPath = strPath + "SetClass//SQL//Web.txt";
            strModulesPath = strPath + "SetClass//SQL//Modules.txt";
            strSPPath = strPath + "SetClass//SQL//SP.txt";
            //string strDBOwner = GetOwer();
            DataTable dtTableName = new DataTable();

            objAccess.strSql = "select name ,id from sysobjects where xtype='P' and category='0' ORDER BY name";
            objAccess.IsSP = false;
            objAccess.SqlParams = null;
            dtTableName = objAccess.getDataSet();
            treeData.Nodes.Clear();
            FillTree(dtTableName);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            DataTable  dtbConame;
			dtbConame=GetColTable();

			int i=0;
			TextWriter tmp = Console.Out;

            FileStream OutFile = new FileStream(strSPPath, FileMode.Create);
			
			StreamWriter objWriter = new StreamWriter(OutFile);
			Console.SetOut(objWriter);
			


			string strPa="";
			string strNewSp="";
			string strPaValue="";
			foreach  (DataRow  dr in dtbConame.Rows )
			{
				
						string intLength="0";
						string strtype="";
						
						string strIn="";
						string strLength="";
						string strOutType="";
						string  strOutSqlType="";
						string  strOutValue="";
                        GetColInfo(dr["ColName"].ToString(), dr["DBType"].ToString(), dr["Length"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);
						if(dr["DBType"].ToString()=="uniqueidentifier")
						{
							strtype="nvarchar";
							intLength="50";
						}
						else
						{
							strtype=dr["DBType"].ToString();
							intLength=strLength;
						}
						if (strPa!="")
						{
							if(dr["status"].ToString()=="4")
							{
								strPa+=" \n";
								strPa+="parameters["+i+"] ="+GetPa(dr["DBType"].ToString(),dr["ColName"].ToString(),dr["Length"].ToString());
								
							}
							else
							{
								strPa+=" \n";
								strPa+="parameters["+i+"] =new SqlParameter(\""+dr["ColName"].ToString()+"\","+GetSqlType(dr["DBType"].ToString())+","+intLength+");";
								
							}
							if(dr["status"].ToString()=="4")
							{
								strPa+=" \n";
								strPa+="parameters["+i+"].Value=" + GetPaVal(dr["DBType"].ToString())+";";
							}
							else
							{
								strPa+=" \n";
								strPa+="parameters["+i+"].Value=" + GetSqlPar(dr["DBType"].ToString(),"p_objParams[\""+dr["ColName"].ToString().Replace("@","")+"\"]")+";";
							}
							
						}
						else
						{
							if(dr["status"].ToString()=="4")
							{
								strPa+="parameters["+i+"] ="+GetPa(dr["DBType"].ToString(),dr["ColName"].ToString(),dr["Length"].ToString());
							}
							else
							{
								strPa+= "parameters["+i+"] =new SqlParameter(\""+dr["ColName"].ToString()+"\","+GetSqlType(dr["DBType"].ToString())+","+intLength+");";
							}
							if(dr["status"].ToString()=="4")
							{
								strPa+=" \n";
								strPa+="parameters["+i+"].Value=" + GetPaVal(dr["DBType"].ToString())+";";
							}
							else
							{
								strPa+=" \n";
								strPa+="parameters["+i+"].Value=" + GetSqlPar(dr["DBType"].ToString(),"p_objParams[\""+dr["ColName"].ToString().Replace("@","")+"\"]")+";";
							}

						}	

					i++;
				
			}
			int j=i-2;
			i=i-1;
			strNewSp="SqlParameter[] parameters = new SqlParameter["+i+"]";

            Console.WriteLine("public int ExceSp(Hashtable p_objParams)");
			Console.WriteLine("{");
			Console.WriteLine(strNewSp+";");
			Console.WriteLine(strPa);
			//Console.WriteLine(strPaValue);
			Console.WriteLine("this.BeginTransaction() ;");
			Console.WriteLine("int iReturn = -1 ;");

			Console.WriteLine("this.ExecuteSP (\""+treeData.SelectedNode.Text.ToString()+"\",parameters) ;");
			Console.WriteLine("if (parameters["+j+"].Value != System.DBNull.Value)");
			Console.WriteLine("{");
			Console.WriteLine("	iReturn = Convert.ToInt32(parameters["+j+"].Value);");
			Console.WriteLine("}");
			Console.WriteLine("if (iReturn == 0)");
			Console.WriteLine("{");
			Console.WriteLine(" this.CommitTransection();");
			Console.WriteLine("}");
			Console.WriteLine("else");
			Console.WriteLine("{");
			Console.WriteLine("  this.RollbackTransection();;");
			Console.WriteLine("}");
			Console.WriteLine("	return iReturn ;");
			Console.WriteLine("}");

			objWriter.Close();
			Console.SetOut(tmp);
            OpenFile(strSPPath);

        }


        private DataTable GetColTable()
        {
            string strSpName = "";
            strSpName = this.treeData.SelectedNode.Tag.ToString();
            if (strSpName == "")
            {
                MessageBox.Show("请选择需要生成的SP!");
                return null;
            }
            objAccess.strSql = "SELECT a.name as ColName,b.name as DBType,a.length as length ,a.colstat as status   from syscolumns as a ,systypes as b   WHERE a.xtype=b.xtype and a.id = '" + strSpName + "' and b.status <>'1'  order by a.colid ";
            objAccess.IsSP = false;
            objAccess.SqlParams = null;
            DataTable dtTableNameCol = new DataTable();
            dtTableNameCol = objAccess.getDataSet();
            return dtTableNameCol;
        }

        #region"数据类型处理"
        private void GetColInfo(string strColName, string strType, string strInLength, out string strOut, out string strOutLength, out string stroutType, out string strOutSqlType, out string strOutValue)
        {

            strOut = "";
            strOutLength = "";
            stroutType = "";
            strOutSqlType = "";
            strOutValue = "";

            switch (strType)
            {
                case "float":
                    strOutLength = "8";
                    strOut = "flt" + strColName;
                    stroutType = "float";
                    strOutSqlType = "Float";
                    strOutValue = "=float.MinValue";
                    break;
                case "datetime":
                    strOutLength = "8";
                    strOut = "dtm" + strColName;
                    stroutType = "DateTime";
                    strOutSqlType = "DateTime";
                    strOutValue = "=DateTime.MinValue";
                    break;
                case "uniqueidentifier":
                    strOutLength = "16";
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "=UniqueIdentifier";
                    strOutValue = "";
                    break;
                case "int":
                    strOutLength = "4";
                    strOut = "int" + strColName;
                    stroutType = "int";
                    strOutSqlType = "Int";
                    strOutValue = "=int.MinValue";
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
                    strOutLength = strInLength;
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "Char";
                    strOutValue = "";
                    break;
                case "nvarchar":
                    strOutLength = strInLength;
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "NVarChar";
                    strOutValue = "";
                    break;
                case "varchar":
                    strOutLength = strInLength;
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "VarChar";
                    strOutValue = "";
                    break;
                case "nchar":
                    strOutLength = strInLength;
                    strOut = "str" + strColName;
                    stroutType = "string";
                    strOutSqlType = "NChar";
                    strOutValue = "";
                    break;
                case "image":
                    strOutLength = strInLength;
                    strOut = "Img" + strColName;
                    stroutType = "byte[]";
                    strOutSqlType = "Image";

                    break;


                default:
                    strOutLength = strInLength;
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
                case "int":
                    strTypeValue = "Int";

                    break;

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
                    strTypeValue = "Float";
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
        #endregion
        private string GetPa(string strType, string strCoName, string strLength)
        {

            if (strType == "int")
            {
                return "new SqlParameter(\"" + strCoName + "\",SqlDbType.Int  ,4,ParameterDirection.Output,false,0, 0, String.Empty, DataRowVersion.Default, 0);";
            }
            if (strType == "varchar")
            {
                return "new SqlParameter(\"" + strCoName + "\",SqlDbType.VarChar ," + strLength + ",ParameterDirection.Output,false,0, 0, String.Empty, DataRowVersion.Default, \"\");";
            }
            if (strType == "char")
            {
                return "new SqlParameter(\"" + strCoName + "\",SqlDbType.Char ," + strLength + ",ParameterDirection.Output,false,0, 0, String.Empty, DataRowVersion.Default, \"\");";
            }
            if (strType == "uniqueidentifier")
            {
                return "new SqlParameter(\"" + strCoName + "\",SqlDbType.UniqueIdentifier ,16,ParameterDirection.Output,false,0, 0, String.Empty, DataRowVersion.Default, \"\");";
            }
            else
            {
                return "";
            }


        }

        private string GetPaVal(string strType)
        {

            if (strType == "int")
            {
                return "0";
            }
            if (strType == "varchar")
            {
                return "\"\"";
            }
            if (strType == "char")
            {
                return "\"\"";
            }
            if (strType == "uniqueidentifier")
            {
                return "\"\"";
            }
            else
            {
                return "";
            }


        }

        private string GetSqlType(string p_strType)
        {
            string strOutSPType = "";
            switch (p_strType)
            {
                case "float":
                    strOutSPType = "SqlDbType.Float";
                    break;
                case "datetime":
                    strOutSPType = "SqlDbType.DateTime";
                    break;
                case "int":
                    strOutSPType = "SqlDbType.Int";
                    break;
                case "smalldatetime":
                    strOutSPType = "SqlDbType.SmallDateTime";
                    break;
                case "bit":
                    strOutSPType = "SqlDbType.Bit";
                    break;
                case "smallint":
                    strOutSPType = "SqlDbType.SmallInt";
                    break;
                case "real":
                    strOutSPType = "SqlDbType.Real";
                    break;
                case "money":
                    strOutSPType = "SqlDbType.Money";
                    break;
                case "char":
                    strOutSPType = "SqlDbType.Char";
                    break;
                case "nvarchar":
                    strOutSPType = "SqlDbType.NVarChar";
                    break;
                case "varchar":
                    strOutSPType = "SqlDbType.VarChar";
                    break;
                case "nchar":
                    strOutSPType = "SqlDbType.NChar";
                    break;
                case "image":
                    strOutSPType = "SqlDbType.Image";
                    break;
                default:
                    strOutSPType = "SqlDbType.NVarChar";
                    break;
            }
            return strOutSPType;
        }

        private string GetSqlPar(string p_strType, string p_strValue)
        {
            string strOutSPType = "";
            switch (p_strType)
            {
                case "float":
                    strOutSPType = "float.Parse(" + p_strValue + ")";
                    break;
                case "datetime":
                    strOutSPType = "DateTime.Parse(" + p_strValue + ")";
                    break;
                case "int":
                    strOutSPType = "Convert.ToInt32(" + p_strValue + ")";
                    break;
                case "char":
                    strOutSPType = p_strValue;
                    break;

                default:
                    strOutSPType = p_strValue;
                    break;
            }
            return strOutSPType;
        }

        #region"文件处理"
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
                txtValue.Text = streamReader.ReadToEnd();
            }

        }

       

   
        #endregion
    }
}
