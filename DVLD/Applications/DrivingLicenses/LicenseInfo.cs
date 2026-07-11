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
    public partial class LicenseInfo : Form
    {
        private readonly Common.License _license;
        private readonly LicenseServices _licenseServices;
        private readonly int _LDLappID;
        public LicenseInfo(Common.License license)
        {
            InitializeComponent();
            _license = license;
        }
        public LicenseInfo(int LDLAppID)
        {
            InitializeComponent();
            _LDLappID = LDLAppID;
            _license = null;
        }
        public LicenseInfo(int licenseID, bool isLicenseID)
        {
            InitializeComponent();
            LicenseServices licenseServices = new LicenseServices(new DVLD_DAL.SqlLicenseRepository(), new DVLD_BLL.TestSharedServices(), new LDLApplicationServices(new ApplicationServices(new DVLD_DAL.SqlApplicationRepository()), new DVLD_BLL.TestSharedServices(), new DVLD_DAL.SqlLDLApplicationRepository()), new DriverServices(new DVLD_DAL.SqlDriverRepository(), new PersonServices(new DVLD_DAL.SqlPersonRepository()), new DVLD_BLL.TestSharedServices()), new ApplicationServices(new DVLD_DAL.SqlApplicationRepository()));
            _license = licenseServices.GetLicense(licenseID);
        }
        private void LicenseInfo_Load(object sender, EventArgs e)
        {
            if (_license == null)
                ctrlLicenseInfo1.Load_License(_LDLappID);
            else ctrlLicenseInfo1.Load_License(_license);
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
