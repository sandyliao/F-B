namespace PetDev
{
    partial class WFSysSet
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.txtPcName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtDataName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtSQLDBPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDBPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FBDOracle = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSQLView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "数据库名称";
            // 
            // txtPcName
            // 
            this.txtPcName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPcName.Location = new System.Drawing.Point(141, 24);
            this.txtPcName.Name = "txtPcName";
            this.txtPcName.Size = new System.Drawing.Size(194, 21);
            this.txtPcName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "UserName";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "数据库机器名/IP";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(141, 103);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(194, 21);
            this.txtUserName.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(306, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "关 闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassWord.Location = new System.Drawing.Point(141, 135);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(194, 21);
            this.txtPassWord.TabIndex = 7;
            // 
            // txtDataName
            // 
            this.txtDataName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataName.Location = new System.Drawing.Point(141, 64);
            this.txtDataName.Name = "txtDataName";
            this.txtDataName.Size = new System.Drawing.Size(194, 21);
            this.txtDataName.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(135, 404);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保 存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPcName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.txtPassWord);
            this.groupBox1.Controls.Add(this.txtDataName);
            this.groupBox1.Location = new System.Drawing.Point(49, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 216);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSQLView);
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.txtSQLDBPath);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDBPath);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(49, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 130);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库文件路径设置";
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Location = new System.Drawing.Point(401, 72);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(56, 23);
            this.btnView.TabIndex = 19;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtSQLDBPath
            // 
            this.txtSQLDBPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSQLDBPath.Location = new System.Drawing.Point(141, 28);
            this.txtSQLDBPath.Name = "txtSQLDBPath";
            this.txtSQLDBPath.Size = new System.Drawing.Size(249, 21);
            this.txtSQLDBPath.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "SqlServer数据库设计文档路径";
            // 
            // txtDBPath
            // 
            this.txtDBPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDBPath.Location = new System.Drawing.Point(140, 72);
            this.txtDBPath.Name = "txtDBPath";
            this.txtDBPath.Size = new System.Drawing.Size(250, 21);
            this.txtDBPath.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Oracle数据库设计文档路径";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSQLView
            // 
            this.btnSQLView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSQLView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSQLView.Location = new System.Drawing.Point(401, 25);
            this.btnSQLView.Name = "btnSQLView";
            this.btnSQLView.Size = new System.Drawing.Size(56, 23);
            this.btnSQLView.TabIndex = 23;
            this.btnSQLView.Text = "View";
            this.btnSQLView.Click += new System.EventHandler(this.btnSQLView_Click);
            // 
            // WFSysSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 452);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "WFSysSet";
            this.Text = "后台设置";
            this.Load += new System.EventHandler(this.WFSysSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPcName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.TextBox txtDataName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDBPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSQLDBPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog FBDOracle;
        private System.Windows.Forms.Button btnSQLView;
    }
}