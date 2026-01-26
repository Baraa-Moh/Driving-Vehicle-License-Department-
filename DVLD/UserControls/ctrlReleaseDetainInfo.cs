using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using DVLD_BLL;
using DVLD_DAL;
namespace DVLD.UserControls
{ 
    public partial class ctrlReleaseDetainInfo : UserControl
    {
        private DetainedLicense _detain;
        private DetainedLicenseServices _detainedLicenseServices;   
        private ApplicationServices _appServices;
        private ApplicationTypeServices _applicationTypeServices;
        private double _appFees;
        public ctrlReleaseDetainInfo()
        {
            InitializeComponent();
            _appServices = new ApplicationServices(new SqlApplicationRepository());
            _detainedLicenseServices = new DetainedLicenseServices(new SqlDetainedLicenseRepository()); 
            _applicationTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
        }
        private void ctrlReleaseDetainInfo_Load(object sender, EventArgs e)
        {

        }
        public void Load_Detain(DetainedLicense detainedLicense)
        {
            _detain = detainedLicense;
            lbDetainID.Text = detainedLicense.DetainID ==-1 ? "???" : detainedLicense.DetainID.ToString();
            lbDetainDate.Text = detainedLicense.DetainDate.ToString();
            _appFees = _applicationTypeServices.GetApplicationType((int)Core.ApplicationTypes.ReleaseDetainedLicense).Fees;
            lbApplicationFees.Text = _appFees.ToString();
            lbTotalFees.Text = (_appFees + _detain.FineFees).ToString();
            lbLicenseID.Text = _detain.LicenseID.ToString();
            lbCreatedBy.Text = _detain.CreatedByUserID.ToString();
            lbFineFees.Text = _detain.FineFees.ToString();
            lbApplicationID.Text = _detain.ReleaseApplicationID ==-1 ? "???" : _detain.ReleaseApplicationID.ToString();
        }
    }
}
