using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Xml;
using System.IO;


namespace PetDev
{
	/// <summary>
	/// WFVCMor 的摘要说明。
	/// </summary>
	public class WFVCMor : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView treeData;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button1;
		public System.Windows.Forms.TextBox txtCSMorSQLDAL;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox groupBox1;
		private	CommonAccess objac=new CommonAccess();

		public WFVCMor()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点6", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点8", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点4", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点3", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeData = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCSMorSQLDAL = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeData
            // 
            this.treeData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeData.Indent = 19;
            this.treeData.ItemHeight = 14;
            this.treeData.Location = new System.Drawing.Point(24, 16);
            this.treeData.Name = "treeData";
            treeNode1.Name = "";
            treeNode1.Text = "节点7";
            treeNode2.Name = "";
            treeNode2.Text = "节点6";
            treeNode3.Name = "";
            treeNode3.Text = "节点0";
            treeNode4.Name = "";
            treeNode4.Text = "节点9";
            treeNode5.Name = "";
            treeNode5.Text = "节点8";
            treeNode6.Name = "";
            treeNode6.Text = "节点1";
            treeNode7.Name = "";
            treeNode7.Text = "节点2";
            treeNode8.Name = "";
            treeNode8.Text = "节点5";
            treeNode9.Name = "";
            treeNode9.Text = "节点4";
            treeNode10.Name = "";
            treeNode10.Text = "节点3";
            this.treeData.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode7,
            treeNode10});
            this.treeData.Size = new System.Drawing.Size(164, 664);
            this.treeData.TabIndex = 25;
            this.treeData.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeData_AfterSelect);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(94, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "生 成";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCSMorSQLDAL
            // 
            this.txtCSMorSQLDAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCSMorSQLDAL.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtCSMorSQLDAL.HideSelection = false;
            this.txtCSMorSQLDAL.Location = new System.Drawing.Point(200, 112);
            this.txtCSMorSQLDAL.Multiline = true;
            this.txtCSMorSQLDAL.Name = "txtCSMorSQLDAL";
            this.txtCSMorSQLDAL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCSMorSQLDAL.Size = new System.Drawing.Size(712, 568);
            this.txtCSMorSQLDAL.TabIndex = 45;
            this.txtCSMorSQLDAL.TextChanged += new System.EventHandler(this.txtCSMorSQLDAL_TextChanged);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(283, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 46;
            this.button2.Text = "web生成";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(472, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 24);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "关 闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(208, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 80);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "代码生成";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // WFVCMor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(992, 723);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCSMorSQLDAL);
            this.Controls.Add(this.treeData);
            this.Name = "WFVCMor";
            this.Text = "存储过程代码生成";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WFVCMor_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void WFVCMor_Load(object sender, System.EventArgs e)
		{
			DataTable dtTableName = new DataTable ();
			
			objac.strSql="select name ,id from sysobjects where xtype='P' and category='0' ORDER BY name";
			objac.IsSP=false;
			objac.SqlParams=null;
			dtTableName=objac.getDataSet();
			treeData.Nodes.Clear();
			FillTree(dtTableName);
			IList ob=new ArrayList();
			ob.Add("22");
			//cmbConnection.Items.Add("6666");

			//GetData();
		}
		/// <summary>
		/// 填充数据库表结构
		/// </summary>
		/// <param name="A_dtbTableName"></param>
		private void FillTree(DataTable A_dtbTableName)
		{
			foreach(DataRow dr in A_dtbTableName.Rows)
			{
				
				TreeNode trn=new TreeNode();
				trn.Text=dr["name"].ToString();
				trn.Tag=dr["id"].ToString();

				treeData.Nodes.Add(trn);

				treeData.SelectedNode=trn;
				objac.strSql="SELECT NAME AS [ColName] from syscolumns  WHERE id = '"+dr["id"].ToString()+"' ";
				objac.IsSP=false;
				objac.SqlParams=null;
				DataTable dtTableNameCol=new DataTable();
				dtTableNameCol=objac.getDataSet();

				foreach(DataRow dr1 in dtTableNameCol.Rows)
				{
					TreeNode trn1=new TreeNode();
					trn1.Text=dr1["ColName"].ToString();

					treeData.SelectedNode.Nodes.Add(trn1);
				}

			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			DataTable  dtbConame;
			dtbConame=GetColTable();

			int i=0;
			TextWriter tmp = Console.Out;

			FileStream OutFile = new FileStream("CSTableStruct.txt", FileMode.Create);
			
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
						GetColInfo(dr["ColName"].ToString(),dr["DBType"].ToString(),dr["Length"].ToString(),out strIn,out strLength,out strOutType,out strOutSqlType, out strOutValue);
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
								strPa+=GetPa(dr["DBType"].ToString(),dr["ColName"].ToString(),dr["Length"].ToString());
							}
							else
							{
								strPa+=" \n";
								strPa+= "new SqlParameter(\""+dr["ColName"].ToString()+"\","+GetSqlType(dr["DBType"].ToString())+","+intLength+"),";
							}
						}
						else
						{
							if(dr["status"].ToString()=="4")
							{
								strPa+=GetPa(dr["DBType"].ToString(),dr["ColName"].ToString(),dr["Length"].ToString());
							}
							else
							{
								strPa+= "new SqlParameter(\""+dr["ColName"].ToString()+"\","+GetSqlType(dr["DBType"].ToString())+","+intLength+"),";
							}
						}	
						if(strPaValue!="")
						{
							if(dr["status"].ToString()=="4")
							{
								strPaValue+=" \n";
								strPaValue+="parameters["+i+"].Value="+GetPaVal(dr["DBType"].ToString())+";";
							}
							else
							{
								strPaValue+="\n";
								strPaValue+="parameters["+i+"].Value=((IList)p_objArrayList["+i+"])[1].ToString();;";
							}
						}
						else
						{
							if(dr["status"].ToString()=="4")
							{
								
								strPaValue+="parameters["+i+"].Value="+GetPaVal(dr["DBType"].ToString())+";";
							}
							else
							{
								strPaValue+="parameters["+i+"].Value=((IList)p_objArrayList["+i+"])[1].ToString();";
							}
						}

					i++;
				
			}
			int j=i-1;
			strNewSp="SqlParameter[] parameters={\n"+strPa+"\n}";
			Console.WriteLine("public string ExceSp(IList p_objArrayList)");
			Console.WriteLine("{");
			Console.WriteLine(strNewSp+";");
			Console.WriteLine(strPaValue);

			
			Console.WriteLine("this.ExecuteSP ("+treeData.SelectedNode.Text.ToString()+",parameters) ;");
			Console.WriteLine("if ( parameters["+j+"].Value.ToString()==\"0\")");
			Console.WriteLine("{");
			Console.WriteLine("	return \"\";");
			Console.WriteLine("}");
			Console.WriteLine("else");
			Console.WriteLine("{");
			Console.WriteLine("	return parameters["+i+"].Value.ToString();");
			Console.WriteLine("}");
			Console.WriteLine("}");

			objWriter.Close();
			Console.SetOut(tmp);
			openTableStructFile();

		}
		private string GetPath()
		{
			string str =System.Windows.Forms.Application.ExecutablePath.ToString();
            string strPath = str.ToUpper().Replace("TOMDEV.EXE", "");
			return strPath;
		}

		/// </summary>
		private void openTableStructFile()
		{

			string strPath=GetPath();
			TextWriter stringWriter = new StringWriter();

			TextReader stringReader = 
				new StringReader(stringWriter.ToString());
			using(TextReader streamReader = 
					  new StreamReader(strPath+"CSTableStruct.txt"))
			{
				txtCSMorSQLDAL.Text=streamReader.ReadToEnd();
			}
		}

		private DataTable  GetColTable()
		{
			string strSpName="";
			strSpName=this.treeData.SelectedNode.Tag.ToString();
			if (strSpName=="")
			{
				MessageBox.Show("请选择需要生成的SP!");
				return null;
			}
			objac.strSql="SELECT a.name as ColName,b.name as DBType,a.length as length ,a.colstat as status   from syscolumns as a ,systypes as b   WHERE a.xtype=b.xtype and a.id = '"+strSpName+"'  order by a.colid ";
			objac.IsSP=false;
			objac.SqlParams=null;
			DataTable dtTableNameCol=new DataTable();
			dtTableNameCol=objac.getDataSet();
			return dtTableNameCol;
		}

		private void  GetColInfo( string strColName,string  strType , string strInLength,out string strOut,out string strOutLength, out string stroutType,out string strOutSqlType,out string strOutValue)
		{
			
			strOut="";
			strOutLength="";
			stroutType="";
			strOutSqlType="";
			strOutValue="";

			switch(strType)       
			{         
				case "float":   
					strOutLength="8";
					strOut="flt"+strColName;
					stroutType="float";
					strOutSqlType="Float";
					strOutValue="=float.MinValue" ;
					break; 
				case"datetime":
					strOutLength="8";
					strOut="dtm"+strColName;
					stroutType="DateTime";
					strOutSqlType="DateTime";
					strOutValue="=DateTime.MinValue";
					break;
				case"uniqueidentifier":
					strOutLength="16";
					strOut="str"+strColName;
					stroutType="string";
					strOutSqlType="=UniqueIdentifier";
					strOutValue="";
					break;
				case"int":
					strOutLength="4";
					strOut="int"+strColName;
					stroutType="int";
					strOutSqlType="Int";
					strOutValue="=int.MinValue";
					break;
				case"smalldatetime":
					strOutLength="4";
					strOut="dtm"+strColName;
					stroutType="DateTime";
					strOutSqlType="SmallDateTime";
					strOutValue="=DateTime.MinValue";
					break;
				case"bit":
					strOutLength="1";
					strOut="bit"+strColName;
					stroutType="bit";
					strOutSqlType="Bit";
					strOutValue="";
					break;
				case"smallint":
					strOutLength="2";
					strOut="int"+strColName;
					stroutType="int";
					strOutSqlType="=SmallInt";
					break;
				case"real":
					strOutLength="4";
					strOut="rel"+strColName;
					stroutType="float";
					strOutSqlType="=Real";
					break;
				case"money":
					strOutLength="8";
					strOut="moy"+strColName;
					stroutType="Decimal";
					strOutSqlType="Money";
					break;
				case"char":
					strOutLength=strInLength;
					strOut="str"+strColName;
					stroutType="string";
					strOutSqlType="Char";
					strOutValue="";
					break;
				case"nvarchar":
					strOutLength=strInLength;
					strOut="str"+strColName;
					stroutType="string";
					strOutSqlType="NVarChar";
					strOutValue="";
					break;
				case"varchar":
					strOutLength=strInLength;
					strOut="str"+strColName;
					stroutType="string";
					strOutSqlType="VarChar";
					strOutValue="";
					break;
				case"nchar":
					strOutLength=strInLength;
					strOut="str"+strColName;
					stroutType="string";
					strOutSqlType="NChar";
					strOutValue="";
					break;
				case"image":
					strOutLength=strInLength;
					strOut="Img"+strColName;
					stroutType="byte[]";
					strOutSqlType="Image";
				
					break;


				default:
					strOutLength=strInLength;
					strOut="str"+strColName;
					stroutType="string";
					strOutSqlType="NVarChar";
					strOutValue="";
					break;
			}
		}

		private  string  GetSqlType(string p_strType)
		{
			string  strOutSPType="";
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

		private string GetPa(string strType,string strCoName,string strLength)
		{

			if (strType=="int")
			{
				return "new SqlParameter(\""+strCoName+"\",SqlDbType.Int  ,4,ParameterDirection.Output,false,0, 0, String.Empty, DataRowVersion.Default, 0),";
			}
			if(strType=="varchar")
			{
				return "new SqlParameter(\""+strCoName+"\",SqlDbType.VarChar ,"+strLength+",ParameterDirection.Output,false,0, 0, String.Empty, DataRowVersion.Default, \"\"),";
			}
			if(strType=="uniqueidentifier")
			{
				return "new SqlParameter(\""+strCoName+"\",SqlDbType.UniqueIdentifier ,16,ParameterDirection.Output,false,0, 0, String.Empty, DataRowVersion.Default, \"\"),";
			}
			else
			{
				return "";
			}


		}

		private string GetPaVal(string strType)
		{

			if (strType=="int")
			{
				return "0";
			}
			if(strType=="varchar")
			{
				return "\"\"";
			}
			if(strType=="uniqueidentifier")
			{
				return "\"\"";
			}
			else
			{
				return "";
			}


		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			DataTable  dtbConame;
			dtbConame=GetColTable();

			int i=0;
			TextWriter tmp = Console.Out;

			FileStream OutFile = new FileStream("CSTableStruct.txt", FileMode.Create);
			
			StreamWriter objWriter = new StreamWriter(OutFile);
			Console.SetOut(objWriter);
			


			string strPa="";
			string strNewSp="";
			
			foreach  (DataRow  dr in dtbConame.Rows )
			{
				
				string intLength="0";
				string strtype="";
						
				string strIn="";
				string strLength="";
				string strOutType="";
				string  strOutSqlType="";
				string  strOutValue="";
				GetColInfo(dr["ColName"].ToString(),dr["DBType"].ToString(),dr["Length"].ToString(),out strIn,out strLength,out strOutType,out strOutSqlType, out strOutValue);
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
//						strPa+=" \n";
//						strPa+=GetPa(dr["DBType"].ToString(),dr["ColName"].ToString(),dr["Length"].ToString());
					}
					else
					{
						strPa+=" \n";
						strPa+= "objIArrayList.Add (\""+dr["ColName"].ToString().Replace("@","")+"\",txt"+dr["ColName"].ToString().Replace("@","")+".Text.ToString());";
					}
				}
				else
				{
					if(dr["status"].ToString()=="4")
					{
						//strPa+=GetPa(dr["DBType"].ToString(),dr["ColName"].ToString(),dr["Length"].ToString());
					}
					else
					{
						strPa+= "objIArrayList.Add (\""+dr["ColName"].ToString().Replace("@","")+"\",txt"+dr["ColName"].ToString().Replace("@","")+".Text.ToString());";
					}
				}	
//				if(strPaValue!="")
//				{
//					if(dr["status"].ToString()=="4")
//					{
//						strPaValue+=" \n";
//						strPaValue+="parameters["+i+"].Value=\"A\";";
//					}
//					else
//					{
//						strPaValue+="\n";
//						strPaValue+="parameters["+i+"].Value=\"A\";";
//					}
//				}
//				else
//				{
//					if(dr["status"].ToString()=="4")
//					{
//								
//						strPaValue+="parameters["+i+"].Value=\"A\";";
//					}
//					else
//					{
//						strPaValue+="parameters["+i+"].Value=\"A\";";
//					}
//				}

				i++;
				
			}
			int j=i-1;
			strNewSp="SqlParameter[] parameters={\n"+strPa+"\n}";
			Console.WriteLine("public IList ExceSp()");
			Console.WriteLine("{");
			Console.WriteLine("IArrayList objIArrayList  = new IArrayList(); ");

			Console.WriteLine(strPa+"");
			//Console.WriteLine(strPaValue);

			
//			Console.WriteLine("this.ExecuteSP ("+treeData.SelectedNode.Text.ToString()+",parameters) ;");
//			Console.WriteLine("if ( parameters["+j+"].Value.ToString()==\"0\")");
//			Console.WriteLine("{");
//			Console.WriteLine("	return \"\";");
//			Console.WriteLine("}");
//			Console.WriteLine("else");
//			Console.WriteLine("{");
//			Console.WriteLine("	return parameters["+i+"].Value.ToString();");
			Console.WriteLine("return objIArrayList ");
			Console.WriteLine("}");

			objWriter.Close();
			Console.SetOut(tmp);
			openTableStructFile();

		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

        private void txtCSMorSQLDAL_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeData_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
		
	
	}
}
