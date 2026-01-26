namespace DVLD.Applications
{
    partial class ReleaseDetain
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
            this.Label1 = new System.Windows.Forms.Label();
            this.ctrlFilterShowLicenseInfo1 = new DVLD.UserControls.ctrlFilterShowLicenseInfo();
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llbShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btRelease = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlReleaseDetainInfo1 = new DVLD.UserControls.ctrlReleaseDetainInfo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label1.Location = new System.Drawing.Point(264, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(493, 45);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Release Detained License";
            // 
            // ctrlFilterShowLicenseInfo1
            // 
            this.ctrlFilterShowLicenseInfo1.EnableFilter = true;
            this.ctrlFilterShowLicenseInfo1.Location = new System.Drawing.Point(12, 57);
            this.ctrlFilterShowLicenseInfo1.Name = "ctrlFilterShowLicenseInfo1";
            this.ctrlFilterShowLicenseInfo1.Size = new System.Drawing.Size(1040, 424);
            this.ctrlFilterShowLicenseInfo1.TabIndex = 1;
            this.ctrlFilterShowLicenseInfo1.OnLicenseFound += new System.Action<Common.License>(this.ctrlFilterShowLicenseInfo1_OnLicenseFound);
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.Enabled = false;
            this.llbShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(184, 695);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(137, 18);
            this.llbShowLicenseInfo.TabIndex = 60;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "ShowLicenseInfo";
            // 
            // llbShowLicensesHistory
            // 
            this.llbShowLicensesHistory.AutoSize = true;
            this.llbShowLicensesHistory.Enabled = false;
            this.llbShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicensesHistory.Location = new System.Drawing.Point(16, 695);
            this.llbShowLicensesHistory.Name = "llbShowLicensesHistory";
            this.llbShowLicensesHistory.Size = new System.Drawing.Size(169, 18);
            this.llbShowLicensesHistory.TabIndex = 59;
            this.llbShowLicensesHistory.TabStop = true;
            this.llbShowLicensesHistory.Text = "ShowLicensesHistory";
            // 
            // btRelease
            // 
            this.btRelease.Enabled = false;
            this.btRelease.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRelease.Image = global::DVLD.Properties.Resources.Release_Detained_License_32;
            this.btRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRelease.Location = new System.Drawing.Point(923, 680);
            this.btRelease.Name = "btRelease";
            this.btRelease.Size = new System.Drawing.Size(129, 33);
            this.btRelease.TabIndex = 58;
            this.btRelease.Text = "Release";
            this.btRelease.UseVisualStyleBackColor = true;
            this.btRelease.Click += new System.EventHandler(this.btRelease_Click);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(793, 680);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(118, 33);
            this.btClose.TabIndex = 57;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlReleaseDetainInfo1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 487);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1040, 187);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain Info";
            // 
            // ctrlReleaseDetainInfo1
            // 
            this.ctrlReleaseDetainInfo1.Location = new System.Drawing.Point(24, 20);
            this.ctrlReleaseDetainInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlReleaseDetainInfo1.Name = "ctrlReleaseDetainInfo1";
            this.ctrlReleaseDetainInfo1.Size = new System.Drawing.Size(758, 154);
            this.ctrlReleaseDetainInfo1.TabIndex = 0;
            // 
            // ReleaseDetain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 719);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.llbShowLicensesHistory);
            this.Controls.Add(this.btRelease);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.ctrlFilterShowLicenseInfo1);
            this.Controls.Add(this.Label1);
            this.Name = "ReleaseDetain";
            this.Text = "ReleaseDetain";
            this.Load += new System.EventHandler(this.ReleaseDetain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private UserControls.ctrlFilterShowLicenseInfo ctrlFilterShowLicenseInfo1;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llbShowLicensesHistory;
        private System.Windows.Forms.Button btRelease;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ctrlReleaseDetainInfo ctrlReleaseDetainInfo1;
    }
}