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
    public partial class WFSysSet : Form
    {
        public WFSysSet()
        {
            InitializeComponent();
        }

        private void WFSysSet_Load(object sender, EventArgs e)
        {
            GetData();
        }

        /// <summary>
        /// 获取设置数据
        /// </summary>
        private void GetData()
        {
            string strPath = GetPath();
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strPath + "SetXML//DB.xml");
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node2 in node.ChildNodes)
            {
                switch (node2.Name.ToString())
                {
                    case "strPCName":
                        txtPcName.Text = node2.InnerText.ToString();
                        break;
                    case "strDBName":
                        txtDataName.Text = node2.InnerText.ToString();
                        break;
                    case "strUserName":
                        txtUserName.Text = node2.InnerText.ToString();
                        break;
                    case "strPassWord":
                        txtPassWord.Text = node2.InnerText.ToString();
                        break;
                    case "strLOGPath":
                        //txtLogPath.Text = node2.InnerText.ToString();
                        break;
                    case "strSQLDBPath":
                        txtSQLDBPath.Text = node2.InnerText.ToString();
                        break;
                    case "strORACLEDBPath":
                        txtDBPath.Text = node2.InnerText.ToString();
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 保存设置文件
        /// </summary>
        private void SaveDBSet()
        {
            string strPath = GetPath();
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(strPath + "SetXML//DB.xml");
            XmlNode node;
            node = myXmlDocument.DocumentElement;
            foreach (XmlNode node2 in node.ChildNodes)
            {
                switch (node2.Name.ToString())
                {
                    case "strPCName":
                        node2.InnerText = txtPcName.Text.ToString();
                        break;
                    case "strDBName":
                        node2.InnerText = txtDataName.Text.ToString();
                        break;
                    case "strUserName":
                        node2.InnerText = txtUserName.Text.ToString();
                        break;
                    case "strPassWord":
                        node2.InnerText = txtPassWord.Text.ToString();
                        break;
                    case "strSQLPath":
                        //node2.InnerText = txtSQLPath.Text.ToString();
                        break;
                    case "strSQLDBPath":
                        node2.InnerText = txtSQLDBPath.Text.ToString();
                        break;
                    case "strORACLEDBPath":
                        node2.InnerText = txtDBPath.Text.ToString();
                        break;
                    default:
                        break;
                }
            }
            myXmlDocument.Save(strPath + "SetXML//DB.xml");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDBSet();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog objPath = new FolderBrowserDialog();
            //objPath.ShowDialog();
            //txtDBPath.Text = objPath.SelectedPath;
            OpenFileDialog objPath = new OpenFileDialog();
            objPath.ShowDialog();
            txtDBPath.Text =objPath.FileName;

        }

        private void btnSQLView_Click(object sender, EventArgs e)
        {
            OpenFileDialog objPath = new OpenFileDialog();
            objPath.ShowDialog();
            txtSQLDBPath.Text = objPath.FileName;
        }
    }
}