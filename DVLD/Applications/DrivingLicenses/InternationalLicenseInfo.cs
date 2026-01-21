using Common;
using DVLD_BLL;
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
    public partial class InternationalLicenseInfo : Form
    {
        private readonly InternationalLicense _license;
        private readonly InternationalLicensesServices _intLicenseServices;
        public InternationalLicenseInfo(InternationalLicense license)
        {
            InitializeComponent();
            _license = license;
        }
        public InternationalLicenseInfo(int licenseID)
        {
            InitializeComponent();
            _intLicenseServices = new InternationalLicensesServices(new DVLD_DAL.SqlInternationalLicenseRepo(), new LicenseServices(new DVLD_DAL.SqlLicenseRepository(), new TestSharedServices(), new LDLApplicationServices(new ApplicationServices(new DVLD_DAL.SqlApplicationRepository()), new TestSharedServices(), new DVLD_DAL.SqlLDLApplicationRepository()), new DriverServices(new DVLD_DAL.SqlDriverRepository(), new PersonServices(new DVLD_DAL.SqlPersonRepository()), new TestSharedServices()), new ApplicationServices(new DVLD_DAL.SqlApplicationRepository())));
            _license = _intLicenseServices.GetInternationalLicense(licenseID);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalDrivingLicenseInfo1.Load_InternationalLicense(_license);
        }
    }
}
