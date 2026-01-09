namespace DVLD.UserControls
{
    partial class ctrlFindShowPersonDetails
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
            this.ctrlFilterPerson1 = new DVLD.UserControls.ctrlFilterPerson();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlPersonDetails1 = new DVLD.UserControls.ctrlPersonDetails();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlFilterPerson1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1126, 84);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // ctrlFilterPerson1
            // 
            this.ctrlFilterPerson1.Location = new System.Drawing.Point(9, 14);
            this.ctrlFilterPerson1.Margin = new System.Windows.Forms.Padding(6);
            this.ctrlFilterPerson1.Name = "ctrlFilterPerson1";
            this.ctrlFilterPerson1.Size = new System.Drawing.Size(1112, 60);
            this.ctrlFilterPerson1.TabIndex = 0;
            this.ctrlFilterPerson1.OnPersonFound += new System.Action<int>(this.ctrlFilterPerson1_OnPersonFound);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlPersonDetails1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1126, 332);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Person Information";
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlPersonDetails1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(7, 25);
            this.ctrlPersonDetails1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(1114, 300);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // ctrlFindShowPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlFindShowPersonDetails";
            this.Size = new System.Drawing.Size(1139, 454);
            this.Load += new System.EventHandler(this.ctrlFindShowPersonDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlFilterPerson ctrlFilterPerson1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ctrlPersonDetails ctrlPersonDetails1;
    }
}
