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
    public partial class ctrlFilterShowLicenseInfo : UserControl
    {
        public bool EnableFilter         {
            get { return ctrlFilterLicenses1.Enabled; }
            set { ctrlFilterLicenses1.Enabled = value; }
        }
        public event Action<Common.License> OnLicenseFound;
        protected virtual void LicenseFound(Common.License license)
        {
            Action<Common.License> handler = OnLicenseFound;
            if (handler != null)
                handler(license);
        }
        public ctrlFilterShowLicenseInfo()
        {
            InitializeComponent();
        }

        private void ctrlFilterLicenses1_OnLicenseFound(Common.License obj)
        {
            ctrlLicenseInfo1.Load_License(obj);
            LicenseFound(obj);
        }

        private void ctrlFilterShowLicenseInfo_Load(object sender, EventArgs e)
        {

        }
        
    }
}
