using Common;
using DVLD_BLL;
using DVLD_BLL.DTOs;
using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.DrivingLicenses
{
    public partial class IssueDrivingLicenseForFirstTime : Form
    {
        private LDLApplicationDto _LDLApp;
        private LDLApplicationServices _LDLappServices;
        private Common.License _license;
        private LicenseServices _LicenseServices;
        private LicenseClassServices _LicenseClassServices;
        private LicenseClass _licenseClass;
        public IssueDrivingLicenseForFirstTime(int LDLAppID)
        {
            InitializeComponent();
            _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _LDLApp = _LDLappServices.GetLDLApplication(LDLAppID);
            _license = new Common.License();
            _LicenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
            _licenseClass = _LicenseClassServices.GetLicenseClass(_LDLApp.LDLApplication.LicenseClassID);
            _LicenseServices = new LicenseServices(new SqlLicenseRepository(),new TestSharedServices(),_LDLappServices,new DriverServices(new SqlDriverRepository()),new ApplicationServices(new SqlApplicationRepository()));
        }

        private void IssueDrivingLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            Prepare();
        }
        private void Prepare()
        {
            ctrlAppBasicInfo1.Load_Application(_LDLApp.Application.ID);
            ctrLDLApplicationInfo1.Load_LDLApp(_LDLApp.LDLApplication.ID);
            lbFees.Text = _licenseClass.Fees.ToString();
        }
        private void Fill_License()
        {
            _license.ApplicationID = _LDLApp.Application.ID;
            _license.ExpirationDate = DateTime.Now.AddYears(_licenseClass.DefaultValidityLength);
            _license.IssueDate = DateTime.Now;
            _license.Notes = tbNotes.Text.Length==0 ? null : tbNotes.Text;  
            _license.CreatedByUserID = Core.CurrentUser.UserID;
            _license.PaidFees = _licenseClass.Fees;
            _license.LicenseClassID = _licenseClass.ID;
            _license.IssueReason = 1;
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btIssue_Click(object sender, EventArgs e)
        {
            Fill_License();

            string error = null;
            if(_LicenseServices.Save(_license,ref error,Core.enIssueReason.FirstTime))
            {
                MessageBox.Show($"Issued Successfully with License ID {_license.LicenseID}","Issued",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(error,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
