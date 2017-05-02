using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace PetDev.WFControl
{
	/// <summary>
	/// UCTreeView 的摘要说明。
	/// </summary>
	public class UCTreeView : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView treeData;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UCTreeView()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

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

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
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
            this.SuspendLayout();
            // 
            // treeData
            // 
            this.treeData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeData.Indent = 19;
            this.treeData.ItemHeight = 14;
            this.treeData.Location = new System.Drawing.Point(40, 16);
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
            this.treeData.Size = new System.Drawing.Size(164, 680);
            this.treeData.TabIndex = 26;
            // 
            // UCTreeView
            // 
            this.Controls.Add(this.treeData);
            this.Name = "UCTreeView";
            this.Size = new System.Drawing.Size(248, 728);
            this.Load += new System.EventHandler(this.UCTreeView_Load);
            this.ResumeLayout(false);

		}
		#endregion

        private void UCTreeView_Load(object sender, EventArgs e)
        {

        }
	}
}
