using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Text.RegularExpressions;

namespace PetDev
{
    public partial class WFOracleDBSet : Form
    {
        public WFOracleDBSet()
        {
            InitializeComponent();
        }

        private string strDBPath = "";
        private string strDBErrorPath = "";
        private string strSysSetPath = "";
        private string strPath = "";
        private string strSQLPath = "";
        private string strOraclePath = "";
        private string strOracleDataPath = "";

        private void WFDBSet_Load(object sender, EventArgs e)
        {
            strPath = GetPath();
            strSysSetPath = strPath + "SetXML//DB.xml";
            strSQLPath = strPath + "DBFile//Oracle//SQL.TXT";
            strOraclePath = strPath + "DBFile//Oracle//OracleSQL.TXT";

            strOracleDataPath = strPath + "DBFile//Oracle//OracleData.TXT";
            strDBErrorPath = strPath + "DBFile//Oracle//DBError.TXT";
            strDBPath = GetDbPath();
            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//打开一个Excel应用
            if (app == null)
            {
                return;
            }
            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//打开一个现有的工作薄Environment.CurrentDirectory + "\\SQL.xls"
            Sheets shs = wb.Sheets;
            _Worksheet sh = (_Worksheet)wb.Sheets["DBSet"];  // (_Worksheet)shs.//.get_Item(1);//选择第一个Sheet页
            if (sh == null)
            {
                return;
            }
            try
            {
                for (int i = 3; i <= sh.UsedRange.Rows.Count; i++)
                {
                    Range r = sh.get_Range("B" + i.ToString(), System.Reflection.Missing.Value);
                    Range V = sh.get_Range("C" + i.ToString(), System.Reflection.Missing.Value);
                    Range D = sh.get_Range("D" + i.ToString(), System.Reflection.Missing.Value);
                    cbxTable.Items.Add(System.Convert.ToString(r.Value2).Trim() + "," + System.Convert.ToString(V.Value2).Trim() + "," + System.Convert.ToString(D.Value2).Trim());
                }
            }

            catch
            {

            }
            finally
            {
                //杀掉EXCEL进程
                wb.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                wb = null;
                app = null;
                GC.Collect();
            }
        }

        private string GetDbPath()
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
                    case "strORACLEDBPath":
                        strDBOwner = node2.InnerText.ToString();
                        break;
                    default:
                        break;
                }
            }

            return strDBOwner;
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
            for (int i = 0; i < cbxTable.Items.Count; i++)
            {
                cbxTable.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cbxTable.Items.Count; i++)
            {
                cbxTable.SetItemChecked(i, false);
            }
        }

        private void SetOracleTable(_Worksheet objSheet)
        {
           

            string strValue, strTableName, strColumnName, strCName, strColumnType, strLength, strIsNull, strDefaultValue, strIsPK, strMemo;
            strValue = "";
            string strIndexValue="";
            //获取表名称
            Range TableName = objSheet.get_Range("B1", System.Reflection.Missing.Value);
            string strOwner = "EHRDAT1";
            Range TableSpace = objSheet.get_Range("D1", System.Reflection.Missing.Value);
            string strTableSpace = "";
            strTableSpace = System.Convert.ToString(TableSpace.Value2).Trim();
            strTableName = System.Convert.ToString(TableName.Value2).Trim();
            string strUserName=txtLogInName.Text.Trim();
            //******************************************************************************
            Console.WriteLine("/*****以下是创建表[" + strTableName + "]SQL脚本****************************/\r\n");
            Console.Write("/*删除现有表*/\r\n");
            Console.WriteLine("/*drop table fnd.T_" + strTableName + ";*/");
            Console.Write("/*创建表结构*/\r\n");
            Console.WriteLine("CREATE TABLE fnd.T_" + strTableName + "\r\n(");
            //**************************************************************************************8888
            for (int i = 4; i <= objSheet.UsedRange.Rows.Count; i++)
            {

                //获取字段名
                Range Column = objSheet.get_Range("B" + i.ToString(), System.Reflection.Missing.Value);
                strColumnName = System.Convert.ToString(Column.Value2).Trim();
                //获取字段中文名称
                Range CName = objSheet.get_Range("C" + i.ToString(), System.Reflection.Missing.Value);
                strCName = System.Convert.ToString(CName.Value2).Trim();
                //获取字段类型
                Range Type = objSheet.get_Range("D" + i.ToString(), System.Reflection.Missing.Value);
                strColumnType = System.Convert.ToString(Type.Value2).Trim();
                //获取字段长度
                Range Length = objSheet.get_Range("E" + i.ToString(), System.Reflection.Missing.Value);
                strLength = System.Convert.ToString(Length.Value2).Trim();
                //获取字段长度
                Range IsNULL = objSheet.get_Range("F" + i.ToString(), System.Reflection.Missing.Value);
                strIsNull = System.Convert.ToString(IsNULL.Value2).Trim();
                if (strIsNull != "")
                {
                    strIsNull = "  NOT NULL";
                }
                //获取字段默认值
                Range Default = objSheet.get_Range("G" + i.ToString(), System.Reflection.Missing.Value);
                strDefaultValue = System.Convert.ToString(Default.Value2).Trim();
                if (strDefaultValue != "")
                {
                    if (strDefaultValue.ToLower() == "date")
                    {
                        strDefaultValue = " Default " + strDefaultValue ;
                    }
                    else
                    {
                        strDefaultValue = " Default '" + strDefaultValue + "'";
                    }
                }
                //获取主键
                Range IsPK = objSheet.get_Range("H" + i.ToString(), System.Reflection.Missing.Value);
                strIsPK = System.Convert.ToString(IsPK.Value2).Trim();
                if (strIsPK.ToUpper() != "")
                {
                    strIndexValue = "CREATE INDEX  fnd.I_" + strIsPK + " ON  fnd.T_" + strTableName + "(" + strColumnName + ") TABLESPACE IDX_FINNET;\r\n";
                    strIndexValue += "ALTER TABLE fnd.T_" + strTableName + " ADD PRIMARY KEY(" + strColumnName + ");\r\n";
                }
                //获取说明
                Range Memo = objSheet.get_Range("I" + i.ToString(), System.Reflection.Missing.Value);
                strMemo = System.Convert.ToString(Memo.Value2).Trim();
                if (i == objSheet.UsedRange.Rows.Count)
                {
                    switch (strColumnType.ToLower())
                    {
                        case "varchar2":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue + strIsNull + " /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "number":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue.Replace("'","") + strIsNull + " /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "date":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "  " + strDefaultValue + strIsNull + " /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "clob":
                            Console.WriteLine(" " + strColumnName + "  " + strColumnType + "   /*" + strCName + ":" + strMemo + " */");
                            break;
                        default:
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue + strIsNull + " /*" + strCName + ":" + strMemo + " */");
                            break;
                    }
                }
                else
                {
                    switch (strColumnType.ToLower())
                    {
                        case "varchar2":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue + strIsNull + ",  /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "number":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue.Replace("'", "") + strIsNull + ",  /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "date":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "   " + strDefaultValue + strIsNull + ",  /*" + strCName + ":" + strMemo + " */");
                            break;
                        case "clob":
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "  ,   /*" + strCName + ":" + strMemo + " */");
                            break;
                        default:
                            Console.WriteLine(" " + strColumnName + " " + strColumnType + "(" + strLength + ") " + strDefaultValue + strIsNull + ",  /*" + strCName + ":" + strMemo + " */");
                            break;
                    }
                }

                strValue += "COMMENT ON COLUMN  fnd.T_" + strTableName + "." + strColumnName + " IS " + "'" + strCName + ":" + strMemo + "';\r\n";
            }
            Console.Write(")\r\n");
            Console.Write("TABLESPACE " + strTableSpace + "; \r\n");
            Console.Write("/*创建表字段说明*/\r\n");
            Console.Write(strValue);
            Console.Write("/*创建表字段索引*/\r\n");
            Console.Write(strIndexValue);
            Console.Write("\r\n");
           
            Range SQIsPK = objSheet.get_Range("H4", System.Reflection.Missing.Value);
            strIsPK = System.Convert.ToString(SQIsPK.Value2).Trim();
            if (strIsPK.ToUpper() != "")
            {
                Console.Write("/*创建表上需要使用到的SEQUENCE*/\r\n");
                Console.Write("CREATE SEQUENCE fnd.Q_" + strTableName + "ID START WITH 1 INCREMENT BY 1 NOCYCLE NOMAXVALUE; \r\n");
                Console.Write("CREATE PUBLIC SYNONYM SEQ_" + strTableName + "ID FOR fnd.Q_" + strTableName + "ID; \r\n");
                Console.Write("/*给SEQUENCE查询权限*/\r\n");
                Console.Write("GRANT SELECT ON fnd.Q_" + strTableName + "ID to finnet;");
            }

            //Range ColumnSeq = objSheet.get_Range("B4", System.Reflection.Missing.Value);
            //string strColumnSeqName = System.Convert.ToString(ColumnSeq.Value2).Trim();
          
            Console.Write("/*给表创建笔名*/\r\n");
            Console.Write("CREATE PUBLIC SYNONYM S_" + strTableName + " for fnd.T_" + strTableName + "; \r\n");

           // Console.Write("Create synonym " + strUserName + ".S_"+strTableName+" for T_"+strTableName+";\r\n");
            Console.Write("/*给表创建用户的使用权限*/\r\n");
            Console.Write("GRANT SELECT,INSERT,UPDATE,DELETE ON fnd.T_" + strTableName + "  to finnet; ");

     
        }


         

        private void SetOracleTableData(_Worksheet objSheet,_Worksheet objtb)
        {
            //设置表的默认结构**************************************************************************************8888
            System.Data.DataTable dtbTable = new System.Data.DataTable();
            dtbTable.Columns.Add("CoName", typeof(string));
            dtbTable.Columns.Add("Length", typeof(string));
            dtbTable.Columns.Add("Type", typeof(string));

            string strValue, strColumnName, strCName, strColumnType, strLength, strIsNull, strDefaultValue, strIsPK, strMemo;
            strValue = "";
            string strIndexValue = "";

            for (int i = 4; i <= objtb.UsedRange.Rows.Count; i++)
            {

                //获取字段名
                Range Column = objtb.get_Range("B" + i.ToString(), System.Reflection.Missing.Value);
                strColumnName = System.Convert.ToString(Column.Value2).Trim().ToUpper();
                //获取字段类型
                Range Type = objtb.get_Range("D" + i.ToString(), System.Reflection.Missing.Value);
                strColumnType = System.Convert.ToString(Type.Value2).Trim().ToUpper();
                //获取字段长度
                Range Length = objtb.get_Range("E" + i.ToString(), System.Reflection.Missing.Value);
                strLength = System.Convert.ToString(Length.Value2).Trim();

                System.Data.DataRow dr= dtbTable.NewRow();
                dr["CoName"] = strColumnName;
                dr["Length"] = strLength;
                dr["Type"] = strColumnType;

                dtbTable.Rows.Add(dr);
            }
            //**************************************************************************************8888*********************

            string strTableName = "";
            string strCol = "";         //列名称
            string strColValue = "";    //列对应EXCEL中纵向位置
            string strMark = "";        //纵向位置标识
            strMark = "B";
            string strMarkA = "@";
            //获取表名称
            Range TableName = objSheet.get_Range("B1", System.Reflection.Missing.Value);
            strTableName = System.Convert.ToString(TableName.Value2).Trim();
            //******************************************************************************
            Console.WriteLine("--*****以下是插入表[" + strTableName + "]SQL脚本****************************");
            Console.WriteLine(" set define off ;");
            Console.WriteLine("delete from  T_" + strTableName + ";");
           
            //**************************************************************************************
            //###############组织列############################################################################################################
            int intAsciiCode = 0;
            for (int i = 2; i <= objSheet.UsedRange.Columns.Count; i++)
            {

                Range Column = objSheet.get_Range(strMark + "3", System.Reflection.Missing.Value);
                //判断表中的列在数据库中是否存在
                dtbTable.DefaultView.RowFilter = "CoName='" + System.Convert.ToString(Column.Value2).Trim().ToUpper() + "'";
                if (dtbTable.DefaultView.Count <= 0)
                {
                    MessageBox.Show("字段[ " + System.Convert.ToString(Column.Value2).Trim() + " ]在数据库中不存在！", "错误！");
                    return;

                }

                if (strCol != "")
                {
                    strCol += ",";
                    strCol += System.Convert.ToString(Column.Value2).Trim();
                }
                else
                {
                    strCol += System.Convert.ToString(Column.Value2).Trim();
                }
                if (strColValue != "")
                {
                    strColValue += ",";
                    strColValue += strMark;
                }
                else
                {
                    strColValue += strMark;
                }
                //strMark = Convert.tos strMark
                if (intAsciiCode < 90)
                {
                    ASCIIEncoding objEnCode = new ASCIIEncoding();
                    intAsciiCode = (int)objEnCode.GetBytes(strMark)[0];
                    intAsciiCode = intAsciiCode + 1;
                    byte[] byteArray = new byte[] { (byte)intAsciiCode };
                    strMark = objEnCode.GetString(byteArray);
                }
                else
                {
                    ASCIIEncoding objEnCode = new ASCIIEncoding();
                    int intAsciiCode1 = (int)objEnCode.GetBytes(strMarkA)[0];
                    intAsciiCode1 = intAsciiCode1 + 1;
                    byte[] byteArray = new byte[] { (byte)intAsciiCode1 };
                    strMarkA = objEnCode.GetString(byteArray);
                    strMark = "A" + strMarkA;
                }


            }
            //##################################################################################################################

            strMark = "B";
            for (int i = 4; i <= objSheet.UsedRange.Rows.Count; i++)
            {
                string strColType = "";
                string  strColLength ="";
                


                string strInsertValue = "";
                char[] carTwo = new char[] { ',' };
                string[] strColTwo;
                strColTwo = strColValue.Split(carTwo);
                for (int j = 0; j < strColTwo.Length; j++)
                {

                    //获取列名称
                    Range Column = objSheet.get_Range(strColTwo[j] + "3", System.Reflection.Missing.Value);
                    string strColName = System.Convert.ToString(Column.Value2).Trim().ToUpper();
                    dtbTable.DefaultView.RowFilter = "CoName='" + strColName + "'";
                    if (dtbTable.DefaultView.Count <= 0)
                    {
                        MessageBox.Show("字段[ " + strColName + " ]在数据库中不存在！", "错误！");
                        return;
                    }
                    else
                    {
                        strColType = dtbTable.DefaultView[0]["Type"].ToString().ToUpper();
                        strColLength = dtbTable.DefaultView[0]["Length"].ToString();
                    }



                    string strCurrentValue = "";
                    Range ColValue = objSheet.get_Range(strColTwo[j].ToString() + i.ToString(), System.Reflection.Missing.Value);
                    strCurrentValue = System.Convert.ToString(ColValue.Text).Trim();
                    if (strCurrentValue != "")
                    {
                        strCurrentValue=strCurrentValue.Replace("'", "''");
                        //判断是否长度长了
                        if (strColLength.Trim() != "" || strColType == "CLOB")
                        {
                            switch (strColType)
                            {
                                case "CLOB":
                                    if (strTableName.ToUpper() != "CP" && strTableName.ToUpper() != "T_CP")
                                    {
                                        strCurrentValue = strCurrentValue.Replace("\r\n", "<BR>");
                                        strCurrentValue = strCurrentValue.Replace("\n\n", "<BR>");
                                        strCurrentValue = strCurrentValue.Replace("\n", "<BR>");
                                    }
                                    if (CheckLength(strCurrentValue ,4000))
                                    {
                                        
                                        if (strTableName.ToUpper() == "T_CP" && strTableName.ToUpper() == "T_CP")
                                        {
                                            //strCurrentValue.Replace("\r\n", "<BR>");
                                        }
                                        //MessageBox.Show(i+"行字段[ " + strColName + " ]长度超过了4000！", "错误！");
                                        //return;
                                        if (CheckLength(strCurrentValue, 3950))
                                        {
                                            strCurrentValue = SubStr(strCurrentValue, 3950) + "...";
                                        }
                                    }
                                    break;
                                case "VARCHAR2":
                                    if ( CheckLength(strCurrentValue  , Convert.ToInt32(strColLength)))
                                    {
                                        MessageBox.Show( "EXCEL " +strColTwo[j]+i + " 字段[ " + strColName + " ]长度超过了" + strColLength + "！", "错误！");
                                        return;
                                    }
                                    break;
                                case "CHAR":
                                    if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                    {
                                        MessageBox.Show("EXCEL " + strColTwo[j] + i + " 字段[ " + strColName + " ]长度超过了" + strColLength + "！", "错误！");
                                        return;
                                    }
                                    break;
                                case "NUMBER":
                                    if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                    {
                                        MessageBox.Show("EXCEL " + strColTwo[j] + i + " 字段[ " + strColName + " ]长度超过了" + strColLength + "！", "错误！");
                                        return;
                                    }
                                    break;
                                case "DATE":
                                    if (CheckLength(strCurrentValue, 19))
                                    {
                                        MessageBox.Show("EXCEL " + strColTwo[j] + i + " 字段[ " + strColName + " ]长度超过了" + strColLength + "！", "错误！");
                                        return;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (strInsertValue != "")
                        {
                            strInsertValue += ",";
                            if (strCurrentValue.Trim().ToUpper() != "SEQ")
                            {
                                if (strColType == "DATE")
                                {
                                    if (strCurrentValue.Length > 10)
                                    {
                                        strInsertValue += "to_date('" + strCurrentValue + "',' yyyy-MM-dd hh24:mi:ss')";
                                    }
                                    else
                                    {
                                        strInsertValue += "to_date('" + strCurrentValue + "','yyyy-MM-dd')";
                                    }
                                }
                                else
                                {
                                    strInsertValue += "'" + strCurrentValue + "'";
                                }
                            }
                            else
                            {
                                strInsertValue += "SEQ_" + strTableName.ToUpper()+"ID.NEXTVAL";
                            }
                        }
                        else
                        {
                            if (strCurrentValue.Trim().ToUpper() != "SEQ")
                            {
                                if (strColType == "DATE")
                                {
                                    if (strCurrentValue.Length > 10)
                                    {
                                        strInsertValue += "to_date('" + strCurrentValue + "',' yyyy-MM-dd hh24:mi:ss')";
                                    }
                                    else
                                    {
                                        strInsertValue += "to_date('" + strCurrentValue + "','yyyy-MM-dd')";
                                    }
                                }
                                else
                                {
                                    strInsertValue += "'" + strCurrentValue + "'";
                                }
                            }
                            else
                            {
                                strInsertValue += "SEQ_" + strTableName.ToUpper() + "ID.NEXTVAL";
                            }
                        }
                    }
                    else
                    {
                        if (strInsertValue != "")
                        {
                            strInsertValue += ",";
                            strInsertValue += "NULL";
                        }
                        else
                        {
                            strInsertValue += "NULL";
                        }
                    }


                    if (intAsciiCode < 90)
                    {
                        ASCIIEncoding objEnCode = new ASCIIEncoding();
                        intAsciiCode = (int)objEnCode.GetBytes(strMark)[0];
                        intAsciiCode = intAsciiCode + 1;
                        byte[] byteArray = new byte[] { (byte)intAsciiCode };
                        strMark = objEnCode.GetString(byteArray);
                    }
                    else
                    {
                        ASCIIEncoding objEnCode = new ASCIIEncoding();
                        int intAsciiCode1 = (int)objEnCode.GetBytes(strMarkA)[0];
                        intAsciiCode1 = intAsciiCode1 + 1;
                        byte[] byteArray = new byte[] { (byte)intAsciiCode1 };
                        strMarkA = objEnCode.GetString(byteArray);
                        strMark = "A" + strMarkA;
                    }


                }
                //写插入语句
                Console.WriteLine("insert into  T_" + strTableName + "( " + strCol + ") values(" + strInsertValue + ") ;");
            }
           

          
        }
        /// <summary>
        /// 打开生成好的脚本
        /// </summary>
        private void OpenFile(string p_strSQLPath)
        {
            string strPath = p_strSQLPath;
            TextWriter stringWriter = new StringWriter();

            TextReader stringReader =
                new StringReader(stringWriter.ToString());
            using (TextReader streamReader =
                      new StreamReader(strPath))
            {
                textBox1.Text = streamReader.ReadToEnd();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOracle_Click(object sender, EventArgs e)
        {
            

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//打开一个Excel应用
            if (app == null)
            {
                return;
            }

            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//打开一个现有的工作薄
            Sheets shs = wb.Sheets;

            TextWriter FileSQL = Console.Out;
            FileStream OutFile = new FileStream(strOraclePath, FileMode.Create);
            StreamWriter objWriter = new StreamWriter(OutFile);
            Console.SetOut(objWriter);

            try
            {
                int intCount = 0;
                foreach (string str in cbxTable.CheckedItems)
                {
                    char[] carTwo = new char[] { ',' };
                    string[] strColTwo;
                    strColTwo = str.Split(carTwo);
                    try
                    {
                        _Worksheet sh = (_Worksheet)wb.Sheets[strColTwo[0].ToString().Trim()];
                        if (sh != null)
                        {
                            if (intCount > 0)
                            {
                                Console.Write("\r\n");
                            }
                            SetOracleTable(sh);  //选择Sheet页
                        }
                    }
                    catch (Exception ex)
                    {
                        //提示没有Sheet但继续进行
                        MessageBox.Show(strColTwo[0].ToString() + "工作表不存在" + ex.Message);
                        continue;
                    }
                    intCount++;
                }
               

            }
            catch (Exception ex)
            {
                string strMsg = "";
                strMsg = ex.Message;
                MessageBox.Show(strMsg);
            }
            finally
            {
                //杀掉EXCEL进程
                wb.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                wb = null;
                app = null;
                GC.Collect();
            }
            //textBox1.Text = strValue;
            //保存文件并且打开
            objWriter.Close();
            Console.SetOut(FileSQL);
            OpenFile(strOraclePath);
            MessageBox.Show("数据库表结构生成成功！", "提示！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//打开一个Excel应用
            if (app == null)
            {
                return;
            }

            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//打开一个现有的工作薄
            Sheets shs = wb.Sheets;

            //**********************************************************************************************
            TextWriter FileSQLData = Console.Out;
      
            FileStream OutFileData = new FileStream(strOracleDataPath, FileMode.Create);
     
            StreamWriter objWriterData = new StreamWriter(OutFileData,Encoding.UTF8);

         
            Console.SetOut(objWriterData);

            try
            {
                int intCount = 0;
                 
                intCount = 0;
                foreach (string str in cbxTable.CheckedItems)
                {
                    char[] carTwo = new char[] { ',' };
                    string[] strColTwo;
                    strColTwo = str.Split(carTwo);
                    try
                    {
                        _Worksheet shtb = (_Worksheet)wb.Sheets[strColTwo[0].ToString().Trim()];
                        if (strColTwo[2].ToString().Trim() != "")
                        {
                            _Worksheet shData = (_Worksheet)wb.Sheets[strColTwo[2].ToString().Trim()];
                            if (shData != null)
                            {
                                if (intCount > 0)
                                {
                                    Console.Write("\r\n");
                                }
                                SetOracleTableData(shData, shtb);  //选择Sheet页
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //提示没有Sheet但继续进行
                        MessageBox.Show(strColTwo[0].ToString() + "工作表不存在" + ex.Message);
                        continue;
                    }
                    intCount++;
                }
                Console.WriteLine("commit;");
            }
            catch (Exception ex)
            {
                string strMsg = "";
                strMsg = ex.Message;
                MessageBox.Show(strMsg);
            }
            finally
            {
                //杀掉EXCEL进程
                wb.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                wb = null;
                app = null;
                GC.Collect();
            }
            //保存文件并且打开
            objWriterData.Close();
            Console.SetOut(FileSQLData);
            OpenFile(strOracleDataPath);
            MessageBox.Show("数据库表默认数据生成成功！", "提示！");

        }

        public  bool CheckLength(string p_strInputText, int p_intLength)
        {
            bool boolCheck = false;
            Regex regex = new Regex("[^\x00-\xff]", RegexOptions.Compiled);     // 正则表达式匹配双字节字符(包括汉字在内)
            char[] arrChar = p_strInputText.ToCharArray();
            int intLength = 0;
            for (int i = 0; i < arrChar.Length; i++)
            {
                intLength++;
                if (regex.IsMatch((arrChar[i]).ToString()))                     // 判断是否是双字节
                {
                    intLength++;
                }
            }
            if (intLength > p_intLength)
            {
                boolCheck = true;
            }
            return boolCheck;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();//打开一个Excel应用
            if (app == null)
            {
                return;
            }
            if (!File.Exists(strDBErrorPath))
            {
                File.Create(strDBErrorPath);
            }
            Workbooks wbs = app.Workbooks;
            _Workbook wb = wbs.Add(strDBPath);//打开一个现有的工作薄
            Sheets shs = wb.Sheets;

            //**********************************************************************************************
            TextWriter FileSQLData = Console.Out;

            FileStream OutFileData = new FileStream(strDBErrorPath, FileMode.Create);

            StreamWriter objWriterData = new StreamWriter(OutFileData, Encoding.UTF8);


            Console.SetOut(objWriterData);
            int refCount = 0;
            try
            {
                int intCount = 0;

                intCount = 0;
                foreach (string str in cbxTable.CheckedItems)
                {
                    char[] carTwo = new char[] { ',' };
                    string[] strColTwo;
                    strColTwo = str.Split(carTwo);
                    try
                    {
                        _Worksheet shtb = (_Worksheet)wb.Sheets[strColTwo[0].ToString().Trim()];
                        if (strColTwo[2].ToString().Trim() != "")
                        {
                            _Worksheet shData = (_Worksheet)wb.Sheets[strColTwo[2].ToString().Trim()];
                            if (shData != null)
                            {
                                if (intCount > 0)
                                {
                                    Console.Write("\r\n");
                                }
                                CheckOracleTableData(shData, shtb,ref refCount);  //选择Sheet页
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //提示没有Sheet但继续进行
                        MessageBox.Show(strColTwo[0].ToString() + "工作表不存在" + ex.Message);
                        continue;
                    }
                    intCount++;
                }
                
            }
            catch (Exception ex)
            {
                string strMsg = "";
                strMsg = ex.Message;
                MessageBox.Show(strMsg);
            }
            finally
            {
                //杀掉EXCEL进程
                wb.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                wb = null;
                app = null;
                GC.Collect();
            }
            //保存文件并且打开
            objWriterData.Close();
            Console.SetOut(FileSQLData);
            OpenFile(strDBErrorPath);
            MessageBox.Show("数据验证完成,共" + refCount+"错误", "提示！");

        }


        private void CheckOracleTableData(_Worksheet objSheet, _Worksheet objtb, ref int refCount)
        {
            //设置表的默认结构**************************************************************************************8888
            System.Data.DataTable dtbTable = new System.Data.DataTable();
            dtbTable.Columns.Add("CoName", typeof(string));
            dtbTable.Columns.Add("Length", typeof(string));
            dtbTable.Columns.Add("Type", typeof(string));

            string strValue, strColumnName, strCName, strColumnType, strLength, strIsNull, strDefaultValue, strIsPK, strMemo;
            strValue = "";
            string strIndexValue = "";

            for (int i = 4; i <= objtb.UsedRange.Rows.Count; i++)
            {

                //获取字段名
                Range Column = objtb.get_Range("B" + i.ToString(), System.Reflection.Missing.Value);
                strColumnName = System.Convert.ToString(Column.Value2).Trim().ToUpper();
                //获取字段类型
                Range Type = objtb.get_Range("D" + i.ToString(), System.Reflection.Missing.Value);
                strColumnType = System.Convert.ToString(Type.Value2).Trim().ToUpper();
                //获取字段长度
                Range Length = objtb.get_Range("E" + i.ToString(), System.Reflection.Missing.Value);
                strLength = System.Convert.ToString(Length.Value2).Trim();

                System.Data.DataRow dr = dtbTable.NewRow();
                dr["CoName"] = strColumnName;
                dr["Length"] = strLength;
                dr["Type"] = strColumnType;

                dtbTable.Rows.Add(dr);
            }
            //**************************************************************************************8888*********************

            string strTableName = "";
            string strCol = "";         //列名称
            string strColValue = "";    //列对应EXCEL中纵向位置
            string strMark = "";        //纵向位置标识
            strMark = "B";
            string strMarkA = "@";
            //获取表名称
            Range TableName = objSheet.get_Range("B1", System.Reflection.Missing.Value);
            strTableName = System.Convert.ToString(TableName.Value2).Trim();
            //******************************************************************************
            Console.WriteLine("--*****以下是对插入插入表[" + strTableName + "]数据合法性的验证****************************");


            //**************************************************************************************
            //###############组织列############################################################################################################
            int intAsciiCode = 0;
            for (int i = 2; i <= objSheet.UsedRange.Columns.Count; i++)
            {

                Range Column = objSheet.get_Range(strMark + "3", System.Reflection.Missing.Value);
                //判断表中的列在数据库中是否存在
                dtbTable.DefaultView.RowFilter = "CoName='" + System.Convert.ToString(Column.Value2).Trim().ToUpper() + "'";
                if (dtbTable.DefaultView.Count <= 0)
                {


                }

                if (strCol != "")
                {
                    strCol += ",";
                    strCol += System.Convert.ToString(Column.Value2).Trim();
                }
                else
                {
                    strCol += System.Convert.ToString(Column.Value2).Trim();
                }
                if (strColValue != "")
                {
                    strColValue += ",";
                    strColValue += strMark;
                }
                else
                {
                    strColValue += strMark;
                }
                //strMark = Convert.tos strMark
                if (intAsciiCode < 90)
                {
                    ASCIIEncoding objEnCode = new ASCIIEncoding();
                    intAsciiCode = (int)objEnCode.GetBytes(strMark)[0];
                    intAsciiCode = intAsciiCode + 1;
                    byte[] byteArray = new byte[] { (byte)intAsciiCode };
                    strMark = objEnCode.GetString(byteArray);
                }
                else
                {
                    ASCIIEncoding objEnCode = new ASCIIEncoding();
                    int intAsciiCode1 = (int)objEnCode.GetBytes(strMarkA)[0];
                    intAsciiCode1 = intAsciiCode1 + 1;
                    byte[] byteArray = new byte[] { (byte)intAsciiCode1 };
                    strMarkA = objEnCode.GetString(byteArray);
                    strMark = "A" + strMarkA;
                }


            }
            //##################################################################################################################

            strMark = "B";
            for (int i = 4; i <= objSheet.UsedRange.Rows.Count; i++)
            {
                string strColType = "";
                string strColLength = "";



                string strInsertValue = "";
                char[] carTwo = new char[] { ',' };
                string[] strColTwo;
                strColTwo = strColValue.Split(carTwo);
                for (int j = 0; j < strColTwo.Length; j++)
                {

                    //获取列名称
                    Range Column = objSheet.get_Range(strColTwo[j] + "3", System.Reflection.Missing.Value);
                    string strColName = System.Convert.ToString(Column.Value2).Trim().ToUpper();
                    dtbTable.DefaultView.RowFilter = "CoName='" + strColName + "'";
                    if (dtbTable.DefaultView.Count <= 0)
                    {
                        Console.WriteLine("EXCEL " + strColTwo[j] + i + "行字段名称[ " + strColName + " ]在数据库中不存在 ");
                        refCount++;
                        return;
                    }
                    else
                    {
                        strColType = dtbTable.DefaultView[0]["Type"].ToString().ToUpper();
                        strColLength = dtbTable.DefaultView[0]["Length"].ToString();
                    }



                    string strCurrentValue = "";
                    Range ColValue = objSheet.get_Range(strColTwo[j].ToString() + i.ToString(), System.Reflection.Missing.Value);
                    strCurrentValue = System.Convert.ToString(ColValue.Text).Trim();
                    if (strCurrentValue != "")
                    {
                        strCurrentValue = strCurrentValue.Replace("'", "''");
                        //判断是否长度长了
                        if (strColLength.Trim() != "" || strColType == "CLOB")
                        {
                            switch (strColType)
                            {
                                case "CLOB":
                                    if (CheckLength(strCurrentValue, 4000))
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + "行字段[ " + strColName + " ]长度超过了4000 ");
                                        refCount++;
                                    }
                                    break;
                                case "VARCHAR2":
                                    if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + " 字段[ " + strColName + " ]长度超过了" + strColLength + " ");
                                        refCount++;
                                    }
                                    break;
                                case "CHAR":
                                    if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + " 字段[ " + strColName + " ]长度超过了" + strColLength + " ");
                                        refCount++;
                                    }
                                    break;

                                case "NUMBER":
                                    if (strCurrentValue.Trim().ToUpper() != "SEQ")
                                    {
                                        if (CheckLength(strCurrentValue, Convert.ToInt32(strColLength)))
                                        {
                                            Console.WriteLine("EXCEL " + strColTwo[j] + i + " 字段[ " + strColName + " ]长度超过了" + strColLength + " ");
                                            refCount++;
                                        }
                                        try
                                        {
                                            Convert.ToInt32(strCurrentValue);
                                        }
                                        catch
                                        {
                                            Console.WriteLine("EXCEL " + strColTwo[j] + i + " 字段[ " + strColName + " ]数据类型不正确应该为" + strColType + " ");
                                            refCount++;
                                        }
                                    }
                                    break;
                                case "DATE":
                                    if (CheckLength(strCurrentValue, 19))
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + " 字段[ " + strColName + " ]长度超过了" + strColLength + " ");
                                        refCount++;
                                    }
                                    try
                                    {
                                        Convert.ToDateTime(strCurrentValue);
                                    }
                                    catch
                                    {
                                        Console.WriteLine("EXCEL " + strColTwo[j] + i + " 字段[ " + strColName + " ]数据类型不正确应该为" + strColType + " ");
                                        refCount++;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            if (strInsertValue != "")
                            {
                                strInsertValue += ",";
                                strInsertValue += "NULL";
                            }
                            else
                            {
                                strInsertValue += "NULL";
                            }
                        }





                    }
                    //写插入语句

                }
            }
            Console.WriteLine("共[ "+ refCount+" ]个错误");
        }

        /// <summary>
        /// 作者:     flighingandblue.com
        /// 创建时间: 2008-10-13
        /// 功能描述: 截取字符串
        /// </summary>
        /// <param name="p_strInputText">输入字符串</param>
        /// <param name="p_intlength">最大长度</param>
        /// <returns>返回截取后字符串的长度</returns>
        public   string SubStr(string p_strInputText, int p_intlength)
        {
            return SubStr(p_strInputText, p_intlength, string.Empty);
        }

        /// <summary>
        /// 作者:     flighingandblue.com
        /// 创建时间: 2008-10-13
        /// 功能描述: 截取输入字符串的指定长度，数字和英文算1个，中文和全角算2个
        /// </summary>
        /// <param name="p_strInputText">输入字符串</param>
        /// <param name="p_intLength">截取长度</param>
        /// <param name="p_strLast">拼接在最后</param>
        /// <returns>截取后的字符串</returns>
        public   string SubStr(string p_strInputText, int p_intLength, string p_strLast)
        {
            Regex regex = new Regex("[^\x00-\xff]", RegexOptions.Compiled);     // 正则表达式匹配双字节字符(包括汉字在内)
            char[] arrChar = p_strInputText.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int intLength = 0;
            for (int i = 0; i < arrChar.Length; i++)
            {
                sb.Append(arrChar[i]);
                intLength++;
                if (regex.IsMatch((arrChar[i]).ToString()))                     // 判断是否是双字节
                {
                    intLength++;
                }
                if (intLength == p_intLength)                                   // 判断截取长度是否一致
                {
                    break;
                }
                if (intLength > p_intLength)                                    // 如果截取的长度比设定的长度大则特殊处理
                {
                    sb.Remove(sb.Length - 1, 1);
                    break;
                }
            }
            if (p_strLast != string.Empty && sb.Length < arrChar.Length)
                sb.Append(p_strLast);
            return sb.ToString();
        }





    }

}