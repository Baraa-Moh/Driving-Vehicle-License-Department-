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
    public partial class LicenseHistory : Form
    {
        private LicenseServices _licenseServices;
        private int _driverID;
        private DriverServices _driverServices;
        public LicenseHistory(int personID)
        {
            InitializeComponent();
            LDLApplicationServices _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _licenseServices = new LicenseServices(new SqlLicenseRepository(), new TestSharedServices(), _LDLappServices, new DriverServices(new SqlDriverRepository()), new ApplicationServices(new SqlApplicationRepository()));
            _driverServices = new DriverServices(new SqlDriverRepository());
            _driverID = _driverServices.GetDriverByPersonID(personID).DriverID; 
        }

        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            Prepare(); ;        
        }
        private void Prepare()
        {
            dgvLocal.DataSource = _licenseServices.GetAllLicensesByDriverID(_driverID);
            //will implement international history later.......
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
