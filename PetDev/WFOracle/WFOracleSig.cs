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
    public partial class WFOracleSig : Form
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
        #endregion

        #region"构造函数"
        public WFOracleSig()
        {
            InitializeComponent();
        }
        #endregion

        #region"加载数据"
        private void WFOracleSig_Load(object sender, EventArgs e)
        {
            strPath = GetPath();
            strSysSetPath = strPath + "SetXML//DB.xml";
            strSelectPath = strPath + "SetClass//Select.txt";
            strUpdatePath = strPath + "SetClass//Update.txt";
            strDeletePath = strPath + "SetClass//Delete.txt";
            strInsertPath = strPath + "SetClass//Insert.txt";
            strBLLPath = strPath + "SetClass//BLL.txt";
            strWebPath = strPath + "SetClass//Web.txt";

            string strDBOwner = GetOwer();
            DataTable dtTableName = new DataTable();

            objAccess.strSql = "select name from sysobjects where xtype='U' ORDER BY name";
            objAccess.IsSP = false;
            objAccess.SqlParams = null;
            dtTableName = objAccess.getDataSet();
            treeData.Nodes.Clear();
            FillTree(dtTableName);

            GetData();
        }
        /// <summary>
        /// 获取表的所有者
        /// </summary>
        /// <returns></returns>
        private string GetOwer()
        {
            string strDBOwner = "";
            string strPath = GetPath();
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
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + dr["name"].ToString() + "' ";
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
        #endregion

        #region"页面操作事件"
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        /// <summary>
        /// 添加全部表字段信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
            catch
            {
            }
        }

        /// <summary>
        /// 添加表名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTableName_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTableName.Text == "")
                {
                    txtTableName.Text = this.treeData.SelectedNode.Text.ToString();
                }

            }
            catch
            {

            }
        }

        /// <summary>
        /// 添加选择字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
            catch
            {
            }
        }

        /// <summary>
        /// 清除所有设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAllCol_Click(object sender, EventArgs e)
        {
            listTableCol.Items.Clear();
            listTableColWhere.Items.Clear();
            txtTableName.Text = "";
            txtCSMorSQLDAL.Text = "";
        }

        /// <summary>
        /// 添加查询更新删除条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddWhereCol_Click(object sender, EventArgs e)
        {
            try
            {
                //listTableCol.Items.Remove(listTableColWhere.Text.ToString());
                listTableColWhere.Items.Add(listTableCol.SelectedItem);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 删除查询,更新,插入列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearTableCol_Click(object sender, EventArgs e)
        {
            listTableCol.Items.Remove(listTableCol.SelectedItem);
        }
        /// <summary>
        /// 删除查询,更新,删除条件列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearTableWhereCol_Click(object sender, EventArgs e)
        {
            listTableColWhere.Items.Remove(listTableColWhere.SelectedItem);
        }


        /// <summary>
        /// 查询函数的生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            if (CheckSelect())
            {
                TextWriter tmp = Console.Out;

                FileStream OutFile = new FileStream(strSelectPath, FileMode.Create);

                StreamWriter objWriter = new StreamWriter(OutFile);
                Console.SetOut(objWriter);
                //生成模板		  									  
                GetSelect();
                objWriter.Close();
                Console.SetOut(tmp);
                OpenFile(strSelectPath);
                MessageBox.Show("查询方法生成成功,可以到SetClass文件夹下查看Select.txt文件");
            }
           
        }

        /// <summary>
        /// 生成更新函数代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            if (CheckUpdate())
            {
                TextWriter FileSQLDAL = Console.Out;

                FileStream OutFile = new FileStream(strUpdatePath, FileMode.Create);

                StreamWriter objWriter = new StreamWriter(OutFile);
                Console.SetOut(objWriter);

                GetUpdate();

                objWriter.Close();
                Console.SetOut(FileSQLDAL);
                OpenFile(strUpdatePath);
                MessageBox.Show("更新方法生成成功,可以到SetClass文件夹下查看Update.txt文件");
            }
            else
            {

            }
        }

        /// <summary>
        /// 生成删除函数代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            if (CheckInsert())
            {
                TextWriter FileSQLDAL = Console.Out;

                FileStream OutFile = new FileStream(strDeletePath, FileMode.Create);

                StreamWriter objWriter = new StreamWriter(OutFile);
                Console.SetOut(objWriter);


                GetDelete();

                objWriter.Close();
                Console.SetOut(FileSQLDAL);
                OpenFile(strDeletePath);
                MessageBox.Show("删除方法生成成功,可以到SetClass文件夹下查看Delete.txt文件");
            }
        }

        /// <summary>
        /// 生成插入函数代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            if (CheckInsert())
            {
                SaveSetStruct();
                TextWriter FileSQLDAL = Console.Out;

                FileStream OutFile = new FileStream(strInsertPath, FileMode.Create);

                StreamWriter objWriter = new StreamWriter(OutFile);
                Console.SetOut(objWriter);


                GetInsert();

                objWriter.Close();
                Console.SetOut(FileSQLDAL);
                OpenFile(strInsertPath);
                MessageBox.Show("插入方法生成成功,可以到SetClass文件夹下查看Insert.txt文件");
            }
        }

        /// <summary>
        /// 生成BLL类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBLL_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            
            string strDBOwner = GetOwer();
            TextWriter tmp = Console.Out;
            FileStream OutFile = new FileStream(strBLLPath, FileMode.Create);
            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);
            GetBLLClass();
            objWriter.Close();
            Console.SetOut(tmp);
            OpenFile(strBLLPath);
            MessageBox.Show("BLL类生成成功,可以到SetClass文件夹下查看BLL.txt文件");

        }

        /// <summary>
        /// 生成Web页面传入参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWeb_Click(object sender, EventArgs e)
        {
            SaveSetStruct();
            TextWriter FileSQLDAL = Console.Out;

            FileStream OutFile = new FileStream(strWebPath, FileMode.Create);

            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);

            GetWeb();

            objWriter.Close();
            Console.SetOut(FileSQLDAL);
            OpenFile(strWebPath);
        }

        #endregion

        #region"生成调用方法代码函数"
        /// <summary>
        /// 生成select 查询函数方法
        /// </summary>
        private void GetSelect()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// 作者:     ***");
            Console.WriteLine("/// 创建时间: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("/// 功能描述: 根据条件获取查询数据");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\"p_hasWhere\">");
            Console.WriteLine("/// 查询条件HashTable的Key为:");
            int intp = 1;
            foreach (string strCol1 in listTableColWhere.Items)
            {
                Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString());
                intp++;
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>返回查询结果结合</returns>");

            Console.WriteLine("public DataTable Get" + txtTableName.Text.ToString().Replace("T_", "") + "Info(Hashtable p_hasWhere)");
            Console.WriteLine("{");
            Console.WriteLine("	string strSQL =\"\";");
            //*****************************************************************查询语句
            string strSelect = "";
            string strWhere = "";

            foreach (string strCol1 in listTableCol.Items)
            {
                if (strSelect != "")
                {
                    strSelect += ",";
                    strSelect += strCol1;
                }
                else
                {
                    strSelect += strCol1;
                }
            }

            foreach (string strCol1 in listTableColWhere.Items)
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                    strWhere += strCol1 + "=:" + strCol1;
                }
                else
                {
                    strWhere += strCol1 + "=:" + strCol1;
                }
            }

            Console.WriteLine("	strSQL =\"select " + strSelect + "  from " + txtTableName.Text.ToString().Replace("T_", "S_") + " where " + strWhere + "\";");
            int intCount = listTableColWhere.Items.Count;
            int i = 0;
            Console.WriteLine("OracleParameter[] objParameter = new OracleParameter[" + intCount.ToString() + "];");
            Console.WriteLine("");
            foreach (string strCol1 in listTableColWhere.Items)
            {

                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
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
                    Console.WriteLine(" objParameter[" + i + "].Value = p_hasWhere[\"" + strCol1.ToString() + "\"];");
                    Console.WriteLine("");
                }
                i++;
            }

            Console.WriteLine("	return this.ExecuteReadTable(strSQL, objParameter);");
            Console.WriteLine("}");
        }

        /// <summary>
        /// update更新数据
        /// </summary>
        private void GetUpdate()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// 作者:     ***");
            Console.WriteLine("/// 创建时间: "+DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("/// 功能描述: 根据条件更新表数据");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\"p_hasParameter\">");
            Console.WriteLine("/// 更新条件为:");
            int intp = 1;
            foreach (string strCol1 in listTableColWhere.Items)
            {
                Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString());
                intp++;
            }
            Console.WriteLine("/// 更新字段为:");
            intp = 1;
            foreach (string strCol1 in listTableCol.Items)
            {
                Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString());
                intp++;
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>返回影响行数</returns>");


            Console.WriteLine("    public  int   Update" + txtTableName.Text.ToString().Replace("T_", "") + " (Hashtable p_hasParameter) ");
            Console.WriteLine("    {");

            Console.WriteLine("	string strSQL =\"\";");
            //*****************************************************************查询语句

            string strUpdateValue = "";
            string strWhere = "";
            int intCount = 0;
            intCount = listTableCol.Items.Count;
            int intParmas = intCount + listTableColWhere.Items.Count;
            foreach (string strCol1 in listTableCol.Items)
            {
                if (strUpdateValue != "")
                {
                    strUpdateValue += ",";
                    strUpdateValue += strCol1 + "=:" + strCol1;
                }
                else
                {
                    strUpdateValue += strCol1 + "=:" + strCol1;
                }
            }

            foreach (string strCol1 in listTableColWhere.Items)
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                    strWhere += strCol1 + "=:" + strCol1;
                }
                else
                {
                    strWhere += strCol1 + "=:" + strCol1;
                }
            }


            Console.WriteLine("	strSQL =\"update  " + txtTableName.Text.ToString().Replace("T_", "S_") + " set  " + strUpdateValue + "    where " + strWhere + "\";");
            Console.WriteLine("OracleParameter[] objParameter = new OracleParameter[" + intParmas + "];");
            Console.WriteLine(" ");

            Console.WriteLine("    ");

            int i = 0;
            //更新字段
            foreach (string strCol1 in listTableCol.Items)
            {
                objAccess.strSql = "SELECT COLUMN_NAME AS [ColName],DATA_TYPE AS [Type],CHARACTER_MAXIMUM_LENGTH AS [Length] ,IS_NULLABLE as [IsNull] , COLUMN_DEFAULT as [DefaultValue] FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1.ToString() + "'";
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

            Console.WriteLine("	return this.ExecuteSQL(strSQL, objParameter);");
            Console.WriteLine("    }");

        }

        /// <summary>
        /// 生成delete 删除函数方法
        /// </summary>
        private void GetDelete()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// 作者:     ***");
            Console.WriteLine("/// 创建时间: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("/// 功能描述: 根据条件删除");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\"p_objWhere\">");
            Console.WriteLine("/// 条件参数为:");
            int intp = 1;
            foreach (string strCol1 in listTableColWhere.Items)
            {
                Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString());
                intp++;
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>返回影响行数</returns>");
            Console.WriteLine("public int  Delete" + txtTableName.Text.ToString().Replace("T_", "") + "Info(Hashtable p_objWhere)");
            Console.WriteLine("{");
            Console.WriteLine("	string strSQL =\"\";");
            //*****************************************************************
            string strWhere = "";

            foreach (string strCol1 in listTableColWhere.Items)
            {
                if (strWhere != "")
                {
                    strWhere += " and ";
                    strWhere += strCol1 + "=:" + strCol1;
                }
                else
                {
                    strWhere += strCol1 + "=:" + strCol1;
                }
            }

            Console.WriteLine("	strSQL =\"delete     from " + txtTableName.Text.ToString().Replace("T_", "S_") + " where " + strWhere + "\";");
            int intCount = listTableColWhere.Items.Count;
            int i = 0;
            Console.WriteLine("OracleParameter[] objParmas = new OracleParameter[" + intCount.ToString() + "];");

            foreach (string strCol1 in listTableColWhere.Items)
            {

                objAccess.strSql = "SELECT COLUMN_NAME AS ColName,DATA_TYPE AS Type,Data_LENGTH AS Length ,Data_Precision as NumberLength ,NULLABLE as IsNull FROM all_tab_columns  WHERE TABLE_NAME = '" + txtTableName.Text.ToString() + "' and COLUMN_NAME='" + strCol1 + "' and owner='" + GetOwer() + "'";
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

                    Console.WriteLine(" objParmas[" + i + "] = new OracleParameter(\":" + strCol1.ToString() + "\", System.Data.OracleClient.OracleType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine(" objParmas[" + i + "].Value = p_objWhere[\"" + strCol1.ToString() + "\"];");
                    Console.WriteLine(" ");
                }
                i++;
            }

            Console.WriteLine("	return this.ExecuteSQL(strSQL, objParmas);");
            Console.WriteLine("}");
        }

        /// <summary>
        /// insert  插入数据
        /// </summary>
        private void GetInsert()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// 作者:     ***");
            Console.WriteLine("/// 创建时间: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("/// 功能描述: 插入表数据");
            Console.WriteLine("/// </summary>");
            Console.WriteLine("/// <param name=\"p_hasParameter\">");
            Console.WriteLine("/// 插入列为:");
            int intp = 1;
            foreach (string strCol1 in listTableCol.Items)
            {
                Console.WriteLine("/// " + intp.ToString() + ": " + strCol1.ToString());
                intp++;
            }
            Console.WriteLine("/// </param>");
            Console.WriteLine("/// <returns>返回影响行数</returns>");

            Console.WriteLine("    public  int   Insert" + txtTableName.Text.ToString().Replace("T_", "") + " (Hashtable p_hasParameter) ");
            Console.WriteLine("    {");

            Console.WriteLine("	string strSQL =\"\";");

            #region"不固定列插入的生成"
            //***********************************
            /*
            Console.WriteLine("	OracleParameter SPNewParm = null;");
            Console.WriteLine("	ArrayList listParam = new ArrayList();");
            Console.WriteLine("	OracleParameter[] objParameter;");
            Console.WriteLine("	string strCol = \"\";");
            Console.WriteLine("	string strColValue = \"\";");

            foreach (string strCol1 in listTableCol.Items)
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

                    Console.WriteLine("if (p_hasParameter[\"" + dr["ColName"].ToString() + "\"] != null)");
                    Console.WriteLine("{");
                    Console.WriteLine("	SPNewParm = new OracleParameter(\"" + dr["ColName"].ToString() + "\", System.Data.OracleClient.OracleType." + GetOracleType(dr["Type"].ToString()) + " , " + strLength + ");");
                    Console.WriteLine("	SPNewParm.Value =p_hasParameter[\"" + strCol1.ToString() + "\"];");
                    Console.WriteLine("	listParam.Add(SPNewParm);");
                    Console.WriteLine("	if (strCol != \"\")");
                    Console.WriteLine("	{");
                    Console.WriteLine("		strCol += \" ,\";");
                    Console.WriteLine("	}");
                    Console.WriteLine("	else");
                    Console.WriteLine("	{");
                    Console.WriteLine("		strCol += \"" + dr["ColName"].ToString() + "\";");
                    Console.WriteLine("	}");

                    Console.WriteLine("	if (strColValue != \"\")");
                    Console.WriteLine("	{");
                    Console.WriteLine("		strColValue += \" ,\";");
                    Console.WriteLine("		strColValue +=\":\"+\"" + dr["ColName"].ToString() + "\";");
                    Console.WriteLine("	}");
                    Console.WriteLine("	else");
                    Console.WriteLine("	{");
                    Console.WriteLine("		strColValue +=\":\"+\"" + dr["ColName"].ToString() + "\";");
                    Console.WriteLine("	}");
                    Console.WriteLine("}");
                    Console.WriteLine(" ");
                }
             

            }
            Console.WriteLine("	strSQL =\"insert into   " + txtTableName.Text.ToString().Replace("T_", "S_") + " (  \"+ strCol +\" ) values ( \"+strColValue+\")\";");

            Console.WriteLine("	objParameter = (OracleParameter[])listParam.ToArray(typeof(OracleParameter));");

            Console.WriteLine("	return this.ExecuteSQL(strSQL, objParameter);");
            Console.WriteLine("    }");
             */
            #endregion

            #region"固定插入列生成"
            string strInsertValue = "";
            string strInserCol = "";
            int intCount = 0;
            intCount = listTableCol.Items.Count;
            int intParmas = intCount + 1;
            foreach (string strCol1 in listTableCol.Items)
            {
                if (strInsertValue != "")
                {
                    strInsertValue += ",";
                    strInsertValue += ":" + strCol1;
                }
                else
                {
                    strInsertValue += ":" + strCol1;
                }
                if (strInserCol != "")
                {
                    strInserCol += ",";
                    strInserCol += strCol1;
                }
                else
                {
                    strInserCol += strCol1;
                }
            }

            Console.WriteLine("	strSQL =\"insert into   " + txtTableName.Text.ToString().Replace("T_", "S_") + " (  " + strInserCol + " ) values ( " + strInsertValue + ")\";");
            Console.WriteLine("OracleParameter[] objParameter = new OracleParameter[" + intCount + "];");
            Console.WriteLine("    ");
            int i = 0;
            //更新字段
            foreach (string strCol1 in listTableCol.Items)
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

            Console.WriteLine("	return this.ExecuteSQL(strSQL, objParameter);");
            Console.WriteLine("    }");
            #endregion

        }

        /// <summary>
        /// 把生成的方法构造成类
        /// </summary>
        private void GetBLLClass()
        {
            Console.WriteLine("using System;");
            Console.WriteLine("using System.Text;");
            Console.WriteLine("using System.Data;");
            Console.WriteLine("using System.Collections;");
            Console.WriteLine("using System.Data.OracleClient;");
            Console.WriteLine("namespace " + txtBLLNameSpace.Text.ToString());
            Console.WriteLine("{");
            Console.WriteLine("	///<summary>");
            //Console.WriteLine("	/// *******************************************************************************************************");
            Console.WriteLine("	/// 创建者:     ***");
            Console.WriteLine("	/// 创建时间:   " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("	/// 修改者:     ***");
            Console.WriteLine("	/// 修改时间:   0000-00-00");
            Console.WriteLine("	/// 修改内容:   ");
            Console.WriteLine("	/// 类功能描述: ");
           // Console.WriteLine("	/// *******************************************************************************************************");
            Console.WriteLine("	///</summary>");
            Console.WriteLine("    public class " + txtBLLClassName.Text.ToString() + " :FinNet.DBModules.BLLOracleBase ");
            Console.WriteLine("      {");
            Console.WriteLine("	///<summary>");
            Console.WriteLine("	/// 构造函数 ");
            Console.WriteLine("	///</summary>");
            Console.WriteLine("public " + txtBLLClassName.Text.ToString() + "()");
            Console.WriteLine("{");
            Console.WriteLine("	//");
            Console.WriteLine("	// 在此处添加构造函数逻辑");
            Console.WriteLine("	//");
            Console.WriteLine("}");

            TextWriter stringWriter = new StringWriter();
            TextReader stringReader =
                new StringReader(stringWriter.ToString());
            //查询文件载入**************************************************************************
            if (cbxSelect.Checked == true)
            {
                using (TextReader streamReader =
                          new StreamReader(strSelectPath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            //插入文件载入**************************************************************************
            if (cbxInsert.Checked == true)
            {
                using (TextReader streamReader =
                          new StreamReader(strInsertPath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            //更新文件载入**************************************************************************
            if (cbxUpdate.Checked == true)
            {
                using (TextReader streamReader =
                          new StreamReader(strUpdatePath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            //删除文件载入**************************************************************************
            if (cbxDelete.Checked == true)
            {
                using (TextReader streamReader =
                          new StreamReader(strDeletePath))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            Console.WriteLine("}");
            Console.WriteLine("}");

        }

        /// <summary>
        /// 生成select 查询函数方法
        /// </summary>
        private void GetWeb()
        {
            Console.WriteLine("/// <summary>");
            Console.WriteLine("/// 生成Hastable");
            Console.WriteLine("/// </summary>");

            Console.WriteLine("public HashMap Get" + txtTableName.Text.ToString().Replace("T_","") + "Info()");
            Console.WriteLine("{");

            //*****************************************************************查询语句
            Console.WriteLine(" Hashtale objHas = new Hashtale();");
            foreach (string strCol1 in listTableCol.Items)
            {
                Console.WriteLine("objHas.Add(\"" + strCol1 + "\", txt" + strCol1 + ".Text);");
            }
            Console.WriteLine(" return objHas;");
            Console.WriteLine("}");
        }
        #endregion

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

        #region"检查数据合法性"
        private bool CheckSelect()
        {
            if (txtTableName.Text.ToString() == "")
            {
                MessageBox.Show("更新表未设置！", "错误！");
                return false;
            }
            if (listTableCol.Items.Count < 1)
            {
                MessageBox.Show("查询字段未选择！", "错误！");
                return false;
            }
            if (listTableColWhere.Items.Count < 1)
            {
                MessageBox.Show("查询条件字段未选择！", "错误！");
                return false;
            }
            return true;
        }

        private bool CheckInsert()
        {
            if (txtTableName.Text.ToString() == "")
            {
                MessageBox.Show("插入表未设置！", "错误！");
                return false;
            }
            if (listTableCol.Items.Count < 1)
            {
                MessageBox.Show("插入字段未选择！", "错误！");
                return false;
            }
             
            return true;
        }

        private bool CheckDelete()
        {
         
            if (listTableColWhere.Items.Count < 1)
            {
                MessageBox.Show("删除条件字段未选择！", "错误！");
                return false;
            }
            return true;
        }

        private bool CheckUpdate()
        {
            if (txtTableName.Text.ToString() == "")
            {
                MessageBox.Show("更新表未设置！", "错误！");
                return false;
            }
            if (listTableCol.Items.Count < 1)
            {
                MessageBox.Show("更新字段未选择！", "错误！");
                return false;
            }
            if (listTableColWhere.Items.Count < 1)
            {
                MessageBox.Show("更新条件字段未选择！", "错误！");
                return false;
            }
            return true;
        }
        #endregion
       
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
        /// 保存生成类的设置
        /// </summary>
        /// <param name="A_strTableName"></param>
        private void SaveSetStruct()
        {
            string strPath = GetPath();
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strSysSetPath);
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node2 in node.ChildNodes)
            {
                switch (node2.Name.ToString())
                {
                    case "strSQLBLLName":
                        node2.InnerText = txtBLLClassName.Text.ToString();
                        break;
                    case "strSQLBLLNameSP":
                        node2.InnerText = txtBLLNameSpace.Text.ToString();
                        break;
                    default:
                        break;
                }
            }
            myXmlDocument.Save(strSysSetPath);
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

        /// <summary>
        /// 得到生成类的设置
        /// </summary>
        private void GetData()
        {

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strSysSetPath);
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node2 in node.ChildNodes)
            {
                switch (node2.Name.ToString())
                {
                    case "strSQLBLLName":
                        txtBLLClassName.Text = node2.InnerText.ToString();
                        break;
                    case "strSQLBLLNameSP":
                        txtBLLNameSpace.Text = node2.InnerText.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

    }
}