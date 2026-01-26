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

namespace DVLD.UserControls
{
    public partial class ctrlFilterLicenses : UserControl
    {
        private readonly LicenseServices _licenseServices;
        public event Action<Common.License> OnLicenseFound;
        protected virtual void LicenseFound(Common.License license)
        {
            Action<Common.License> handler = OnLicenseFound;
            if (handler != null)
                handler(license);
        }
        public ctrlFilterLicenses()
        {
            InitializeComponent();
            LDLApplicationServices _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _licenseServices = new LicenseServices(new SqlLicenseRepository(), new TestSharedServices(), _LDLappServices, new DriverServices(new SqlDriverRepository(), new PersonServices(new SqlPersonRepository()), new TestSharedServices()), new ApplicationServices(new SqlApplicationRepository()));
        }

        private void ctrlFilterLicenses_Load(object sender, EventArgs e)
        {

        }
        public void Load_Disable(int licenseID)
        {
            Common.License license = _licenseServices.GetLicense(licenseID);
            LicenseFound(license);
            textBox1.Text = licenseID.ToString();
            Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int licenseID = Convert.ToInt32(textBox1.Text.Trim());
            Common.License license = _licenseServices.GetLicense(licenseID);
            LicenseFound(license);
            if (license == null)
            {
                MessageBox.Show("No license found with the provided ID.", "License Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
        }
    }
}
