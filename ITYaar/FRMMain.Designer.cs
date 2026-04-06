namespace ITYaar
{
    partial class FRMMain
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.TXTKey = new System.Windows.Forms.TextBox();
			this.BTNLogin = new System.Windows.Forms.Button();
			this.username = new System.Windows.Forms.Label();
			this.TXTUserName = new System.Windows.Forms.TextBox();
			this.BTNRefresh = new System.Windows.Forms.Button();
			this.NUDTalar = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.BTNSend = new System.Windows.Forms.Button();
			this.ReadyBox = new System.Windows.Forms.RichTextBox();
			this.RTBChatBox = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnKillSession = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.LB = new System.Windows.Forms.ListBox();
			this.tabControl1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NUDTalar)).BeginInit();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tabControl1.RightToLeftLayout = true;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1170, 519);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.label3);
			this.tabPage4.Controls.Add(this.TXTKey);
			this.tabPage4.Controls.Add(this.BTNLogin);
			this.tabPage4.Controls.Add(this.username);
			this.tabPage4.Controls.Add(this.TXTUserName);
			this.tabPage4.Controls.Add(this.BTNRefresh);
			this.tabPage4.Controls.Add(this.NUDTalar);
			this.tabPage4.Controls.Add(this.label2);
			this.tabPage4.Controls.Add(this.BTNSend);
			this.tabPage4.Controls.Add(this.ReadyBox);
			this.tabPage4.Controls.Add(this.RTBChatBox);
			this.tabPage4.Controls.Add(this.label1);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(1162, 490);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "استخبارات";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1076, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "شماره تالار:";
			// 
			// TXTKey
			// 
			this.TXTKey.Location = new System.Drawing.Point(557, 11);
			this.TXTKey.Name = "TXTKey";
			this.TXTKey.Size = new System.Drawing.Size(223, 24);
			this.TXTKey.TabIndex = 0;
			// 
			// BTNLogin
			// 
			this.BTNLogin.Location = new System.Drawing.Point(15, 11);
			this.BTNLogin.Name = "BTNLogin";
			this.BTNLogin.Size = new System.Drawing.Size(120, 24);
			this.BTNLogin.TabIndex = 12;
			this.BTNLogin.Text = "ورود";
			this.BTNLogin.UseVisualStyleBackColor = true;
			// 
			// username
			// 
			this.username.AutoSize = true;
			this.username.Location = new System.Drawing.Point(455, 15);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(59, 17);
			this.username.TabIndex = 11;
			this.username.Text = "نام کاربر:";
			// 
			// TXTUserName
			// 
			this.TXTUserName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.TXTUserName.Location = new System.Drawing.Point(216, 11);
			this.TXTUserName.Name = "TXTUserName";
			this.TXTUserName.Size = new System.Drawing.Size(233, 25);
			this.TXTUserName.TabIndex = 10;
			// 
			// BTNRefresh
			// 
			this.BTNRefresh.Enabled = false;
			this.BTNRefresh.Location = new System.Drawing.Point(13, 403);
			this.BTNRefresh.Name = "BTNRefresh";
			this.BTNRefresh.Size = new System.Drawing.Size(75, 76);
			this.BTNRefresh.TabIndex = 9;
			this.BTNRefresh.Text = "رفرش";
			this.BTNRefresh.UseVisualStyleBackColor = true;
			// 
			// NUDTalar
			// 
			this.NUDTalar.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.NUDTalar.Location = new System.Drawing.Point(950, 11);
			this.NUDTalar.Name = "NUDTalar";
			this.NUDTalar.Size = new System.Drawing.Size(120, 25);
			this.NUDTalar.TabIndex = 7;
			this.NUDTalar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1213, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "شماره تالار:";
			// 
			// BTNSend
			// 
			this.BTNSend.Enabled = false;
			this.BTNSend.Location = new System.Drawing.Point(94, 403);
			this.BTNSend.Name = "BTNSend";
			this.BTNSend.Size = new System.Drawing.Size(101, 76);
			this.BTNSend.TabIndex = 5;
			this.BTNSend.Text = "ارسال";
			this.BTNSend.UseVisualStyleBackColor = true;
			// 
			// ReadyBox
			// 
			this.ReadyBox.Enabled = false;
			this.ReadyBox.Location = new System.Drawing.Point(201, 406);
			this.ReadyBox.Name = "ReadyBox";
			this.ReadyBox.Size = new System.Drawing.Size(955, 73);
			this.ReadyBox.TabIndex = 4;
			this.ReadyBox.Text = "";
			// 
			// RTBChatBox
			// 
			this.RTBChatBox.Location = new System.Drawing.Point(8, 47);
			this.RTBChatBox.Name = "RTBChatBox";
			this.RTBChatBox.Size = new System.Drawing.Size(1146, 350);
			this.RTBChatBox.TabIndex = 3;
			this.RTBChatBox.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(789, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "کلید:";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1162, 490);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "عملیات";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnKillSession);
			this.groupBox1.Location = new System.Drawing.Point(984, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(322, 358);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// btnKillSession
			// 
			this.btnKillSession.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.btnKillSession.Location = new System.Drawing.Point(10, 22);
			this.btnKillSession.Name = "btnKillSession";
			this.btnKillSession.Size = new System.Drawing.Size(293, 40);
			this.btnKillSession.TabIndex = 4;
			this.btnKillSession.Text = "رفع مشکل ورود به خوددریافت";
			this.btnKillSession.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1162, 490);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "سامانه ها";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(1162, 490);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "گزارشات";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// LB
			// 
			this.LB.FormattingEnabled = true;
			this.LB.Location = new System.Drawing.Point(7, 521);
			this.LB.Name = "LB";
			this.LB.Size = new System.Drawing.Size(1159, 108);
			this.LB.TabIndex = 8;
			// 
			// FRMMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1170, 645);
			this.Controls.Add(this.LB);
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FRMMain";
			this.RightToLeftLayout = true;
			this.Text = "Form1";
			this.tabControl1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NUDTalar)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TXTKey;
		private System.Windows.Forms.Button BTNLogin;
		private System.Windows.Forms.Label username;
		private System.Windows.Forms.TextBox TXTUserName;
		private System.Windows.Forms.Button BTNRefresh;
		private System.Windows.Forms.NumericUpDown NUDTalar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BTNSend;
		private System.Windows.Forms.RichTextBox ReadyBox;
		private System.Windows.Forms.RichTextBox RTBChatBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnKillSession;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ListBox LB;
	}
}

