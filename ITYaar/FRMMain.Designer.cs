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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMMain));
            this.LB = new System.Windows.Forms.ListBox();
            this.TimerLoadingMSG = new System.Windows.Forms.Timer(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnKillSession = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.TXTKey = new System.Windows.Forms.TextBox();
            this.TXTUserName = new System.Windows.Forms.TextBox();
            this.ReadyBox = new System.Windows.Forms.RichTextBox();
            this.RTBChatBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTNLogin = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.BTNRefresh = new System.Windows.Forms.Button();
            this.NUDTalar = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.راهنماToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.راهنماToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.دربارهبرنامهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.نسخجدیدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNCleanOldMessages = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTalar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB
            // 
            this.LB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LB.FormattingEnabled = true;
            this.LB.ItemHeight = 16;
            this.LB.Location = new System.Drawing.Point(15, 654);
            this.LB.Margin = new System.Windows.Forms.Padding(4);
            this.LB.Name = "LB";
            this.LB.Size = new System.Drawing.Size(1431, 164);
            this.LB.TabIndex = 8;
            // 
            // TimerLoadingMSG
            // 
            this.TimerLoadingMSG.Interval = 4000;
            this.TimerLoadingMSG.Tick += new System.EventHandler(this.TimerLoadingMSG_Tick);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1456, 583);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "گزارشات";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1456, 583);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "سامانه ها";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnKillSession);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1456, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "عملیات";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnKillSession
            // 
            this.btnKillSession.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnKillSession.Location = new System.Drawing.Point(12, 8);
            this.btnKillSession.Margin = new System.Windows.Forms.Padding(4);
            this.btnKillSession.Name = "btnKillSession";
            this.btnKillSession.Size = new System.Drawing.Size(270, 49);
            this.btnKillSession.TabIndex = 4;
            this.btnKillSession.Text = "رفع مشکل ورود به خوددریافت";
            this.btnKillSession.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage4.Controls.Add(this.TXTKey);
            this.tabPage4.Controls.Add(this.BTNCleanOldMessages);
            this.tabPage4.Controls.Add(this.TXTUserName);
            this.tabPage4.Controls.Add(this.ReadyBox);
            this.tabPage4.Controls.Add(this.RTBChatBox);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.BTNLogin);
            this.tabPage4.Controls.Add(this.username);
            this.tabPage4.Controls.Add(this.BTNRefresh);
            this.tabPage4.Controls.Add(this.NUDTalar);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.BTNSend);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(1456, 583);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "استخبارات";
            // 
            // TXTKey
            // 
            this.TXTKey.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TXTKey.Location = new System.Drawing.Point(848, 16);
            this.TXTKey.Margin = new System.Windows.Forms.Padding(4);
            this.TXTKey.Name = "TXTKey";
            this.TXTKey.Size = new System.Drawing.Size(296, 30);
            this.TXTKey.TabIndex = 0;
            this.TXTKey.Text = "MyKey";
            this.TXTKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXTKey_KeyDown);
            // 
            // TXTUserName
            // 
            this.TXTUserName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TXTUserName.Location = new System.Drawing.Point(459, 15);
            this.TXTUserName.Margin = new System.Windows.Forms.Padding(4);
            this.TXTUserName.Name = "TXTUserName";
            this.TXTUserName.Size = new System.Drawing.Size(301, 30);
            this.TXTUserName.TabIndex = 10;
            this.TXTUserName.Text = "MyName";
            this.TXTUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXTUserName_KeyDown);
            // 
            // ReadyBox
            // 
            this.ReadyBox.Enabled = false;
            this.ReadyBox.Location = new System.Drawing.Point(268, 487);
            this.ReadyBox.Margin = new System.Windows.Forms.Padding(4);
            this.ReadyBox.Name = "ReadyBox";
            this.ReadyBox.Size = new System.Drawing.Size(1173, 89);
            this.ReadyBox.TabIndex = 4;
            this.ReadyBox.Text = "";
            this.ReadyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReadyBox_KeyDown);
            // 
            // RTBChatBox
            // 
            this.RTBChatBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.RTBChatBox.Location = new System.Drawing.Point(11, 58);
            this.RTBChatBox.Margin = new System.Windows.Forms.Padding(4);
            this.RTBChatBox.Name = "RTBChatBox";
            this.RTBChatBox.Size = new System.Drawing.Size(1431, 416);
            this.RTBChatBox.TabIndex = 3;
            this.RTBChatBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(1343, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "شماره تالار:";
            // 
            // BTNLogin
            // 
            this.BTNLogin.Location = new System.Drawing.Point(341, 10);
            this.BTNLogin.Margin = new System.Windows.Forms.Padding(4);
            this.BTNLogin.Name = "BTNLogin";
            this.BTNLogin.Size = new System.Drawing.Size(110, 40);
            this.BTNLogin.TabIndex = 12;
            this.BTNLogin.Text = "ورود";
            this.BTNLogin.UseVisualStyleBackColor = true;
            this.BTNLogin.Click += new System.EventHandler(this.BTNLogin_Click);
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.username.Location = new System.Drawing.Point(768, 20);
            this.username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(80, 23);
            this.username.TabIndex = 11;
            this.username.Text = "نام کاربر:";
            // 
            // BTNRefresh
            // 
            this.BTNRefresh.Enabled = false;
            this.BTNRefresh.Location = new System.Drawing.Point(11, 482);
            this.BTNRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.BTNRefresh.Name = "BTNRefresh";
            this.BTNRefresh.Size = new System.Drawing.Size(100, 94);
            this.BTNRefresh.TabIndex = 9;
            this.BTNRefresh.Text = "رفرش";
            this.BTNRefresh.UseVisualStyleBackColor = true;
            this.BTNRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // NUDTalar
            // 
            this.NUDTalar.Enabled = false;
            this.NUDTalar.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.NUDTalar.Location = new System.Drawing.Point(1205, 15);
            this.NUDTalar.Margin = new System.Windows.Forms.Padding(4);
            this.NUDTalar.Name = "NUDTalar";
            this.NUDTalar.Size = new System.Drawing.Size(131, 30);
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
            this.label2.Location = new System.Drawing.Point(1617, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "شماره تالار:";
            // 
            // BTNSend
            // 
            this.BTNSend.Enabled = false;
            this.BTNSend.Location = new System.Drawing.Point(125, 482);
            this.BTNSend.Margin = new System.Windows.Forms.Padding(4);
            this.BTNSend.Name = "BTNSend";
            this.BTNSend.Size = new System.Drawing.Size(135, 94);
            this.BTNSend.TabIndex = 5;
            this.BTNSend.Text = "ENTER برای ارسال";
            this.BTNSend.UseVisualStyleBackColor = true;
            this.BTNSend.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(1152, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "کلید:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 27);
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1464, 618);
            this.tabControl1.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.راهنماToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1464, 30);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // راهنماToolStripMenuItem
            // 
            this.راهنماToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.راهنماToolStripMenuItem1,
            this.نسخجدیدToolStripMenuItem,
            this.دربارهبرنامهToolStripMenuItem});
            this.راهنماToolStripMenuItem.Name = "راهنماToolStripMenuItem";
            this.راهنماToolStripMenuItem.Size = new System.Drawing.Size(76, 26);
            this.راهنماToolStripMenuItem.Text = "اطلاعات";
            this.راهنماToolStripMenuItem.Click += new System.EventHandler(this.راهنماToolStripMenuItem_Click);
            // 
            // راهنماToolStripMenuItem1
            // 
            this.راهنماToolStripMenuItem1.Name = "راهنماToolStripMenuItem1";
            this.راهنماToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.راهنماToolStripMenuItem1.Text = "راهنما";
            // 
            // دربارهبرنامهToolStripMenuItem
            // 
            this.دربارهبرنامهToolStripMenuItem.Name = "دربارهبرنامهToolStripMenuItem";
            this.دربارهبرنامهToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.دربارهبرنامهToolStripMenuItem.Text = "درباره برنامه";
            this.دربارهبرنامهToolStripMenuItem.Click += new System.EventHandler(this.دربارهبرنامهToolStripMenuItem_Click);
            // 
            // نسخجدیدToolStripMenuItem
            // 
            this.نسخجدیدToolStripMenuItem.Name = "نسخجدیدToolStripMenuItem";
            this.نسخجدیدToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.نسخجدیدToolStripMenuItem.Text = "نسخه جدید";
            this.نسخجدیدToolStripMenuItem.Click += new System.EventHandler(this.نسخجدیدToolStripMenuItem_Click);
            // 
            // BTNCleanOldMessages
            // 
            this.BTNCleanOldMessages.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.BTNCleanOldMessages.Location = new System.Drawing.Point(21, 9);
            this.BTNCleanOldMessages.Margin = new System.Windows.Forms.Padding(4);
            this.BTNCleanOldMessages.Name = "BTNCleanOldMessages";
            this.BTNCleanOldMessages.Size = new System.Drawing.Size(249, 40);
            this.BTNCleanOldMessages.TabIndex = 17;
            this.BTNCleanOldMessages.Text = "حذف پیام های قدیمی";
            this.BTNCleanOldMessages.UseVisualStyleBackColor = true;
            this.BTNCleanOldMessages.Click += new System.EventHandler(this.BTNCleanOldMessages_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 31);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1456, 583);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ارسال و دریافت B";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 31);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1456, 583);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "برداشتن کنترل ها";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // FRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1464, 831);
            this.Controls.Add(this.LB);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FRMMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-";
            this.Load += new System.EventHandler(this.FRMMain_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTalar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.ListBox LB;
		private System.Windows.Forms.Timer TimerLoadingMSG;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnKillSession;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TextBox TXTKey;
		private System.Windows.Forms.TextBox TXTUserName;
		private System.Windows.Forms.RichTextBox ReadyBox;
		private System.Windows.Forms.RichTextBox RTBChatBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button BTNLogin;
		private System.Windows.Forms.Label username;
		private System.Windows.Forms.Button BTNRefresh;
		private System.Windows.Forms.NumericUpDown NUDTalar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BTNSend;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem راهنماToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem راهنماToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem دربارهبرنامهToolStripMenuItem;
		private System.Windows.Forms.Button BTNCleanOldMessages;
		private System.Windows.Forms.ToolStripMenuItem نسخجدیدToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
    }
}

