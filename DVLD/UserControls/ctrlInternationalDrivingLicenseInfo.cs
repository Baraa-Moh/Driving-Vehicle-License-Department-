using Common;
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

namespace DVLD.UserControls
{
    public partial class ctrlInternationalDrivingLicenseInfo : UserControl
    {
        private InternationalLicense _internationalLicense;
        private DriverServices _driverServices;
        private PersonServices _personServices;
        public ctrlInternationalDrivingLicenseInfo()
        {
            InitializeComponent();
            _driverServices = new DriverServices(new DVLD_DAL.SqlDriverRepository(), new PersonServices(new DVLD_DAL.SqlPersonRepository()), new TestSharedServices());
            _personServices = new PersonServices(new DVLD_DAL.SqlPersonRepository());
        }

        private void ctrlInternationalDrivingLicenseInfo_Load(object sender, EventArgs e)
        {

        }
        public void Load_InternationalLicense(InternationalLicense internationalLicense)
        {
            _internationalLicense = internationalLicense;
            Fill_Fields();
        }
        private void Fill_Fields()
        {
            if (_internationalLicense == null)
                return;
            Person person = _personServices.GetPerson(_driverServices.GetDriver(_internationalLicense.DriverID).PersonID);

            lbName.Text = person.FullName;
            lbLicenseID.Text = _internationalLicense.IssuedUsingLocalLicenseID.ToString();
            lbInternationalLicenseID.Text = _internationalLicense.InternationalLicenseID.ToString();
            lbGender.Text = person.Gender == 0 ? "Male" : "Female";
            lbNationalID.Text = person.NationalID;
            lbDateOfBirth.Text = person.DateOfBirth.ToString("dd/MM/yyyy");
            lbIssueDate.Text = _internationalLicense.IssueDate.ToString("dd/MM/yyyy");
            lbExpirationDate.Text = _internationalLicense.ExpirationDate.ToString("dd/MM/yyyy");
            lbIsActive.Text = _internationalLicense.IsActive ? "Active" : "Inactive";
            lbDriverID.Text = _internationalLicense.DriverID.ToString();
            lbAppID.Text = _internationalLicense.ApplicationID.ToString();

            if(person.ImagePath != null)
                pbImage.Load(person.ImagePath);
            else
            {
                if (person.Gender == 0)
                    pbImage.Image = Properties.Resources.Male_512;
                else pbImage.Image = Properties.Resources.Female_512;
            }
        }
    }
}
