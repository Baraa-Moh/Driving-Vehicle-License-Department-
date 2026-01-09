namespace DVLD.Applications.DrivingLicenses
{
    partial class IssueDrivingLicenseForFirstTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueDrivingLicenseForFirstTime));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrLDLApplicationInfo1 = new DVLD.UserControls.ctrLDLApplicationInfo();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlAppBasicInfo1 = new DVLD.UserControls.ctrlAppBasicInfo();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btIssue = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrLDLApplicationInfo1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driving License App Info";
            // 
            // ctrLDLApplicationInfo1
            // 
            this.ctrLDLApplicationInfo1.Location = new System.Drawing.Point(7, 20);
            this.ctrLDLApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrLDLApplicationInfo1.Name = "ctrLDLApplicationInfo1";
            this.ctrLDLApplicationInfo1.Size = new System.Drawing.Size(896, 130);
            this.ctrLDLApplicationInfo1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlAppBasicInfo1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(954, 270);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Basic Info";
            // 
            // ctrlAppBasicInfo1
            // 
            this.ctrlAppBasicInfo1.Location = new System.Drawing.Point(7, 20);
            this.ctrlAppBasicInfo1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlAppBasicInfo1.Name = "ctrlAppBasicInfo1";
            this.ctrlAppBasicInfo1.Size = new System.Drawing.Size(937, 240);
            this.ctrlAppBasicInfo1.TabIndex = 0;
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(130, 491);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(836, 118);
            this.tbNotes.TabIndex = 85;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD.Properties.Resources.Notes_32;
            this.pictureBox10.Location = new System.Drawing.Point(82, 489);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(32, 23);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 84;
            this.pictureBox10.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 489);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 18);
            this.label10.TabIndex = 83;
            this.label10.Text = "Notes:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(703, 648);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(118, 33);
            this.btClose.TabIndex = 86;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btIssue
            // 
            this.btIssue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIssue.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.btIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIssue.Location = new System.Drawing.Point(838, 648);
            this.btIssue.Name = "btIssue";
            this.btIssue.Size = new System.Drawing.Size(118, 33);
            this.btIssue.TabIndex = 87;
            this.btIssue.Text = "Issue";
            this.btIssue.UseVisualStyleBackColor = true;
            this.btIssue.Click += new System.EventHandler(this.btIssue_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox1.Location = new System.Drawing.Point(226, 623);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 89;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 623);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 88;
            this.label1.Text = "Issue Fees:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbFees
            // 
            this.lbFees.AutoSize = true;
            this.lbFees.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFees.Location = new System.Drawing.Point(279, 627);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(38, 14);
            this.lbFees.TabIndex = 90;
            this.lbFees.Text = "154?";
            // 
            // IssueDrivingLicenseForFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 693);
            this.Controls.Add(this.lbFees);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btIssue);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "IssueDrivingLicenseForFirstTime";
            this.Text = "Issue Driving License For the First Time";
            this.Load += new System.EventHandler(this.IssueDrivingLicenseForFirstTime_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.ctrLDLApplicationInfo ctrLDLApplicationInfo1;
        private System.Windows.Forms.GroupBox groupBox2;
        private UserControls.ctrlAppBasicInfo ctrlAppBasicInfo1;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btIssue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFees;
    }
}