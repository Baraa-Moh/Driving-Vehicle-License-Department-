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

namespace DVLD.Applications.DrivingLicenses
{
    public partial class LDLApplicationDetails : Form
    {
        private int _LDLAppID;
        private LDLApplicationServices _LDLappServices;
        private LDLApplicationDto _LDLApp;
        public LDLApplicationDetails(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _LDLApp = _LDLappServices.GetLDLApplication(_LDLAppID);
        }
        private void LDLApplicationDetails_Load(object sender, EventArgs e)
        {
            if (_LDLApp == null)
            {
                MessageBox.Show($"There's no application with [{_LDLAppID}] ID");
                this.Close();
                return;
            }
            ctrlAppBasicInfo1.Load_Application(_LDLApp.Application);
            ctrLDLApplicationInfo1.Load_LDLApp(_LDLAppID);
        }
    }
}
