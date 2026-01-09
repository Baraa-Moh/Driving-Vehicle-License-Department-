namespace DVLD.UserControls
{
    partial class ctrlFilterPerson
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.btAddPerson = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By:";
            // 
            // cbFilters
            // 
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Items.AddRange(new object[] {
            "NationalNo",
            "PersonID"});
            this.cbFilters.Location = new System.Drawing.Point(123, 20);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(212, 21);
            this.cbFilters.TabIndex = 1;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(360, 21);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(228, 20);
            this.tbID.TabIndex = 2;
            this.tbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbID_KeyPress);
            // 
            // btAddPerson
            // 
            this.btAddPerson.Image = global::DVLD.Properties.Resources.AddPerson_321;
            this.btAddPerson.Location = new System.Drawing.Point(671, 11);
            this.btAddPerson.Name = "btAddPerson";
            this.btAddPerson.Size = new System.Drawing.Size(53, 37);
            this.btAddPerson.TabIndex = 4;
            this.btAddPerson.UseVisualStyleBackColor = true;
            this.btAddPerson.Click += new System.EventHandler(this.btAddPerson_Click);
            // 
            // btSearch
            // 
            this.btSearch.Image = global::DVLD.Properties.Resources.SearchPerson;
            this.btSearch.Location = new System.Drawing.Point(612, 11);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(53, 37);
            this.btSearch.TabIndex = 3;
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // ctrlFilterPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btAddPerson);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.label1);
            this.Name = "ctrlFilterPerson";
            this.Size = new System.Drawing.Size(965, 64);
            this.Load += new System.EventHandler(this.ctrlFilterPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btAddPerson;
    }
}
