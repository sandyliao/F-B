using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PetDev
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Index : System.Windows.Forms.Form
	{
        private System.Windows.Forms.MainMenu TopMenu;
		private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuExit;
        public Dev4Arabs.OfficeMenus officeMenuTop;
		private System.Windows.Forms.MenuItem menuSQLCMor;
		private System.Windows.Forms.MenuItem menuSQLCSig;
		private System.Windows.Forms.MenuItem menuSet;
        private System.Windows.Forms.MenuItem menuSQL;
        private MenuItem menuItem5;
        private MenuItem menuItem11;
        private MenuItem menuItem8;
        private MenuItem menuItem1;
        private MenuItem menuItem14;
        private MenuItem menuItem15;
        private MenuItem menuItem16;
        private MenuItem menuItem17;
        private MenuItem menuItem10;
		private System.ComponentModel.IContainer components;

		public Index()
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
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.TopMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuSQL = new System.Windows.Forms.MenuItem();
            this.menuSQLCSig = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuSQLCMor = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuSet = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.officeMenuTop = new Dev4Arabs.OfficeMenus(this.components);
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14,
            this.menuSQL,
            this.menuItem5,
            this.menuSet});
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 0;
            this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15,
            this.menuItem16,
            this.menuItem17});
            this.menuItem14.Text = "SQLServer代码生成";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 0;
            this.menuItem15.Text = "单表生成（C#）";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 1;
            this.menuItem16.Text = "两表生成（C#）";
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 2;
            this.menuItem17.Text = "存储过程调用（C#）";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuSQL
            // 
            this.menuSQL.Index = 1;
            this.menuSQL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSQLCSig,
            this.menuItem1,
            this.menuSQLCMor});
            this.menuSQL.Text = "Oracle代码生成";
            // 
            // menuSQLCSig
            // 
            this.menuSQLCSig.Index = 0;
            this.menuSQLCSig.Text = "单表生成（C#）";
            this.menuSQLCSig.Click += new System.EventHandler(this.menuSQLCSig_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "两表生成（C#）";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuSQLCMor
            // 
            this.menuSQLCMor.Index = 2;
            this.menuSQLCMor.Text = "存储过程调用（C#）";
            this.menuSQLCMor.Click += new System.EventHandler(this.menuSQLCMor_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem10});
            this.menuItem5.Text = "数据库表管理";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Text = "Oracle数据库脚本生成";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.Text = "SQLServer数据库脚本生成";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuSet
            // 
            this.menuSet.Index = 3;
            this.menuSet.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuItem3,
            this.menuExit});
            this.menuSet.Text = "设置";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "系统设置";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 2;
            this.menuExit.Text = "退出";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // officeMenuTop
            // 
            this.officeMenuTop.ImageList = null;
            // 
            // Index
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(704, 444);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.TopMenu;
            this.Name = "Index";
            this.Text = "代码生成器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Index_Load);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Index());
		}

		private void Index_Load(object sender, System.EventArgs e)
		{
			officeMenuTop.Start(this);
		}

		private void menuAboutMe_Click(object sender, System.EventArgs e)
		{
		 
		}

		private void menuSetDB_Click(object sender, System.EventArgs e)
		{
			 
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuSQLCMor_Click(object sender, System.EventArgs e)
		{
            WFOracleSP NewMDIChild = new WFOracleSP();
            NewMDIChild.WindowState = FormWindowState.Maximized;
			NewMDIChild.MdiParent = this;
			NewMDIChild.Show();
		}

		private void menuSQLCSig_Click(object sender, System.EventArgs e)
		{
            WFOracleSig NewMDIChild = new WFOracleSig();
            NewMDIChild.MdiParent = this;
            NewMDIChild.WindowState = FormWindowState.Maximized;
            NewMDIChild.Show();
		}

		private void menuSQLVBMor_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuSQLVBSig_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuACSCMor_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuACSCSig_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuACSVBMor_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuACSVBSig_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuDBToXML_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuDBToHtml_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuDBToAccess_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuDBStructTOAccess_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuDBStructTOXML_Click(object sender, System.EventArgs e)
		{
		
		}

        private void menuItem11_Click(object sender, EventArgs e)
        {
            WFSysSet NewMDIChild = new WFSysSet();
            NewMDIChild.WindowState = FormWindowState.Maximized;
            NewMDIChild.MdiParent = this;
            NewMDIChild.Show();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            WFOracleMor NewMDIChild = new WFOracleMor();
            NewMDIChild.WindowState = FormWindowState.Maximized;
            NewMDIChild.MdiParent = this;
            NewMDIChild.Show();
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            WFOracleDBSet NewMDIChild = new WFOracleDBSet();
            NewMDIChild.WindowState = FormWindowState.Maximized;
            NewMDIChild.MdiParent = this;
            NewMDIChild.Show();
        }


        private void menuItem13_Click(object sender, EventArgs e)
        {
            //WFSetJobs NewMDIChild = new WFSetJobs();
            //NewMDIChild.WindowState = FormWindowState.Maximized;
            //NewMDIChild.MdiParent = this;
            //NewMDIChild.Show();
        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            WFSQLSig NewMDIChild = new WFSQLSig();
            NewMDIChild.WindowState = FormWindowState.Maximized;
            NewMDIChild.MdiParent = this;
            NewMDIChild.Show();
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            WFSQLDBSet NewMDIChild = new WFSQLDBSet();
            NewMDIChild.WindowState = FormWindowState.Maximized;
            NewMDIChild.MdiParent = this;
            NewMDIChild.Show();
        }

        private void menuItem17_Click(object sender, EventArgs e)
        {

            WFSPSet NewMDIChild = new WFSPSet();
            NewMDIChild.WindowState = FormWindowState.Maximized;
            NewMDIChild.MdiParent = this;
            NewMDIChild.Show();
        }
	}
}
