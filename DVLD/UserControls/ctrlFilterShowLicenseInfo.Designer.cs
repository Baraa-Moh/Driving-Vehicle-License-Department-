namespace DVLD.UserControls
{
    partial class ctrlFilterShowLicenseInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlFilterLicenses1 = new DVLD.UserControls.ctrlFilterLicenses();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlLicenseInfo1 = new DVLD.UserControls.ctrlLicenseInfo();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlFilterLicenses1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(651, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // ctrlFilterLicenses1
            // 
            this.ctrlFilterLicenses1.Location = new System.Drawing.Point(0, 13);
            this.ctrlFilterLicenses1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlFilterLicenses1.Name = "ctrlFilterLicenses1";
            this.ctrlFilterLicenses1.Size = new System.Drawing.Size(647, 81);
            this.ctrlFilterLicenses1.TabIndex = 0;
            this.ctrlFilterLicenses1.OnLicenseFound += new System.Action<Common.License>(this.ctrlFilterLicenses1_OnLicenseFound);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlLicenseInfo1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(990, 287);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driver License Info";
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(1, 11);
            this.ctrlLicenseInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(1026, 264);
            this.ctrlLicenseInfo1.TabIndex = 0;
            // 
            // ctrlFilterShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlFilterShowLicenseInfo";
            this.Size = new System.Drawing.Size(1040, 434);
            this.Load += new System.EventHandler(this.ctrlFilterShowLicenseInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ctrlFilterLicenses ctrlFilterLicenses1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ctrlLicenseInfo ctrlLicenseInfo1;
    }
}
