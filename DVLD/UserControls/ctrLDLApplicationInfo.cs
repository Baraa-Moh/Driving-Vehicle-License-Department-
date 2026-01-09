using DVLD_BLL;
using DVLD_BLL.DTOs;
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

namespace DVLD.UserControls
{
    public partial class ctrLDLApplicationInfo : UserControl
    {
        private LDLApplicationDto _LDLApp;
        private LDLApplicationServices _services;
        //should be handled by services or inside the dto but for simplicity :)
        private LicenseClassServices _licenseClassServices;
        public ctrLDLApplicationInfo()
        {
            InitializeComponent();
            _services = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), 
                new TestSharedServices(), new SqlLDLApplicationRepository());
            _licenseClassServices= new LicenseClassServices(new SqlLicenseClassRepository());   
        }
        public void Load_LDLApp(int LDLAppID)
        {
            _LDLApp= _services.GetLDLApplication(LDLAppID);
            Fill_Fields();
        }
        private void Fill_Fields()
        {
            lbLDLAppID.Text= _LDLApp.LDLApplication.ID.ToString();
            lbLicenseClass.Text = _licenseClassServices.GetLicenseClass(_LDLApp.LDLApplication.LicenseClassID).Name;
            lbPassedTests.Text = _LDLApp.PassedTests.ToString() + "/3";

            if (_LDLApp.Application.Status != 3)
                linkLabel1.Enabled = false;
            else linkLabel1.Enabled = true;
        }
        private void ctrLDLApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
