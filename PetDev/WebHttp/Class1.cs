using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace PetDev
{
    class HttpWebHelper
    {
        public static string ReadWebHTML(string p_strURL,string p_strInCode)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(p_strURL);
            req.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(p_strInCode));
            string webhtml = sr.ReadToEnd();
            webhtml = TrimHTMLString(webhtml);
            return webhtml;
        }

        private static string TrimHTMLString(string html)
        {
            html = html.Replace("\r", string.Empty);
            html = html.Replace("\n", string.Empty);
            return html;
        }

        public static string PostGet(string p_strURL, string p_strInCode)
        {
            System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(p_strURL);

            httpWebRequest.Method = "POST";

            httpWebRequest.ContentType = "application/x-www-form-urlencoded";      //表头的格式必须要写,否则请求响应的页面得不到要传递的值

            byte[] SomeBytes = System.Text.Encoding.Default.GetBytes("jtq=onlyrecord&urlKey=Y29tcGFueVR5cGVJRExpc3QlM0QlMjZpc0ludGVyVmlldyUzRDclMjZjb21wYW55TmFtZSUzRCUyNXU5NGY2JTI1dTg4NGMlMjZwcmolM0RxdWljayUyNnNqJTNEMSUyNmN1clBhZ2UlM0Q5JTI2cGFnZVNpemUlM0QyMCUyNnJlY29yZENvdW50JTNEMTUyMyUyNm9yZGVyRmllbGQlM0RSZWZyZXNoRGF0ZSUyNm9yZGVyJTNEREVTQw== jtUrl=document.location.href&hidRnd=tmpJtRefRnd");//传递的值
            httpWebRequest.ContentLength = SomeBytes.Length;
            System.IO.Stream newStream = httpWebRequest.GetRequestStream();//把传递的值写到流中   
            newStream.Write(SomeBytes, 0, SomeBytes.Length);
            newStream.Close();//必须要关闭 请求
            System.Net.HttpWebResponse httpWebResponse = null;
            httpWebResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
            System.IO.Stream s = httpWebResponse.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(s, System.Text.Encoding.Default);
            string respHTML = reader.ReadToEnd();
            return respHTML;
        }

        private void OpenSeet()
        {
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            object missing = System.Reflection.Missing.Value;
            ObjWorkBook = ObjExcel.Workbooks.Open(Environment.CurrentDirectory + "JOBS.xls", missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
        }
    }


     
}
