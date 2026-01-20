namespace DVLD.Applications.DrivingLicenses
{
    partial class InternationalLicenseInfo
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlInternationalDrivingLicenseInfo1 = new DVLD.UserControls.ctrlInternationalDrivingLicenseInfo();
            this.btClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.LicenseView_400;
            this.pictureBox1.Location = new System.Drawing.Point(425, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(322, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "International License";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlInternationalDrivingLicenseInfo1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 217);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "International License Info";
            // 
            // ctrlInternationalDrivingLicenseInfo1
            // 
            this.ctrlInternationalDrivingLicenseInfo1.Location = new System.Drawing.Point(7, 20);
            this.ctrlInternationalDrivingLicenseInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlInternationalDrivingLicenseInfo1.Name = "ctrlInternationalDrivingLicenseInfo1";
            this.ctrlInternationalDrivingLicenseInfo1.Size = new System.Drawing.Size(1007, 193);
            this.ctrlInternationalDrivingLicenseInfo1.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(923, 423);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(118, 33);
            this.btClose.TabIndex = 39;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // InternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 463);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "InternationalLicenseInfo";
            this.Text = "InternationalLicenseInfo";
            this.Load += new System.EventHandler(this.InternationalLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ctrlInternationalDrivingLicenseInfo ctrlInternationalDrivingLicenseInfo1;
        private System.Windows.Forms.Button btClose;
    }
}