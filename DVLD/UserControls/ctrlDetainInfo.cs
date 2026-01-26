using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UserControls
{
    public partial class ctrlDetainInfo : UserControl
    {
        private DetainedLicense _detained;
        public ctrlDetainInfo()
        {
            InitializeComponent();
        }

        private void ctrlDetainInfo_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = 0;
        }

        public void Load_DetainedLicenseInfo(DetainedLicense detainedLicense)
        {
            _detained = detainedLicense;
            lbDetainID.Text = detainedLicense.DetainID.ToString();
            lbDetainDate.Text = detainedLicense.DetainDate.ToString("dd/MM/yyyy");
            comboBox1.SelectedIndex = 0;
            lbLicenseID.Text = detainedLicense.LicenseID.ToString();
            lbCreatedBy.Text = detainedLicense.CreatedByUserID.ToString();
        }
        public void ClearInfo()
        {
            lbDetainID.Text = "???";
            lbDetainDate.Text = "???";
            lbLicenseID.Text = "???";
            lbCreatedBy.Text = "???";
            _detained = null;
        }

        private void tbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _detained.FineFees = Convert.ToDouble(comboBox1.SelectedItem);
        }
    }
}
