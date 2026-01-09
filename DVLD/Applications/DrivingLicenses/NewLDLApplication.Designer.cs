namespace DVLD.Applications.DrivingLicenses
{
    partial class NewLDLApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pPersonInfo = new System.Windows.Forms.TabPage();
            this.btNext = new System.Windows.Forms.Button();
            this.ctrlFindShowPersonDetails1 = new DVLD.UserControls.ctrlFindShowPersonDetails();
            this.pApplicationInfo = new System.Windows.Forms.TabPage();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbClasses = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLDLApplicationID = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.pPersonInfo.SuspendLayout();
            this.pApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTitle.Location = new System.Drawing.Point(205, 21);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(823, 58);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "New Local Driving License Application";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pPersonInfo);
            this.tabControl1.Controls.Add(this.pApplicationInfo);
            this.tabControl1.Location = new System.Drawing.Point(12, 105);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1151, 554);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // pPersonInfo
            // 
            this.pPersonInfo.Controls.Add(this.btNext);
            this.pPersonInfo.Controls.Add(this.ctrlFindShowPersonDetails1);
            this.pPersonInfo.Location = new System.Drawing.Point(4, 22);
            this.pPersonInfo.Name = "pPersonInfo";
            this.pPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pPersonInfo.Size = new System.Drawing.Size(1143, 528);
            this.pPersonInfo.TabIndex = 0;
            this.pPersonInfo.Text = "PersonInformation";
            this.pPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btNext
            // 
            this.btNext.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNext.Image = global::DVLD.Properties.Resources.Next_32;
            this.btNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNext.Location = new System.Drawing.Point(1018, 476);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(118, 33);
            this.btNext.TabIndex = 42;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // ctrlFindShowPersonDetails1
            // 
            this.ctrlFindShowPersonDetails1.EnableFilter = true;
            this.ctrlFindShowPersonDetails1.Location = new System.Drawing.Point(6, 6);
            this.ctrlFindShowPersonDetails1.Name = "ctrlFindShowPersonDetails1";
            this.ctrlFindShowPersonDetails1.PersonID = -1;
            this.ctrlFindShowPersonDetails1.Size = new System.Drawing.Size(1137, 526);
            this.ctrlFindShowPersonDetails1.TabIndex = 0;
            this.ctrlFindShowPersonDetails1.OnPersonFound += new System.Action<int>(this.ctrlFindShowPersonDetails1_OnPersonFound);
            // 
            // pApplicationInfo
            // 
            this.pApplicationInfo.Controls.Add(this.lbCreatedBy);
            this.pApplicationInfo.Controls.Add(this.pictureBox4);
            this.pApplicationInfo.Controls.Add(this.label6);
            this.pApplicationInfo.Controls.Add(this.lbFees);
            this.pApplicationInfo.Controls.Add(this.pictureBox3);
            this.pApplicationInfo.Controls.Add(this.label5);
            this.pApplicationInfo.Controls.Add(this.pictureBox2);
            this.pApplicationInfo.Controls.Add(this.cbClasses);
            this.pApplicationInfo.Controls.Add(this.label1);
            this.pApplicationInfo.Controls.Add(this.lbApplicationDate);
            this.pApplicationInfo.Controls.Add(this.pictureBox1);
            this.pApplicationInfo.Controls.Add(this.label3);
            this.pApplicationInfo.Controls.Add(this.lbLDLApplicationID);
            this.pApplicationInfo.Controls.Add(this.pictureBox7);
            this.pApplicationInfo.Controls.Add(this.label2);
            this.pApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.pApplicationInfo.Name = "pApplicationInfo";
            this.pApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pApplicationInfo.Size = new System.Drawing.Size(1143, 528);
            this.pApplicationInfo.TabIndex = 1;
            this.pApplicationInfo.Text = "Application Info";
            this.pApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(288, 217);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(129, 23);
            this.lbCreatedBy.TabIndex = 41;
            this.lbCreatedBy.Text = "????";
            this.lbCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.User_32__2;
            this.pictureBox4.Location = new System.Drawing.Point(224, 214);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 29);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 40;
            this.pictureBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 23);
            this.label6.TabIndex = 39;
            this.label6.Text = "Created By:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFees
            // 
            this.lbFees.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFees.Location = new System.Drawing.Point(288, 183);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(129, 23);
            this.lbFees.TabIndex = 38;
            this.lbFees.Text = "????";
            this.lbFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(224, 180);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 37;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 23);
            this.label5.TabIndex = 36;
            this.label5.Text = "Application Fees:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Renew_Driving_License_321;
            this.pictureBox2.Location = new System.Drawing.Point(224, 146);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // cbClasses
            // 
            this.cbClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasses.FormattingEnabled = true;
            this.cbClasses.Location = new System.Drawing.Point(292, 146);
            this.cbClasses.Name = "cbClasses";
            this.cbClasses.Size = new System.Drawing.Size(247, 21);
            this.cbClasses.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "License Class:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationDate.Location = new System.Drawing.Point(288, 112);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(129, 23);
            this.lbApplicationDate.TabIndex = 32;
            this.lbApplicationDate.Text = "????";
            this.lbApplicationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(224, 109);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "Application Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLDLApplicationID
            // 
            this.lbLDLApplicationID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLDLApplicationID.Location = new System.Drawing.Point(288, 78);
            this.lbLDLApplicationID.Name = "lbLDLApplicationID";
            this.lbLDLApplicationID.Size = new System.Drawing.Size(129, 23);
            this.lbLDLApplicationID.TabIndex = 29;
            this.lbLDLApplicationID.Text = "????";
            this.lbLDLApplicationID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox7.Location = new System.Drawing.Point(224, 75);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(26, 29);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 28;
            this.pictureBox7.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "D.L Application:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(1034, 683);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(118, 33);
            this.btSave.TabIndex = 40;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(910, 683);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(118, 33);
            this.btClose.TabIndex = 39;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click_1);
            // 
            // NewLDLApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 727);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbTitle);
            this.Name = "NewLDLApplication";
            this.Text = "New Local Driving License Application";
            this.Load += new System.EventHandler(this.NewLocalDrivingLicenseApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.pPersonInfo.ResumeLayout(false);
            this.pApplicationInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pPersonInfo;
        private System.Windows.Forms.TabPage pApplicationInfo;
        private UserControls.ctrlFindShowPersonDetails ctrlFindShowPersonDetails1;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLDLApplicationID;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbClasses;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbFees;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btNext;
    }
}