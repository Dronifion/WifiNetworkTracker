namespace WlanLocationDLPPoc
{
    partial class Form1
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
            this.tmrMonitor = new System.Windows.Forms.Timer(this.components);
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSSID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckbCredit = new System.Windows.Forms.CheckBox();
            this.ckbIC = new System.Windows.Forms.CheckBox();
            this.ckbKeyword = new System.Windows.Forms.CheckBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnCancelPolicy = new System.Windows.Forms.Button();
            this.btnSetPolicy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbRetrieveHash = new System.Windows.Forms.ListBox();
            this.lblRetrieveStatus = new System.Windows.Forms.Label();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.lbRetrieve = new System.Windows.Forms.ListBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrMonitor
            // 
            this.tmrMonitor.Tick += new System.EventHandler(this.tmrMonitor_Tick);
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "Sensitive.txt";
            this.fileDialog.InitialDirectory = "C:\\Users\\Lester\\Desktop\\MOSTI bDLP P Meeting\\Patent 1 - Location based DLP\\WlanLo" +
                "cationDLPPoc\\LocationDLPPoc\\";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 387);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(559, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Step 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtSSID);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(20, 240);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(521, 67);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Define Wireless LAN Information";
            // 
            // txtSSID
            // 
            this.txtSSID.Location = new System.Drawing.Point(60, 19);
            this.txtSSID.Name = "txtSSID";
            this.txtSSID.Size = new System.Drawing.Size(411, 20);
            this.txtSSID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SSID:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckbCredit);
            this.groupBox4.Controls.Add(this.ckbIC);
            this.groupBox4.Controls.Add(this.ckbKeyword);
            this.groupBox4.Controls.Add(this.txtKeyword);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(20, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(521, 92);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Define Sensitive Data";
            // 
            // ckbCredit
            // 
            this.ckbCredit.AutoSize = true;
            this.ckbCredit.Checked = true;
            this.ckbCredit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCredit.Location = new System.Drawing.Point(256, 62);
            this.ckbCredit.Name = "ckbCredit";
            this.ckbCredit.Size = new System.Drawing.Size(118, 17);
            this.ckbCredit.TabIndex = 4;
            this.ckbCredit.Text = "Credit Card Number";
            this.ckbCredit.UseVisualStyleBackColor = true;
            // 
            // ckbIC
            // 
            this.ckbIC.AutoSize = true;
            this.ckbIC.Checked = true;
            this.ckbIC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIC.Location = new System.Drawing.Point(139, 62);
            this.ckbIC.Name = "ckbIC";
            this.ckbIC.Size = new System.Drawing.Size(76, 17);
            this.ckbIC.TabIndex = 3;
            this.ckbIC.Text = "IC Number";
            this.ckbIC.UseVisualStyleBackColor = true;
            // 
            // ckbKeyword
            // 
            this.ckbKeyword.AutoSize = true;
            this.ckbKeyword.Checked = true;
            this.ckbKeyword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbKeyword.Location = new System.Drawing.Point(24, 62);
            this.ckbKeyword.Name = "ckbKeyword";
            this.ckbKeyword.Size = new System.Drawing.Size(67, 17);
            this.ckbKeyword.TabIndex = 2;
            this.ckbKeyword.Text = "Keyword";
            this.ckbKeyword.UseVisualStyleBackColor = true;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(124, 21);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(375, 20);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.Text = "Confidential";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sensitive Keyword:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFilename);
            this.groupBox3.Controls.Add(this.btnOpenFile);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(20, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(521, 65);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Define Sensitive Data Location";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(151, 19);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(320, 20);
            this.txtFilename.TabIndex = 11;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(477, 19);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(32, 23);
            this.btnOpenFile.TabIndex = 10;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sensitive Data Location: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Step 1 - Define Security Policy (In the server)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnCancelPolicy);
            this.tabPage2.Controls.Add(this.btnSetPolicy);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(559, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.txtInfo);
            this.groupBox2.Location = new System.Drawing.Point(20, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 269);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Location Monitoring Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(18, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(482, 30);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(21, 52);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(479, 201);
            this.txtInfo.TabIndex = 4;
            // 
            // btnCancelPolicy
            // 
            this.btnCancelPolicy.Location = new System.Drawing.Point(285, 57);
            this.btnCancelPolicy.Name = "btnCancelPolicy";
            this.btnCancelPolicy.Size = new System.Drawing.Size(254, 23);
            this.btnCancelPolicy.TabIndex = 5;
            this.btnCancelPolicy.Text = "Click here to stop the monitoring process";
            this.btnCancelPolicy.UseVisualStyleBackColor = true;
            this.btnCancelPolicy.Click += new System.EventHandler(this.btnCancelPolicy_Click);
            // 
            // btnSetPolicy
            // 
            this.btnSetPolicy.Location = new System.Drawing.Point(20, 57);
            this.btnSetPolicy.Name = "btnSetPolicy";
            this.btnSetPolicy.Size = new System.Drawing.Size(259, 23);
            this.btnSetPolicy.TabIndex = 4;
            this.btnSetPolicy.Text = "Click here to start the monitoring process";
            this.btnSetPolicy.UseVisualStyleBackColor = true;
            this.btnSetPolicy.Click += new System.EventHandler(this.btnSetPolicy_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Step 2 - Start the monitoring process. (At the endpoint)";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbRetrieveHash);
            this.tabPage3.Controls.Add(this.lblRetrieveStatus);
            this.tabPage3.Controls.Add(this.btnRetrieve);
            this.tabPage3.Controls.Add(this.lbRetrieve);
            this.tabPage3.Controls.Add(this.btnLogin);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(559, 361);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbRetrieveHash
            // 
            this.lbRetrieveHash.FormattingEnabled = true;
            this.lbRetrieveHash.Location = new System.Drawing.Point(335, 130);
            this.lbRetrieveHash.Name = "lbRetrieveHash";
            this.lbRetrieveHash.Size = new System.Drawing.Size(181, 95);
            this.lbRetrieveHash.TabIndex = 16;
            this.lbRetrieveHash.Visible = false;
            // 
            // lblRetrieveStatus
            // 
            this.lblRetrieveStatus.AutoSize = true;
            this.lblRetrieveStatus.Location = new System.Drawing.Point(17, 92);
            this.lblRetrieveStatus.Name = "lblRetrieveStatus";
            this.lblRetrieveStatus.Size = new System.Drawing.Size(37, 13);
            this.lblRetrieveStatus.TabIndex = 15;
            this.lblRetrieveStatus.Text = "Status";
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Enabled = false;
            this.btnRetrieve.Location = new System.Drawing.Point(20, 318);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(520, 29);
            this.btnRetrieve.TabIndex = 14;
            this.btnRetrieve.Text = "Click here to retrieve file (Decryption)";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // lbRetrieve
            // 
            this.lbRetrieve.Enabled = false;
            this.lbRetrieve.FormattingEnabled = true;
            this.lbRetrieve.HorizontalScrollbar = true;
            this.lbRetrieve.Location = new System.Drawing.Point(20, 117);
            this.lbRetrieve.Name = "lbRetrieve";
            this.lbRetrieve.Size = new System.Drawing.Size(520, 186);
            this.lbRetrieve.TabIndex = 13;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(20, 56);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(520, 29);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "Click here to login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(311, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Step 3 - Retrieve the encrypted file on demand. (At the endpoint)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 408);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DLP Agent Function (Wireless Network Location Tracking) POC";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMonitor;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtSSID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ckbCredit;
        private System.Windows.Forms.CheckBox ckbIC;
        private System.Windows.Forms.CheckBox ckbKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnCancelPolicy;
        private System.Windows.Forms.Button btnSetPolicy;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lbRetrieveHash;
        private System.Windows.Forms.Label lblRetrieveStatus;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ListBox lbRetrieve;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

