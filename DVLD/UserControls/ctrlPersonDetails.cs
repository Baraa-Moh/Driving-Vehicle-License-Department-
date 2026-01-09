using Common;
using DVLD.People;
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

namespace DVLD.UserControls
{
    public partial class ctrlPersonDetails : UserControl
    {
        private PersonServices _personServices;
        private CountryServices _countryServices;
        private Person _person;
        public ctrlPersonDetails()
        {
            InitializeComponent();
            _personServices = new PersonServices(new SqlPersonRepository());  
            _countryServices = new CountryServices(new SqlCountryRepository());
        }

        private void ctrlPersonDetails_Load(object sender, EventArgs e)
        {
            Empty_Card();
        }
        public void Empty_Card()
        {
            string Uniformed = "[???????]";
            lbPersonID.Text = Uniformed;
            lbNationalNo.Text = Uniformed;
            lbCountry.Text = Uniformed;
            lbName.Text = Uniformed;
            lbEmail.Text = Uniformed;
            lbPhone.Text = Uniformed;
            lbAddress.Text = Uniformed;
            lbGender.Text = Uniformed;
            lbDateOfBirth.Text = Uniformed;
            pbPersonalImage.Image = Properties.Resources.Male_512;
        }
        public void Load_Person(int personId)
        {
            _person = _personServices.FindPersonByID(personId);
            if (_person == null)
                return;

            linkLabel1.Enabled = true;
            lbPersonID.Text = _person.ID.ToString();
            lbName.Text = _person.FullName;
            lbEmail.Text = _person.Email;
            lbNationalNo.Text = _person.NationalID;
            if (_person.Gender == 0)
            {
                lbGender.Text = "Male";
                pbGender.Image = Properties.Resources.Man_32;
            }
            else
            {
                lbGender.Text = "Female";
                pbGender.Image = Properties.Resources.Woman_32; ;
            }
            lbAddress.Text = _person.Address;
            lbCountry.Text = _countryServices.GetCountry(_person.NationalityID).Name;
            lbPhone.Text = _person.Phone;
            lbDateOfBirth.Text = _person.DateOfBirth.ToString();
            if(_person.ImagePath != null)
            {
                try
                {
                    pbPersonalImage.Load(_person.ImagePath);
                }
                catch (Exception)
                {
                    pbPersonalImage.Image = _person.Gender == 0 ? Properties.Resources.Male_512 : Properties.Resources.Female_512;
                }
            }
            else pbPersonalImage.Image = _person.Gender == 0 ? Properties.Resources.Male_512 : Properties.Resources.Female_512;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdatePerson form = new AddUpdatePerson(_person.ID);
            form.ShowDialog();
            Load_Person(_person.ID);
        }
    }
}
