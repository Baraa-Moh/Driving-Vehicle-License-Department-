namespace DVLD.Applications.DrivingLicenses
{
    partial class NewInternationalLicenseApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlAppBasicInfo1 = new DVLD.UserControls.ctrlAppBasicInfo();
            this.llbShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btIssue = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.ctrlFilterShowLicenseInfo1 = new DVLD.UserControls.ctrlFilterShowLicenseInfo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(188, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(636, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "International License Application";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlAppBasicInfo1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 514);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(999, 256);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Basic Info";
            // 
            // ctrlAppBasicInfo1
            // 
            this.ctrlAppBasicInfo1.Location = new System.Drawing.Point(7, 13);
            this.ctrlAppBasicInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlAppBasicInfo1.Name = "ctrlAppBasicInfo1";
            this.ctrlAppBasicInfo1.Size = new System.Drawing.Size(959, 237);
            this.ctrlAppBasicInfo1.TabIndex = 0;
            // 
            // llbShowLicensesHistory
            // 
            this.llbShowLicensesHistory.AutoSize = true;
            this.llbShowLicensesHistory.Enabled = false;
            this.llbShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicensesHistory.Location = new System.Drawing.Point(18, 784);
            this.llbShowLicensesHistory.Name = "llbShowLicensesHistory";
            this.llbShowLicensesHistory.Size = new System.Drawing.Size(169, 18);
            this.llbShowLicensesHistory.TabIndex = 40;
            this.llbShowLicensesHistory.TabStop = true;
            this.llbShowLicensesHistory.Text = "ShowLicensesHistory";
            this.llbShowLicensesHistory.Click += new System.EventHandler(this.llbShowLicensesHistory_Click);
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.Enabled = false;
            this.llbShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(193, 784);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(137, 18);
            this.llbShowLicenseInfo.TabIndex = 41;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "ShowLicenseInfo";
            this.llbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseInfo_LinkClicked);
            // 
            // btIssue
            // 
            this.btIssue.Enabled = false;
            this.btIssue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIssue.Image = global::DVLD.Properties.Resources.International_32;
            this.btIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIssue.Location = new System.Drawing.Point(896, 776);
            this.btIssue.Name = "btIssue";
            this.btIssue.Size = new System.Drawing.Size(118, 33);
            this.btIssue.TabIndex = 39;
            this.btIssue.Text = "Issue";
            this.btIssue.UseVisualStyleBackColor = true;
            this.btIssue.Click += new System.EventHandler(this.btIssue_Click);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(758, 776);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(118, 33);
            this.btClose.TabIndex = 38;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ctrlFilterShowLicenseInfo1
            // 
            this.ctrlFilterShowLicenseInfo1.EnableFilter = true;
            this.ctrlFilterShowLicenseInfo1.Location = new System.Drawing.Point(12, 80);
            this.ctrlFilterShowLicenseInfo1.Name = "ctrlFilterShowLicenseInfo1";
            this.ctrlFilterShowLicenseInfo1.Size = new System.Drawing.Size(1011, 428);
            this.ctrlFilterShowLicenseInfo1.TabIndex = 1;
            this.ctrlFilterShowLicenseInfo1.OnLicenseFound += new System.Action<Common.License>(this.ctrlFilterShowLicenseInfo1_OnLicenseFound);
            // 
            // NewInternationalLicenseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 813);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.llbShowLicensesHistory);
            this.Controls.Add(this.btIssue);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlFilterShowLicenseInfo1);
            this.Controls.Add(this.label1);
            this.Name = "NewInternationalLicenseApp";
            this.Text = "NewInternationalLicenseApp";
            this.Load += new System.EventHandler(this.NewInternationalLicenseApp_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UserControls.ctrlFilterShowLicenseInfo ctrlFilterShowLicenseInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ctrlAppBasicInfo ctrlAppBasicInfo1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btIssue;
        private System.Windows.Forms.LinkLabel llbShowLicensesHistory;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
    }
}