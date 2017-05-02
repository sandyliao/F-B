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
    public partial class WFOracleMor : Form
    {
        #region"变量定义"
        private CommonAccess objAccess = new CommonAccess();
        private string strPath = "";
        private string strSysSetPath = "";
        private string strSelectTwoPath = "";
        
        #endregion
        public WFOracleMor()
        {
            InitializeComponent();
        }

        private void WFOracleMor_Load(object sender, EventArgs e)
        {
            strPath = GetPath();
            strSysSetPath = strPath + "SetXML//DB.xml";
            strSelectTwoPath = strPath + "SetClass//SelectTwo.txt";
           

            string strDBOwner = GetOwer();
            DataTable dtTableName = new DataTable();

            objAccess.strSql = "select table_name from all_tables  where owner='" + strDBOwner + "' ORDER BY table_name";
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
                objAccess.strSql = "SELECT Column_Name AS ColName FROM all_tab_columns  where Table_Name= '" + dr["table_name"].ToString() + "'and owner='" + strDBOwner + "' order by Column_id ";
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
                txtCSMorSQLDAL.Text = streamReader.ReadToEnd();
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

        
        #endregion

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTableName.Text == "")
                {
                    listTableCol.Items.Clear();
                    txtTableName.Text = this.treeData.SelectedNode.Text.ToString();

                    foreach (TreeNode nd in treeData.SelectedNode.Nodes)
                    {
                        listTableCol.Items.Add(nd.Text.ToString());
                    }
                }
                else
                {
                    if (txtTableName1.Text == "")
                    {
                        listTableCol1.Items.Clear();
                        txtTableName1.Text = this.treeData.SelectedNode.Text.ToString();

                        foreach (TreeNode nd in treeData.SelectedNode.Nodes)
                        {
                            listTableCol1.Items.Add(nd.Text.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("您已经选择了两个表操作，请清除所有或者删除一个表名后重新操作！");
                    }
                }
            }
            catch
            {
            }
        }

        private void btnAddTableName_Click(object sender, EventArgs e)
        {
            if (txtTableName.Text == "")
            {
                listTableCol.Items.Clear();
                txtTableName.Text = this.treeData.SelectedNode.Text.ToString();
            }
            else
            {
                if (txtTableName1.Text == "")
                {
                    listTableCol1.Items.Clear();
                    txtTableName1.Text = this.treeData.SelectedNode.Text.ToString();
                }
                else
                {
                    MessageBox.Show("您已经选择了两个表操作，请清除所有或者删除一个表名后重新操作！");
                }
            }
        }

        private void btnAddColm_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeData.SelectedNode.Parent.Text == txtTableName.Text.ToString())
                {
                    if (listTableCol.FindString(treeData.SelectedNode.Text.ToString(), -1) == ListBox.NoMatches)
                    {
                        listTableCol.Items.Add(treeData.SelectedNode.Text.ToString());
                    }

                }
                if (treeData.SelectedNode.Parent.Text == txtTableName1.Text.ToString())
                {
                    if (listTableCol1.FindString(treeData.SelectedNode.Text.ToString(), -1) == ListBox.NoMatches)
                    {
                        listTableCol1.Items.Add(treeData.SelectedNode.Text.ToString());
                    }

                }
            }
            catch
            {
            }
        }

        private void btnClearTableCol_Click(object sender, EventArgs e)
        {
            listTableCol.Items.Remove(listTableCol.SelectedItem);
        }

        private void btnTableColJoin_Click(object sender, EventArgs e)
        {
            try
            {
                listTableColJoin.Text =listTableCol.Text;
            }
            catch
            {
            }
        }

        private void btnTableColWhere_Click(object sender, EventArgs e)
        {
            try
            {
                listTableColWhere.Items.Add(listTableCol.SelectedItem);
            }
            catch
            {
            }
        }

        private void btnClearTableCol1_Click(object sender, EventArgs e)
        {
            listTableCol1.Items.Remove(listTableCol1.SelectedItem);
        }

        private void btnTableCol1Join_Click(object sender, EventArgs e)
        {
            try
            {
                listTableColJoin1.Text = listTableCol1.Text;
            }
            catch
            {
            }
        }

        private void btnTableCol1Where_Click(object sender, EventArgs e)
        {
            try
            {
                listTableColWhere1.Items.Add(listTableCol1.SelectedItem);
            }
            catch
            {
            }
        }

         

        private void btnMoveWhere_Click(object sender, EventArgs e)
        {
            listTableColWhere.Items.Remove(listTableColWhere.SelectedItem);
        }

        private void btnMoveWhere1_Click(object sender, EventArgs e)
        {
            listTableColWhere1.Items.Remove(listTableColWhere1.SelectedItem);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (CheckSelect())
            {
                TextWriter FileSQLDAL = Console.Out;

                FileStream OutFile = new FileStream(strSelectTwoPath, FileMode.Create);

                StreamWriter objWriter = new StreamWriter(OutFile);
                Console.SetOut(objWriter);

                GetSelect();

                objWriter.Close();
                Console.SetOut(FileSQLDAL);
                OpenFile(strSelectTwoPath);
                MessageBox.Show("两表连查方法生成成功,可以到SetClass文件夹下查看SeletTwo.txt文件");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearAllCol_Click(object sender, EventArgs e)
        {
            txtTableName1.Text = "";
            txtTableName.Text = "";
            txtTableName1Sub.Text = "";
            txtTableNameSub.Text = "";
            listTableCol.Items.Clear();
            listTableCol1.Items.Clear();
            listTableColJoin.Text="";
            listTableColJoin1.Text="";
            listTableColWhere.Items.Clear();
            listTableColWhere1.Items.Clear();
            
        }

        private bool CheckSelect()
        {
            if (txtTableName.Text.ToString() == "")
            {
                MessageBox.Show("表1未设置！", "错误！");
                return false;
            }
            if (txtTableName1.Text.ToString() == "")
            {
                MessageBox.Show("表1未设置！", "错误！");
                return false;
            }
            if (listTableColJoin.Text.Trim()=="")
            {
                MessageBox.Show("连接字段未选择！", "错误！");
                return false;
            }
            if (listTableColJoin1.Text.Trim()=="" )
            {
                MessageBox.Show("连接字段未选择！", "错误！");
                return false;
            }
            if (listTableColWhere.Items.Count < 1 && listTableColWhere1.Items.Count < 1)
            {
                MessageBox.Show("查询条件未设置！", "错误！");
                return false;
            }
            if (cmbxJoin.Text.Trim() == "请选择")
            {
                MessageBox.Show("请设置两表连接方式！", "错误！");
                return false;
            }
            return true;
        }

        private void GetSelect()
        {
            string strTableSub = txtTableNameSub.Text.Trim() == "" ? txtTableName.Text.ToString().Replace("T_", "S_") : txtTableNameSub.Text.Trim();
            string strTableSub1 = txtTableName1Sub.Text.Trim() == "" ? txtTableName1.Text.ToString().Replace("T_", "S_") : txtTableName1Sub.Text.Trim();
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// 根据条件查询数据数据");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\"p_hasParameter\">");
            Console.WriteLine("/// 更新条件为:");
            int intp = 1;
            foreach (string strCol in listTableColWhere.Items)
            {
                Console.WriteLine("/// " + intp.ToString() + ": " + strCol.ToString());
                intp++;
            }
            foreach (string strCol1 in listTableColWhere1.Items)
            {
                Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString());
                intp++;
            }

            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>返回查询数据</returns>");


            Console.WriteLine("    public  DataTable   GetInfo (Hashtable p_hasParameter) ");
            Console.WriteLine("    {");

            Console.WriteLine("	string strSQL =\"\";");
            //*****************************************************************查询语句
            string strWhere = "";
            string strSelect = "";
            string strJoin = "";

            foreach (string strCol1 in listTableColWhere.Items)
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                    strWhere += strTableSub + "." + strCol1 + "=:" + strCol1;
                }
                else
                {
                    strWhere += strTableSub + "." + strCol1 + "=:" + strCol1;
                }
            }

            foreach (string strCol1 in listTableColWhere1.Items)
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                    strWhere += strTableSub1 + "." + strCol1 + "=:" + strCol1;
                }
                else
                {
                    strWhere += strTableSub1 + "." + strCol1 + "=:" + strCol1;
                }
            }
            //***************************
            foreach (string strCol1 in listTableCol.Items)
            {
                if (strSelect != "")
                {
                    strSelect += " ,";
                    strSelect += strTableSub + "." + strCol1;
                }
                else
                {
                    strSelect += strTableSub + "." + strCol1;
                }
            }

            foreach (string strCol1 in listTableCol1.Items)
            {
                if (strSelect != "")
                {
                    strSelect += " ,";
                    strSelect += strTableSub1 + "." + strCol1;
                }
                else
                {
                    strSelect += strTableSub1 + "." + strCol1;
                }
            }

            if (cmbxJoin.Text.Trim() == "内连")
            {
                strJoin = strTableSub + "." + listTableColJoin.Text.Trim() + "=" + strTableSub1 + "." + listTableColJoin1.Text.Trim();
            }
            if (cmbxJoin.Text.Trim() == "右连")
            {
                strJoin = strTableSub + "." + listTableColJoin.Text.Trim() + "=" + strTableSub1 + "." + listTableColJoin1.Text.Trim()+"(+)";

            }
            if (cmbxJoin.Text.Trim() == "左连")
            {
                strJoin = strTableSub + "." + listTableColJoin.Text.Trim() + "(+)=" + strTableSub1 + "." + listTableColJoin1.Text.Trim();

            }
            Console.WriteLine("	strSQL =\"select  " + strSelect + " from " + txtTableName.Text.ToString().Replace("T_", "S_") + " " + txtTableNameSub.Text.Trim() + "," + txtTableName1.Text.ToString().Replace("T_", "S_") + " " + txtTableName1Sub.Text.Trim() + " where   " + strJoin + " and " + strWhere + "\";");
            intp = intp - 1;
            Console.WriteLine("OracleParameter[] objParameter = new OracleParameter[" + intp + "];");
            Console.WriteLine(" ");
            int i = 0;
            //更新字段
            foreach (string strCol1 in listTableColWhere.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS ColName,DATA_TYPE AS Type,Data_LENGTH AS Length ,Data_Precision as NumberLength ,NULLABLE as IsNull FROM all_tab_columns  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "' and owner='" + GetOwer() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();
                foreach (DataRow dr in dtbModule.Rows)
                {

                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);

                    Console.WriteLine(" objParameter[" + i + "] = new OracleParameter(\":" + strCol1.ToString() + "\", System.Data.OracleClient.OracleType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine(" objParameter[" + i + "].Value = p_hasParameter[\"" + strCol1.ToString() + "\"];");
                    Console.WriteLine(" ");
                }
                i++;
            }
            //条件字段
            foreach (string strCol1 in listTableColWhere1.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS ColName,DATA_TYPE AS Type,Data_LENGTH AS Length ,Data_Precision as NumberLength ,NULLABLE as IsNull FROM all_tab_columns  WHERE TABLE_NAME = '" + txtTableName1.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "' and owner='" + GetOwer() + "'";
                objAccess.IsSP = false;
                DataTable dtbModule = objAccess.getDataSet();

                foreach (DataRow dr in dtbModule.Rows)
                {
                    string strIn = "";
                    string strLength = "";
                    string strOutType = "";
                    string strOutSqlType = "";
                    string strOutValue = "";
                    GetColInfo(dr["ColName"].ToString(), dr["Type"].ToString(), dr["Length"].ToString(), dr["NumberLength"].ToString(), out strIn, out strLength, out strOutType, out strOutSqlType, out strOutValue);

                    Console.WriteLine(" objParameter[" + i + "] = new OracleParameter(\":" + strCol1.ToString() + "\", System.Data.OracleClient.OracleType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine(" objParameter[" + i + "].Value = p_hasParameter[\"" + strCol1.ToString() + "\"];");
                    Console.WriteLine(" ");
                }
                i++;
            }

            Console.WriteLine("	return this.ExecuteReadTable(strSQL, objParameter);");
            Console.WriteLine("   } ");
            Console.WriteLine("    ");
        }


        #region"数据类型处理"
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
        private void GetColInfo(string strColName, string strType, string strInLength, string strNumberLength, out string strOut, out string strOutLength, out string stroutType, out string strOutSqlType, out string strOutValue)
        {

            strOut = "";
            strOutLength = "";
            stroutType = "";
            strOutSqlType = "";
            strOutValue = "";

            switch (strType.ToLower())
            {
                case "float":
                    strOutLength = "8";
                    strOut = "flt" + strColName;
                    stroutType = "float";
                    strOutSqlType = "Float";
                    strOutValue = "=float.MinValue";
                    break;
                case "date":
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
                case "number":
                    strOutLength = strNumberLength;
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
                case "varchar2":
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
        #endregion
       
    }
}