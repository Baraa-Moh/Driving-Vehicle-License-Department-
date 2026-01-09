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
        private void LicenseInfo_Load(object sender, EventArgs e)
        {
            if (_license == null)
                ctrlLicenseInfo1.Load_License(_LDLappID);
            else ctrlLicenseInfo1.Load_License(_license);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
