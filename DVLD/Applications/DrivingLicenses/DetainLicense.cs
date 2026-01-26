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

namespace DVLD.Applications.DrivingLicenses
{
    public partial class DetainLicense : Form
    {
        private Common.License _license;
        private Common.DetainedLicense _detainedLicense;
        private readonly DetainedLicenseServices _detainedLicenseServices;
        public DetainLicense()
        {
            InitializeComponent();
            _detainedLicenseServices = new DetainedLicenseServices(new SqlDetainedLicenseRepository());
        }

        private void DetainLicense_Load(object sender, EventArgs e)
        {

        }

        private void ctrlFilterShowLicenseInfo1_OnLicenseFound(Common.License obj)
        {
            if(obj == null)
            {
                llbShowLicenseInfo.Enabled = false;
                llbShowLicensesHistory.Enabled = false;
                btDetain.Enabled = false;
                ctrlDetainInfo1.ClearInfo();
                return;
            }
            _license = obj;
            btDetain.Enabled= true;
            llbShowLicensesHistory.Enabled= true;
            Fill_DetainInfo();
        }
        private void Fill_DetainInfo()
        {
            _detainedLicense = new Common.DetainedLicense();
            _detainedLicense.DetainDate = DateTime.Now;
            _detainedLicense.LicenseID = _license.LicenseID;
            _detainedLicense.CreatedByUserID = _license.CreatedByUserID;

            ctrlDetainInfo1.Load_DetainedLicenseInfo(_detainedLicense);
        }
        private void llbShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory form = new LicenseHistory(_license.DriverID, false);
            form.ShowDialog();
        }
        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseInfo form = new LicenseInfo(_license.DriverID);
            form.ShowDialog();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btDetain_Click(object sender, EventArgs e)
        {
            string error = null;
            if (!_detainedLicenseServices.AddNewDetain(_detainedLicense,ref error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btDetain.Enabled = false;
                return;
            }

            MessageBox.Show("Saved Successfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
            ctrlFilterShowLicenseInfo1.EnableFilter = false;
            btDetain.Enabled = false;
            ctrlDetainInfo1.Load_DetainedLicenseInfo(_detainedLicense);
        }
    }
}
