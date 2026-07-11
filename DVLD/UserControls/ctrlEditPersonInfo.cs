using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BLL;
using Common;
using DVLD_DAL;

namespace DVLD.UserControls
{
    public partial class ctrlEditPersonInfo : UserControl
    {
        private Person _person;
        private CountryServices _countryServices;

        enum enMode { add,update};
        enMode mode;

        public event Action<object> onCloseClick;
        protected virtual void CloseClick(object result)
        {
            Action<object> handler = onCloseClick;
            if (handler != null)
                handler(result);
        }
        public event Action<object> onSaveClick;
        protected virtual void SaveClick(object result)
        {
            Action<object> handler = onSaveClick;
            if(handler != null)
                handler(result);
        }
        public ctrlEditPersonInfo()
        {
            InitializeComponent();
            _countryServices = new CountryServices(new SqlCountryRepository());
        }
        
        private void ctrlEditPersonInfo_Load(object sender, EventArgs e)
        {
            Prepare();
        }
        private void Prepare()
        {
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            
            Load_Countries();
            Load_Controls();
        }
        public void Load_Person(Person person)
        {
            this._person = person;
            if(this._person?.ID !=-1) 
                mode= enMode.update;
            else mode= enMode.add;
            Prepare();
        }
        private void Load_Countries()
        {
            DataTable Countries = new DataTable();
            Countries = _countryServices.GetAllCountries();
            cbCountries.DataSource = Countries.DefaultView;
            cbCountries.DisplayMember = "CountryName";
            cbCountries.SelectedIndex = 149;
        }
        private void Load_Controls()
        {
            if (mode == enMode.add)
                return;
            tbFirst.Text = _person.FirstName;
            tbSecond.Text = _person.SecondName;
            tbThird.Text = _person.ThirdName;
            tbLast.Text = _person.LastName;
            tbEmail.Text = _person.Email;
            tbPhone.Text = _person.Phone;
            tbNationalNo.Text = _person.NationalID.ToString();
            tbAddress.Text = _person.Address;
            dateTimePicker1.Value = _person.DateOfBirth;
            if (_person.Gender == 0)
                rbMale.Checked = true;
            else rbFemale.Checked = true;
            cbCountries.SelectedIndex = cbCountries.FindString(_countryServices.GetCountry((int)_person.NationalityID).Name);
            if(_person.ImagePath != null)
            {
                try
                {
                    pbImage.Load(_person.ImagePath);
                }
                catch (Exception)
                {

                }
            }
                
        }
        
        private void Gender_CheckedChanged(object sender, EventArgs e)
        {

            if (rbMale.Checked)
            {
                pbImage.Image = Properties.Resources.Male_512;
                _person.Gender = (byte)rbMale.Tag;
            }
            else
            {
                pbImage.Image = Properties.Resources.Female_512;
                _person.Gender = (byte)rbFemale.Tag;
            }


        }
        private void LLSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _person.ImagePath= openFileDialog1.FileName;
                pbImage.ImageLocation = _person.ImagePath;
                pbImage.Tag = 1;
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            CloseClick(null);
        }
        private bool Check_Valid_Controls()
        {
            return !(Convert.ToInt32(tbEmail.Tag) != 1 || tbFirst.Text.Length == 0 || tbSecond.Text.Length == 0
                || tbLast.Text.Length == 0 || tbPhone.Text.Length == 0 || tbNationalNo.Text.Length == 0 ||
                tbAddress.Text.Length == 0 || cbCountries.SelectedItem == null);
                
        }
        private void Raise_Fields_Errors()
        {
            string Message = "Required";
            if (tbFirst.Text.Length == 0)
                errorProvider1.SetError(tbFirst, Message);
            else errorProvider1.SetError(tbFirst, string.Empty);
            if (tbSecond.Text.Length == 0)
                errorProvider1.SetError(tbSecond, Message);
            else errorProvider1.SetError(tbSecond, string.Empty);
            if (tbLast.Text.Length == 0)
                errorProvider1.SetError(tbLast, Message);
            else errorProvider1.SetError(tbLast, string.Empty);
            if (tbNationalNo.Text.Length == 0)
                errorProvider1.SetError(tbNationalNo, Message);
            else errorProvider1.SetError(tbNationalNo, string.Empty);
            if (cbCountries.SelectedItem == null)
                errorProvider1.SetError(cbCountries, Message);
            else errorProvider1.SetError (cbCountries, string.Empty);
            if (tbPhone.Text.Length == 0)
                errorProvider1.SetError(tbPhone, Message);
            else errorProvider1.SetError(tbPhone , string.Empty);
            if (tbAddress.Text.Length == 0)
                errorProvider1.SetError(tbAddress, Message);
            else errorProvider1.SetError(tbAddress , string.Empty);

        }
        private void Fill_Person()
        {
            if(_person == null)
                _person = new Person();

            _person.FirstName = tbFirst.Text;
            _person.SecondName = tbSecond.Text;
            _person.ThirdName = tbThird.Text;
            _person.LastName = tbLast.Text;
            _person.Email = tbEmail.Text;
            _person.Phone = tbPhone.Text;
            _person.NationalID =(tbNationalNo.Text);
            _person.NationalityID =(ushort) _countryServices.GetCountry(cbCountries.Text).ID;
            _person.DateOfBirth = dateTimePicker1.Value;
            _person.Address = tbAddress.Text;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!Check_Valid_Controls())
            {
                MessageBox.Show("Complete the fields","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Raise_Fields_Errors();
                return;
            }
                

            bool Succeeded = false; 
            Fill_Person();
            PersonServices personServices= new PersonServices(new SqlPersonRepository());

                Succeeded = personServices.Save(_person);

            if(Succeeded)
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveClick(_person);
            }
        }

        

        private void tbEmail_Leave(object sender, CancelEventArgs e)
        {
            if (!(tbEmail.Text.Contains("@") && tbEmail.Text.Contains(".")) && tbEmail.Text.Length > 0)
            {
                errorProvider1.SetError(tbEmail, "Invalid Email");
                tbEmail.Tag = 2;
            }
            else
            {
                tbEmail.Tag = 1;
                errorProvider1.SetError(tbEmail,string.Empty);
            }

        }
    }
}
