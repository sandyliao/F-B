using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace PetDev
{
    /// <summary>
    /// 修改者:     ***
    /// 修改时间:   0000-00-00
    /// 修改内容:   
    /// 类功能描述: DataTable的导出到Excel处理
    /// </summary>
    public class ToExcel
    {
        /// <summary>
        /// 功能描述: DataTable导出数据到Excel,这里可以根据需要再进行修改
        /// 调用说明:
        /// objArrayCol.Insert(0, "XM");
        /// objArrayCol.Insert(1, "NJ");
        /// objArrayCol.Insert(2, "SFZH");
        /// objArrayCol.Insert(3, "CSRQ");
        /// objArrayColName.Insert(0, "姓名");
        /// objArrayColName.Insert(1, "年龄");
        /// objArrayColName.Insert(2, "身份证号");
        /// objArrayColName.Insert(3, "出生日期");
        /// </summary>
        /// <param name="dtbOut">导出的数据集</param>
        /// <param name="objArrayColName">列名称objHasValue.add("序列号","字段名")</param>
        /// <param name="objArrayCol">列对应的说明 objHasValue.add("序列号","字段说明")</param>
        /// <param name="strFileName">临时文件路径</param>
        public void SetExcelLog(System.Data.DataTable dtbOut, ArrayList objArrayColName, ArrayList objArrayCol, string strFileName)
        {
            #region"初始化变量"
            Microsoft.Office.Interop.Excel.Application ThisApplication = new ApplicationClass();//启动Excel进程
            Microsoft.Office.Interop.Excel.Workbook ThisWorkBook;
            ThisWorkBook = ThisApplication.Workbooks.Add(true);
            object missing = System.Reflection.Missing.Value;
            #endregion
            try
            {
                //实例化Sheet
                Worksheet ThisSheet = new Worksheet();

                //#region"设置总Sheet"
                //ThisSheet = (Worksheet)ThisWorkBook.ActiveSheet;
                //ThisSheet.Name = "目录";
                //for (int t = 1; t <= 5; t++)
                //{
                //    Range r1 = (Range)ThisSheet.Cells[t, 1];
                //    //设置当前位置超连接到的Sheet
                //    r1.Hyperlinks.Add(r1, "", "信息" + t + "!A1", missing, "信息" + t);
                //}
                //#endregion

                #region"设置分Sheet"
                //for (int x = 1; x <= 5; x++)
                //{
                //int y = x - 1;
                ////参数中可以设置是加在sheet后面还是前面
                //if (x > 0)
                //{
                //    ThisApplication.Worksheets.Add(missing, ThisSheet, missing, missing);
                //}
                ThisSheet = (Worksheet)ThisWorkBook.ActiveSheet;
                ThisSheet.Name = "Sheet";// +x.ToString();

                #region"生成标题行"
                //int m = 1;
                for (int i = 0; i < objArrayColName.Count; i++)
                {
                    //if (i < objArrayColName.Count)
                    //{
                    ThisSheet.Cells[1, i + 1] = "'" + objArrayColName[i].ToString();
                    //Range r1 = (Range)ThisSheet.Cells[1, m];
                    Range r1 = (Range)ThisSheet.Cells[1, i + 1];
                    r1.Font.Bold = true;
                    // r1.Borders.LineStyle = 1;                                   //单元格边框宽度
                    //r1.Borders.Color = System.Drawing.Color.Black.ToArgb();        //单元格边框颜色
                    //r1.Interior.Color = System.Drawing.Color.LightGray.ToArgb();   //单元格背景颜色
                    //r1.Borders[XlBordersIndex.xlDiagonalDown].Weight = 1;           //设置边筐样式    
                    //}
                    //else
                    //{
                    //    Range r1 = (Range)ThisSheet.Cells[1, m];
                    //r1.Hyperlinks.Add(r1, "http://www. .com", " ");
                    //设置返回到当前位置超连接
                    //r1.Hyperlinks.Add(r1, "", "目录!A1", missing, "back");
                    //}
                    //m++;
                }
                #endregion

                #region"生成数据行"
                for (int i = 0; i < dtbOut.Rows.Count; i++)
                {
                    int j = 1;
                    for (int n = 0; n < objArrayCol.Count; n++)
                    {
                        string str = objArrayCol[n].ToString();
                        string str1 = dtbOut.Columns[str].DataType.ToString();
                        //判断数据类型来做特殊处理
                        if (str1 == "System.DateTime")
                        {
                            ThisSheet.Cells[i + 2, j] = "'" + Convert.ToDateTime(dtbOut.Rows[i][str]).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            ThisSheet.Cells[i + 2, j] = dtbOut.Rows[i][str].ToString();// + x.ToString();
                        }
                        j++;
                    }

                }
                #endregion

                //设置公式项
                //Range r2 = (Range)ThisSheet.Cells[4, 2];
                //r2.Formula = "=SUM(B3+B2)";

                /*参数说明
                FileName                要创建的 OLE 对象的源文件。
                LinkToFile              要链接至的文件。
                SaveWithDocument        图片与文档一起保存。
                Left                    左上角的位置。
                Top                     图片左上角的位置。
                Width                   图片的宽度。
                Height                  图片的高度。
                往EXCEL中添加图片*/
                //ThisSheet.Shapes.AddPicture("C:\\ .gif", Microsoft.Office.Core.MsoTriState.msoCTrue, Microsoft.Office.Core.MsoTriState.msoCTrue, 250, 0, 70, 30);
                //}
                #endregion

                //保存工作薄
                ThisSheet.SaveAs("C:\\"+strFileName, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            finally
            {
                #region"销毁Excel进程"
                ThisWorkBook.Close(false, Type.Missing, Type.Missing);
                ThisApplication.Workbooks.Close();
                ThisApplication.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ThisWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ThisApplication);
                ThisWorkBook = null;
                ThisApplication = null;
                GC.Collect();
                #endregion
            }
        }
 

    }
}
