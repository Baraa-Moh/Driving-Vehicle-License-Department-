namespace DVLD.Applications.DrivingLicenses
{
    partial class DetainLicense
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
            this.ctrlDetainInfo1 = new DVLD.UserControls.ctrlDetainInfo();
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llbShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btDetain = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(391, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detain License";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlDetainInfo1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 508);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 144);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain Info";
            // 
            // ctrlDetainInfo1
            // 
            this.ctrlDetainInfo1.Location = new System.Drawing.Point(7, 20);
            this.ctrlDetainInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlDetainInfo1.Name = "ctrlDetainInfo1";
            this.ctrlDetainInfo1.Size = new System.Drawing.Size(754, 116);
            this.ctrlDetainInfo1.TabIndex = 0;
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.Enabled = false;
            this.llbShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(180, 673);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(137, 18);
            this.llbShowLicenseInfo.TabIndex = 56;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "ShowLicenseInfo";
            this.llbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseInfo_LinkClicked);
            // 
            // llbShowLicensesHistory
            // 
            this.llbShowLicensesHistory.AutoSize = true;
            this.llbShowLicensesHistory.Enabled = false;
            this.llbShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicensesHistory.Location = new System.Drawing.Point(12, 673);
            this.llbShowLicensesHistory.Name = "llbShowLicensesHistory";
            this.llbShowLicensesHistory.Size = new System.Drawing.Size(169, 18);
            this.llbShowLicensesHistory.TabIndex = 55;
            this.llbShowLicensesHistory.TabStop = true;
            this.llbShowLicensesHistory.Text = "ShowLicensesHistory";
            this.llbShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicensesHistory_LinkClicked);
            // 
            // btDetain
            // 
            this.btDetain.Enabled = false;
            this.btDetain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDetain.Image = global::DVLD.Properties.Resources.International_32;
            this.btDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDetain.Location = new System.Drawing.Point(919, 658);
            this.btDetain.Name = "btDetain";
            this.btDetain.Size = new System.Drawing.Size(118, 33);
            this.btDetain.TabIndex = 54;
            this.btDetain.Text = "Detain";
            this.btDetain.UseVisualStyleBackColor = true;
            this.btDetain.Click += new System.EventHandler(this.btDetain_Click);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(789, 658);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(118, 33);
            this.btClose.TabIndex = 53;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ctrlFilterShowLicenseInfo1
            // 
            this.ctrlFilterShowLicenseInfo1.EnableFilter = true;
            this.ctrlFilterShowLicenseInfo1.Location = new System.Drawing.Point(12, 67);
            this.ctrlFilterShowLicenseInfo1.Name = "ctrlFilterShowLicenseInfo1";
            this.ctrlFilterShowLicenseInfo1.Size = new System.Drawing.Size(1035, 434);
            this.ctrlFilterShowLicenseInfo1.TabIndex = 1;
            this.ctrlFilterShowLicenseInfo1.OnLicenseFound += new System.Action<Common.License>(this.ctrlFilterShowLicenseInfo1_OnLicenseFound);
            // 
            // DetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 700);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.llbShowLicensesHistory);
            this.Controls.Add(this.btDetain);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlFilterShowLicenseInfo1);
            this.Controls.Add(this.label1);
            this.Name = "DetainLicense";
            this.Text = "Detain License";
            this.Load += new System.EventHandler(this.DetainLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UserControls.ctrlFilterShowLicenseInfo ctrlFilterShowLicenseInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ctrlDetainInfo ctrlDetainInfo1;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llbShowLicensesHistory;
        private System.Windows.Forms.Button btDetain;
        private System.Windows.Forms.Button btClose;
    }
}