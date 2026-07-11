namespace DVLD.Applications.DrivingLicenses
{
    partial class LDLApplicationDetails
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
            this.ctrlAppBasicInfo1 = new DVLD.UserControls.ctrlAppBasicInfo();
            this.ctrLDLApplicationInfo1 = new DVLD.UserControls.ctrLDLApplicationInfo();
            this.SuspendLayout();
            // 
            // ctrlAppBasicInfo1
            // 
            this.ctrlAppBasicInfo1.Location = new System.Drawing.Point(0, -1);
            this.ctrlAppBasicInfo1.Name = "ctrlAppBasicInfo1";
            this.ctrlAppBasicInfo1.Size = new System.Drawing.Size(814, 240);
            this.ctrlAppBasicInfo1.TabIndex = 0;
            // 
            // ctrLDLApplicationInfo1
            // 
            this.ctrLDLApplicationInfo1.Location = new System.Drawing.Point(0, 245);
            this.ctrLDLApplicationInfo1.Name = "ctrLDLApplicationInfo1";
            this.ctrLDLApplicationInfo1.Size = new System.Drawing.Size(896, 130);
            this.ctrLDLApplicationInfo1.TabIndex = 1;
            // 
            // LDLApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 548);
            this.Controls.Add(this.ctrLDLApplicationInfo1);
            this.Controls.Add(this.ctrlAppBasicInfo1);
            this.Name = "LDLApplicationDetails";
            this.Text = "LDLApplicationInfo";
            this.Load += new System.EventHandler(this.LDLApplicationDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ctrlAppBasicInfo ctrlAppBasicInfo1;
        private UserControls.ctrLDLApplicationInfo ctrLDLApplicationInfo1;
    }
}