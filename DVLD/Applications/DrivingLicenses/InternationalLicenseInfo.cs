using Common;
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
        public InternationalLicenseInfo(InternationalLicense license)
        {
            InitializeComponent();
            _license = license;
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
