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
            if(obj == null)
            {
                ctrlLicenseInfo1.Clear();
            }
            else
                ctrlLicenseInfo1.Load_License(obj);

            LicenseFound(obj);
        }
        public void Load_License(Common.License license)
        {
            ctrlLicenseInfo1.Load_License(license);
            
        }
        public void Clear()
        {
            ctrlLicenseInfo1.Clear();
        }
        private void ctrlFilterShowLicenseInfo_Load(object sender, EventArgs e)
        {

        }
        
    }
}
