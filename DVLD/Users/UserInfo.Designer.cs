namespace DVLD.Users
{
    partial class UserInfo
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
            this.btClose = new System.Windows.Forms.Button();
            this.ctrlPersonDetails1 = new DVLD.UserControls.ctrlPersonDetails();
            this.ctrlLoginInformation1 = new DVLD.UserControls.ctrlLoginInformation();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(862, 450);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(118, 33);
            this.btClose.TabIndex = 40;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlPersonDetails1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(12, 24);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(968, 280);
            this.ctrlPersonDetails1.TabIndex = 41;
            // 
            // ctrlLoginInformation1
            // 
            this.ctrlLoginInformation1.Location = new System.Drawing.Point(12, 334);
            this.ctrlLoginInformation1.Name = "ctrlLoginInformation1";
            this.ctrlLoginInformation1.Size = new System.Drawing.Size(968, 89);
            this.ctrlLoginInformation1.TabIndex = 42;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 495);
            this.Controls.Add(this.ctrlLoginInformation1);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Controls.Add(this.btClose);
            this.Name = "UserInfo";
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.UserInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private UserControls.ctrlPersonDetails ctrlPersonDetails1;
        private UserControls.ctrlLoginInformation ctrlLoginInformation1;
    }
}