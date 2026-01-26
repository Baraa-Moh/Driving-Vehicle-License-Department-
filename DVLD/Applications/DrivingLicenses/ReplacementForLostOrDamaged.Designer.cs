namespace DVLD.Applications.DrivingLicenses
{
    partial class ReplacementForLostOrDamaged
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlAppBasicInfo1 = new DVLD.UserControls.ctrlAppBasicInfo();
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llbShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btIssue = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.lbTotalFees = new System.Windows.Forms.Label();
            this.lb4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ctrlFilterShowLicenseInfo1 = new DVLD.UserControls.ctrlFilterShowLicenseInfo();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTitle.Location = new System.Drawing.Point(269, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(671, 45);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Replacement For Damaged License";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLostLicense);
            this.groupBox1.Controls.Add(this.rbDamagedLicense);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(704, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement For:";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLostLicense.Location = new System.Drawing.Point(16, 54);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(100, 18);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_Click);
            this.rbLostLicense.Click += new System.EventHandler(this.rbDamagedLicense_Click);
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDamagedLicense.Location = new System.Drawing.Point(16, 31);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(130, 18);
            this.rbDamagedLicense.TabIndex = 0;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_Click);
            this.rbDamagedLicense.Click += new System.EventHandler(this.rbDamagedLicense_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlAppBasicInfo1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 508);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1062, 267);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info";
            // 
            // ctrlAppBasicInfo1
            // 
            this.ctrlAppBasicInfo1.Location = new System.Drawing.Point(1, 20);
            this.ctrlAppBasicInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlAppBasicInfo1.Name = "ctrlAppBasicInfo1";
            this.ctrlAppBasicInfo1.Size = new System.Drawing.Size(1050, 240);
            this.ctrlAppBasicInfo1.TabIndex = 4;
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.Enabled = false;
            this.llbShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(189, 799);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(137, 18);
            this.llbShowLicenseInfo.TabIndex = 49;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "ShowLicenseInfo";
            this.llbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseInfo_LinkClicked);
            // 
            // llbShowLicensesHistory
            // 
            this.llbShowLicensesHistory.AutoSize = true;
            this.llbShowLicensesHistory.Enabled = false;
            this.llbShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicensesHistory.Location = new System.Drawing.Point(14, 799);
            this.llbShowLicensesHistory.Name = "llbShowLicensesHistory";
            this.llbShowLicensesHistory.Size = new System.Drawing.Size(169, 18);
            this.llbShowLicensesHistory.TabIndex = 48;
            this.llbShowLicensesHistory.TabStop = true;
            this.llbShowLicensesHistory.Text = "ShowLicensesHistory";
            this.llbShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicensesHistory_LinkClicked);
            // 
            // btIssue
            // 
            this.btIssue.Enabled = false;
            this.btIssue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIssue.Image = global::DVLD.Properties.Resources.International_32;
            this.btIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIssue.Location = new System.Drawing.Point(953, 784);
            this.btIssue.Name = "btIssue";
            this.btIssue.Size = new System.Drawing.Size(118, 33);
            this.btIssue.TabIndex = 47;
            this.btIssue.Text = "Issue";
            this.btIssue.UseVisualStyleBackColor = true;
            this.btIssue.Click += new System.EventHandler(this.btIssue_Click);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(822, 784);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(118, 33);
            this.btClose.TabIndex = 46;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lbTotalFees
            // 
            this.lbTotalFees.AutoSize = true;
            this.lbTotalFees.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalFees.Location = new System.Drawing.Point(758, 790);
            this.lbTotalFees.Name = "lbTotalFees";
            this.lbTotalFees.Size = new System.Drawing.Size(35, 16);
            this.lbTotalFees.TabIndex = 52;
            this.lbTotalFees.Text = "????";
            // 
            // lb4
            // 
            this.lb4.AutoSize = true;
            this.lb4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb4.Location = new System.Drawing.Point(628, 792);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(86, 18);
            this.lb4.TabIndex = 51;
            this.lb4.Text = "TotalFees:";
            this.lb4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(720, 788);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 50;
            this.pictureBox3.TabStop = false;
            // 
            // ctrlFilterShowLicenseInfo1
            // 
            this.ctrlFilterShowLicenseInfo1.EnableFilter = true;
            this.ctrlFilterShowLicenseInfo1.Location = new System.Drawing.Point(12, 79);
            this.ctrlFilterShowLicenseInfo1.Name = "ctrlFilterShowLicenseInfo1";
            this.ctrlFilterShowLicenseInfo1.Size = new System.Drawing.Size(1034, 434);
            this.ctrlFilterShowLicenseInfo1.TabIndex = 1;
            this.ctrlFilterShowLicenseInfo1.OnLicenseFound += new System.Action<Common.License>(this.ctrlFilterShowLicenseInfo1_OnLicenseFound);
            // 
            // ReplacementForLostOrDamaged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 819);
            this.Controls.Add(this.lbTotalFees);
            this.Controls.Add(this.lb4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.llbShowLicensesHistory);
            this.Controls.Add(this.btIssue);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlFilterShowLicenseInfo1);
            this.Controls.Add(this.lbTitle);
            this.Name = "ReplacementForLostOrDamaged";
            this.Text = "ReplacementForLostOrDamaged";
            this.Load += new System.EventHandler(this.ReplacementForLostOrDamaged_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private UserControls.ctrlFilterShowLicenseInfo ctrlFilterShowLicenseInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
        private System.Windows.Forms.GroupBox groupBox2;
        private UserControls.ctrlAppBasicInfo ctrlAppBasicInfo1;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llbShowLicensesHistory;
        private System.Windows.Forms.Button btIssue;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lbTotalFees;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}