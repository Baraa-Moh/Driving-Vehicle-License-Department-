namespace DVLD.People
{
    partial class AddUpdatePerson
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNationalNo = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.ctrlEditPersonInfo1 = new DVLD.UserControls.ctrlEditPersonInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTitle.Location = new System.Drawing.Point(382, 22);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(291, 46);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "Add New Person";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Person ID:";
            // 
            // lbPersonID
            // 
            this.lbPersonID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonID.Location = new System.Drawing.Point(190, 92);
            this.lbPersonID.Name = "lbPersonID";
            this.lbPersonID.Size = new System.Drawing.Size(100, 23);
            this.lbPersonID.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(226, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lbNationalNo
            // 
            this.lbNationalNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNationalNo.Location = new System.Drawing.Point(274, 92);
            this.lbNationalNo.Name = "lbNationalNo";
            this.lbNationalNo.Size = new System.Drawing.Size(77, 23);
            this.lbNationalNo.TabIndex = 7;
            this.lbNationalNo.Text = "N/A:";
            // 
            // lbID
            // 
            this.lbID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.Location = new System.Drawing.Point(111, 92);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(109, 23);
            this.lbID.TabIndex = 8;
            // 
            // ctrlEditPersonInfo1
            // 
            this.ctrlEditPersonInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlEditPersonInfo1.Location = new System.Drawing.Point(17, 128);
            this.ctrlEditPersonInfo1.Name = "ctrlEditPersonInfo1";
            this.ctrlEditPersonInfo1.Size = new System.Drawing.Size(1010, 342);
            this.ctrlEditPersonInfo1.TabIndex = 6;
            this.ctrlEditPersonInfo1.onCloseClick += new System.Action<object>(this.ctrlEditPersonInfo1_onCloseClick);
            this.ctrlEditPersonInfo1.onSaveClick += new System.Action<object>(this.ctrlEditPersonInfo1_onSaveClick);
            // 
            // AddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 482);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.lbNationalNo);
            this.Controls.Add(this.ctrlEditPersonInfo1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbPersonID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdatePerson";
            this.Text = "AddUpdatePerson";
            this.Load += new System.EventHandler(this.AddUpdatePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPersonID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UserControls.ctrlEditPersonInfo ctrlEditPersonInfo1;
        private System.Windows.Forms.Label lbNationalNo;
        private System.Windows.Forms.Label lbID;
    }
}