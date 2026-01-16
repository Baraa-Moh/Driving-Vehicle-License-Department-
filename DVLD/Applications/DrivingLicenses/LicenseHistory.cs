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
    public partial class LicenseHistory : Form
    {
        private LicenseServices _licenseServices;
        private Driver _driver;
        private DriverServices _driverServices;
        public LicenseHistory(int personID)
        {
            InitializeComponent();
            LDLApplicationServices _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _licenseServices = new LicenseServices(new SqlLicenseRepository(), new TestSharedServices(), _LDLappServices, new DriverServices(new SqlDriverRepository(), new PersonServices(new SqlPersonRepository()), new TestSharedServices()), new ApplicationServices(new SqlApplicationRepository()));
            _driverServices = new DriverServices(new SqlDriverRepository(), new PersonServices(new SqlPersonRepository()), new TestSharedServices());
            _driver = _driverServices.GetDriverByPersonID(personID); 
        }

        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            if(_driver ==null)
            {
                MessageBox.Show("No driver record found for the selected person. License history cannot be displayed.", "Driver Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            Prepare(); ;        
        }
        private void Prepare()
        {
            dgvLocal.DataSource = _licenseServices.GetAllLicensesByDriverID(_driver.DriverID);
            ctrlFindShowPersonDetails1.Load_Information(_driver.PersonID);
            ctrlFindShowPersonDetails1.Enabled = false;
            lbRecords.Text = dgvLocal.Rows.Count.ToString() + " records found.";
            //will implement international history later.......
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
