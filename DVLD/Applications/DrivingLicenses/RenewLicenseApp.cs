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
    public partial class RenewLicenseApp : Form
    {
        private Common.License _license;
        private Common.License _newLicense;
        private Common.Application _application;
        private DriverServices _driverServices;
        private PersonServices _personServices;
        private ApplicationTypeServices _applicationTypeServices;
        private LicenseClassServices _licenseClassServices;
        private ApplicationServices _applicationServices;
        private LicenseServices _licenseServices;
        private int _personID;  
        public RenewLicenseApp()
        {
            InitializeComponent();
            _personServices = new PersonServices(new SqlPersonRepository());
            _driverServices = new DriverServices(new SqlDriverRepository(), _personServices, new TestSharedServices());
            _applicationTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
            _licenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
            _applicationServices = new ApplicationServices(new SqlApplicationRepository());
            _licenseServices = new LicenseServices(new SqlLicenseRepository(), new TestSharedServices(), new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository()), _driverServices, _applicationServices);
        }

        private void RenewLicenseApp_Load(object sender, EventArgs e)
        {

        }

        private void ctrlFilterShowLicenseInfo1_OnLicenseFound(Common.License obj)
        {
            _license = obj;
            if(_license.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("The license is still valid and cannot be renewed.");
                llbShowLicensesHistory.Enabled = false;
                btIssue.Enabled = false;
                return;
            }

            Fill_Application();
            llbShowLicensesHistory.Enabled = true;
            btIssue.Enabled = true;
        }
        private void Fill_Application()
        {
            _personID = _driverServices.GetDriver(_license.DriverID).PersonID;  
            _application = new Common.Application();
            _application.PersonID = _personID;
            _application.Date = DateTime.Now;
            _application.TypeID = (int)Core.ApplicationTypes.RenewDrivingLicense;
            _application.Status = (int)Core.Status.New;
            _application.LastStatuesDate = DateTime.Now;
            _application.PaidFees = _applicationTypeServices.GetApplicationType((int)Core.ApplicationTypes.RenewDrivingLicense).Fees;
            _application.CreatedBy = Core.CurrentUser.UserID;

            ctrlAppBasicInfo1.Load_Application(_application);
        }
        private void btIssue_Click(object sender, EventArgs e)
        {
            if(!_applicationServices.Save(_application))
            {
                MessageBox.Show("Error with the application", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Fill_NewLicense();
            string error = null;

            if(_licenseServices.Save(_newLicense,ref error, Core.enIssueReason.Renew, _license))
            {
                MessageBox.Show("The license has been renewed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llbShowLicenseInfo.Enabled = true;
                btIssue.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error with the license renewal: " + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Fill_NewLicense()
        {
            //not all the information is available in the UI for now.
            _newLicense = new Common.License();
            _newLicense.DriverID = _license.DriverID;
            _newLicense.ApplicationID = _application.ID;
            _newLicense.LicenseClassID = _license.LicenseClassID;
            _newLicense.IssueDate = DateTime.Now;
            int defaultYears = _licenseClassServices.GetLicenseClass(_license.LicenseClassID).DefaultValidityLength;
            _newLicense.ExpirationDate = DateTime.Now.AddYears(defaultYears);
            _newLicense.Notes = null;
            _newLicense.PaidFees = _licenseClassServices.GetLicenseClass(_license.LicenseClassID).Fees;
            _newLicense.isActive = true;
            _newLicense.IssueReason = (byte)Core.enIssueReason.Renew;
            _newLicense.CreatedByUserID = Core.CurrentUser.UserID;
        }
        private void llbShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory form = new LicenseHistory(_personID);
            form.ShowDialog();
        }
        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseInfo form = new LicenseInfo(_newLicense);
            form.ShowDialog();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
