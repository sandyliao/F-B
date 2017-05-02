namespace PetDev
{
    partial class WFSPSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.btnSet = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeData
            // 
            this.treeData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeData.Indent = 19;
            this.treeData.ItemHeight = 14;
            this.treeData.Location = new System.Drawing.Point(2, 2);
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
            this.treeData.Size = new System.Drawing.Size(164, 458);
            this.treeData.TabIndex = 71;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(363, 12);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 72;
            this.btnSet.Text = "生成代码";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtValue
            // 
            this.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValue.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtValue.HideSelection = false;
            this.txtValue.Location = new System.Drawing.Point(200, 82);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtValue.Size = new System.Drawing.Size(483, 378);
            this.txtValue.TabIndex = 106;
            // 
            // WFSPSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 540);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.treeData);
            this.Name = "WFSPSet";
            this.Text = "WFSPSet";
            this.Load += new System.EventHandler(this.WFSPSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeData;
        private System.Windows.Forms.Button btnSet;
        public System.Windows.Forms.TextBox txtValue;
    }
}