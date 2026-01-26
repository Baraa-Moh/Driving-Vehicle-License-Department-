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

namespace DVLD.Applications.DrivingLicenses
{
    public partial class ReplacementForLostOrDamaged : Form
    {
        private Common.License _license;
        private Common.License _newLicense;
        private Common.Application _app;
        private readonly LicenseServices _licenseServices;
        private readonly ApplicationServices _appServices;
        private readonly ApplicationTypeServices _appTypeServices;
        private readonly DriverServices _driverServices;
        private readonly LicenseClassServices _licenseClassServices;
        int _personID;
        int _appTypeID;
        public ReplacementForLostOrDamaged()
        {
            InitializeComponent();
            _appServices = new ApplicationServices(new SqlApplicationRepository());
            TestSharedServices sharedServices = new TestSharedServices();
            LDLApplicationServices ldlAppServices = new LDLApplicationServices(_appServices,sharedServices,new SqlLDLApplicationRepository());
            _licenseServices = new LicenseServices(new SqlLicenseRepository(), sharedServices, ldlAppServices, new DriverServices(new SqlDriverRepository(), new PersonServices(new SqlPersonRepository()), sharedServices),_appServices);
            _appTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
            _driverServices = new DriverServices(new SqlDriverRepository(), new PersonServices(new SqlPersonRepository()), sharedServices);
            _licenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
            _app = new Common.Application();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void rbDamagedLicense_Click(object sender, EventArgs e)
        {
            if (rbDamagedLicense.Checked)
                lbTitle.Text = "Replacement for Damaged License";
            else
                lbTitle.Text = "Replacement for Lost License";
            Fill_App();
            if(_license != null)
                lbTotalFees.Text = (_appTypeServices.GetApplicationType(_appTypeID).Fees + _licenseClassServices.GetLicenseClass(_license.LicenseClassID).Fees).ToString("C2");
        }
        private void Fill_App()
        {
            _app.PersonID= _personID;
            _app.Date = DateTime.Now;
            _appTypeID = rbDamagedLicense.Checked ? (int)Core.ApplicationTypes.ReplacementForDamaged : (int)Core.ApplicationTypes.ReplacementForLost;
            _app.TypeID = _appTypeID;
            _app.Status = 1;
            _app.LastStatuesDate = DateTime.Now;
            _app.PaidFees = _appTypeServices.GetApplicationType(_app.TypeID).Fees;
            _app.CreatedBy = Core.CurrentUser.UserID;

            ctrlAppBasicInfo1.Load_Application(_app);
        }
        private void ctrlFilterShowLicenseInfo1_OnLicenseFound(Common.License obj)
        {
            if(obj == null)
            {
                llbShowLicensesHistory.Enabled = false;
                btIssue.Enabled = false;
                lbTotalFees.Text = string.Empty;
                ctrlAppBasicInfo1.Clear();
                Fill_App();
                return;
            }

            _license = obj;
            if (!_license.isActive)
            {
                MessageBox.Show("The selected license is not active.", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlFilterShowLicenseInfo1.Clear();
                return;
            }

            _personID = _driverServices.GetDriver(_license.DriverID).PersonID;
            llbShowLicensesHistory.Enabled = true;
            btIssue.Enabled = true;
            Fill_App();
            lbTotalFees.Text = (_appTypeServices.GetApplicationType(_appTypeID).Fees + _licenseClassServices.GetLicenseClass(_license.LicenseClassID).Fees).ToString("C2");
        }
        private void ReplacementForLostOrDamaged_Load(object sender, EventArgs e)
        {
            rbDamagedLicense.Checked = true;
        }
        private void llbShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory form = new LicenseHistory(_personID);
            form.ShowDialog();
        }
        private void Fill_NewLicense()
        {
            _newLicense = new Common.License();
            _newLicense.DriverID = _license.DriverID;
            _newLicense.LicenseClassID = _license.LicenseClassID;
            _newLicense.IssueDate = DateTime.Now;
            _newLicense.ExpirationDate = _license.ExpirationDate;
            _newLicense.isActive = true;
            _newLicense.CreatedByUserID = Core.CurrentUser.UserID;
            _newLicense.ApplicationID = _app.ID;
            _newLicense.IssueReason = rbDamagedLicense.Checked ? (byte)3 :(byte) 4; // 3: Damaged, 4: Lost
            _newLicense.Notes = null;
            _newLicense.PaidFees = _licenseClassServices.GetLicenseClass(_newLicense.LicenseClassID).Fees;
        }
        private void btIssue_Click(object sender, EventArgs e)
        {
            if (!_appServices.Save(_app))
            {
                MessageBox.Show("Failed to save the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Fill_NewLicense();
            string error = null;

            if(_licenseServices.Save(_newLicense, ref error,Core.enIssueReason.ReplacementOrDamaged,_license))
            {
                MessageBox.Show("New license issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llbShowLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error issuing new license: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseInfo form = new LicenseInfo(_newLicense);
            form.ShowDialog();
        }
    }
}
