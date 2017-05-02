using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;


namespace PetDev
{
    class BLLExcel
    {

        private void OpenSeet()
        {
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            object missing = System.Reflection.Missing.Value;
            ObjWorkBook = ObjExcel.Workbooks.Open(Environment.CurrentDirectory + "SQL.xls", missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
        }

        private void AddSQL(string strValue)
        {

            /// 获取Txt文本的路径名称
            string strFilePath = Environment.CurrentDirectory + "\\SQL.txt";
            //写物理文件
            StreamWriter objStrWriter = null;
            try
            {
                /// 判断该日志文件是否存在
                if (!File.Exists(strFilePath))
                {
                    objStrWriter = File.CreateText(strFilePath);
                }
                else
                {
                    objStrWriter = File.AppendText(strFilePath);
                }

                /// 写入当前日志信息
                objStrWriter.WriteLine(strValue);
                objStrWriter.WriteLine("--****************************************");
              
            }
            catch
            {
               
            }
            finally
            {
                objStrWriter.Close();
            }


        }
    }
}
