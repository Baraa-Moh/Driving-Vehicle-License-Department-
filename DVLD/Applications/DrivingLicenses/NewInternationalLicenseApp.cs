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
    public partial class NewInternationalLicenseApp : Form
    {
        private readonly InternationalLicensesServices _internationalLicensesServices;
        private readonly ApplicationServices _applicationServices;
        private readonly ApplicationTypeServices _applicationTypeServices;
        private readonly DriverServices _driverServices;
        private Common.Application _app; 
        private InternationalLicense _internationalLicense;
        private Common.License _license;
        private readonly LicenseClassServices _licenseClassServices;
        public NewInternationalLicenseApp()
        {
            InitializeComponent();
            LDLApplicationServices _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            LicenseServices _LicenseServices = new LicenseServices(new SqlLicenseRepository(), new TestSharedServices(), _LDLappServices, new DriverServices(new SqlDriverRepository(), new PersonServices(new SqlPersonRepository()), new TestSharedServices()), new ApplicationServices(new SqlApplicationRepository()));
            _internationalLicensesServices = new InternationalLicensesServices(new SqlInternationalLicenseRepo(), _LicenseServices);
            _applicationServices = new ApplicationServices(new SqlApplicationRepository());
             _applicationTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
            _driverServices = new DriverServices(new SqlDriverRepository(), new PersonServices(new SqlPersonRepository()), new TestSharedServices());
            _licenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
        }

        private void NewInternationalLicenseApp_Load(object sender, EventArgs e)
        {

        }
        private void FillNewInternationalApplication(Common.License license)
        {
            _app = new Common.Application();
            _app.PersonID = _driverServices.GetDriver(license.DriverID).PersonID;
            _app.Date = DateTime.Now;
            _app.TypeID = (int)Core.ApplicationTypes.NewInternationalLicense;
            _app.Status = (int)Core.Status.New;
            _app.LastStatuesDate = DateTime.Now;
            _app.CreatedBy =Core.CurrentUser.UserID;
            _app.PaidFees = _applicationTypeServices.GetApplicationType(_app.TypeID).Fees;

            ctrlAppBasicInfo1.Load_Application(_app);
        }
        private void ctrlFilterShowLicenseInfo1_OnLicenseFound(Common.License obj)
        {
            if (obj == null)
                return;
            _license = obj;
            FillNewInternationalApplication(_license);
            llbShowLicensesHistory.Enabled = true;
            btIssue.Enabled = true;
        }

        private void llbShowLicensesHistory_Click(object sender, EventArgs e)
        {
            LicenseHistory form = new LicenseHistory(_app.PersonID);
            form.ShowDialog();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InternationalLicenseInfo form = new InternationalLicenseInfo(_internationalLicense);
            form.ShowDialog();
        }

        private void Fill_InternationalLicenseInfo()
        {
            _internationalLicense = new InternationalLicense();
            _internationalLicense.ApplicationID = _app.ID;
            _internationalLicense.DriverID = _license.DriverID;
            _internationalLicense.IssuedUsingLocalLicenseID = _license.LicenseID;
            _internationalLicense.IssueDate = DateTime.Now;
            int defaultYears = _licenseClassServices.GetLicenseClass(_license.LicenseClassID).DefaultValidityLength;
            _internationalLicense.ExpirationDate = DateTime.Now.AddYears(defaultYears);
            _internationalLicense.CreatedByUserID = Core.CurrentUser.UserID;
            _internationalLicense.IsActive = true;
        }
        private void btIssue_Click(object sender, EventArgs e)
        {
            if(!_applicationServices.Save(_app))
            {
                MessageBox.Show("Error with the application", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Fill_InternationalLicenseInfo();
            string error = null;
            if (_internationalLicensesServices.Save(_internationalLicense,ref error))
            {
                MessageBox.Show("International Driving License issued successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llbShowLicenseInfo.Enabled = true;
                ctrlFilterShowLicenseInfo1.EnableFilter = false;
                btIssue.Enabled = false;
            }
            else MessageBox.Show(error,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
