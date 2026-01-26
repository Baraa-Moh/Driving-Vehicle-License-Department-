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

namespace DVLD.Applications
{
    public partial class ReleaseDetain : Form
    {
        private Common.License _license;
        private DetainedLicense _detainedLicense;
        private DetainedLicenseServices _detainedServices;
        public ReleaseDetain()
        {
            InitializeComponent();
            _detainedServices = new DetainedLicenseServices(new SqlDetainedLicenseRepository());
        }

        private void ReleaseDetain_Load(object sender, EventArgs e)
        {

        }

        private void ctrlFilterShowLicenseInfo1_OnLicenseFound(Common.License obj)
        {
            _license = obj;
            if (_license == null)
                return;

            if (!_detainedServices.isDetained(_license.LicenseID))
            {
                MessageBox.Show("Selected License isn't Detained","Valid License",MessageBoxButtons.OK, MessageBoxIcon.Error);
                btRelease.Enabled = false;
                llbShowLicensesHistory.Enabled = false;
                return;
            }

            _detainedLicense = _detainedServices.GetDetainByLicenseID(_license.LicenseID);
            btRelease.Enabled = true;
            llbShowLicensesHistory.Enabled=true;
            ctrlReleaseDetainInfo1.Load_Detain(_detainedLicense);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btRelease_Click(object sender, EventArgs e)
        {
            string error = null;
            if(_detainedServices.ReleaseDetain(_detainedLicense,ref error))
            {
                MessageBox.Show("Released Successfully","Released",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btRelease.Enabled=false;
                ctrlFilterShowLicenseInfo1.EnableFilter =false;
                llbShowLicenseInfo.Enabled = true;
                ctrlReleaseDetainInfo1.Load_Detain(_detainedLicense);
            }
            else
                MessageBox.Show(error,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
