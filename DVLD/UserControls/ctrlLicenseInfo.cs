using Common;
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
    public partial class ctrlLicenseInfo : UserControl
    {
        private Common.License _license;
        private LDLApplicationServices _LDLappServices;
        private LDLApplicationDto _LDLApp;
        private LicenseServices _LicenseServices;
        private LicenseClassServices _LicenseClassServices;
        private PersonServices _personServices;
        private DetainedLicenseServices _detainedLicenseServices;
        public ctrlLicenseInfo()
        {
            InitializeComponent();
            
        }
        private void ctrlLicenseInfo_Load(object sender, EventArgs e)
        {
           
        }
        public void Load_License(Common.License license)
        {
            _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _license = license;
            _LDLApp = _LDLappServices.GetLDLApplicationByAppID(_license.ApplicationID);
            _LicenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
            _LicenseServices = new LicenseServices(new SqlLicenseRepository(), new TestSharedServices(), _LDLappServices, new DriverServices(new SqlDriverRepository()), new ApplicationServices(new SqlApplicationRepository()));
            _personServices = new PersonServices(new SqlPersonRepository()); ;
            _detainedLicenseServices = new DetainedLicenseServices(new SqlDetainedLicenseRepository());

            Prepare(); ;
        }
        public void Load_License(int LDLAppID)
        {
            _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _LDLApp = _LDLappServices.GetLDLApplication(LDLAppID);
            _LicenseServices = new LicenseServices(new SqlLicenseRepository(), new TestSharedServices(), _LDLappServices, new DriverServices(new SqlDriverRepository()), new ApplicationServices(new SqlApplicationRepository()));
            _license = _LicenseServices.GetLicenseByAppID(_LDLApp.Application.ID);
            _LicenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
            _personServices = new PersonServices(new SqlPersonRepository()); ;
            _detainedLicenseServices = new DetainedLicenseServices(new SqlDetainedLicenseRepository());

            Prepare();
        }
        private void Prepare()
        {
            Person person = _personServices.GetPerson(_LDLApp.Application.PersonID);

            lbClass.Text = _LicenseClassServices.GetLicenseClass(_LDLApp.LDLApplication.LicenseClassID).Name;
            lbName.Text = person.FullName;
            lbNationalID.Text = person.NationalID;
            lbLicenseID.Text = _license.LicenseID.ToString();
            lbGender.Text = person.Gender == 0 ? "Male" : "Female";
            lbIssueDate.Text = _license.IssueDate.ToString();
            lbIssueReason.Text = _LicenseServices.GetIssueReason(_license.IssueReason);
            lbNotes.Text = _license.Notes;
            lbIsActive.Text = _license.isActive ? "Yes" : "No";
            lbExpirationDate.Text = _license.ExpirationDate.ToString();
            lbDateOfBirth.Text = person.DateOfBirth.ToString();
            lbDriverID.Text= _license.DriverID.ToString();  
            lbIsDetained.Text = _detainedLicenseServices.isDetained(_license.LicenseID) ? "Yes" : "No";

            if (person.ImagePath != null)
            {
                pbImage.Load(person.ImagePath);
            }
            else
            {
                if (person.Gender == 0)
                    pbImage.Image = Properties.Resources.Male_512;
                else pbImage.Image = Properties.Resources.Female_512;
            }
            
        }
    }
}
