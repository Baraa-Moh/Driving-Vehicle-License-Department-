using Common;
using DVLD_BLL;
using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DVLD.Applications
{
    public partial class EditApplicationType : Form
    {
        private ApplicationType _appType;
        private ApplicationTypeServices _appTypeServices;
        public EditApplicationType(int AppTypeID)
        {
            InitializeComponent();
            _appTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
            _appType = _appTypeServices.GetApplicationType(AppTypeID);  
        }
        private void EditApplicationType_Load(object sender, EventArgs e)
        {
            lbID.Text = _appType.ID.ToString();
            tbTitle.Text = _appType.Title;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Fill()
        {
            _appType.Title = tbTitle.Text;
            _appType.Fees = Convert.ToDouble(tbFees.Text);
        }
        private bool Validate_Fields()
        {
            bool valid = true;
            if(tbTitle.Text.Length < 0)
            {
                valid = false;
                errorProvider1.SetError(tbTitle, "Required");
            }else errorProvider1.SetError(tbTitle, string.Empty);   
            
            return valid;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!Validate_Fields())
                return;

            Fill(); 
            if (_appTypeServices.Save(_appType))
            {
                MessageBox.Show("Data has been saved successfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Data hasn't been saved","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);   
        }

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-numeric input
            }
            
        }
    }
}
