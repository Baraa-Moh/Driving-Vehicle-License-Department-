using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using DVLD_BLL;
using DVLD_DAL;
namespace DVLD.People
{
    public partial class AddUpdatePerson : Form
    {
        private Person _person;
        private PersonServices _services;

        public delegate void PersoIDBackHandler(int PersonID);
        public event PersoIDBackHandler PersonIDBack;
        public AddUpdatePerson(int ID)
        {
            InitializeComponent();
            _services = new PersonServices(new SqlPersonRepository());
            _person = ID == -1 ? new Person() : _services.FindPersonByID(ID);
        }
        public AddUpdatePerson()
        {
            InitializeComponent();
            _services = new PersonServices(new SqlPersonRepository());
            _person = new Person();  
        }
        private void AddUpdatePerson_Load(object sender, EventArgs e)
        {
            if(_person == null)
            {
                MessageBox.Show("The person doesn't exist anymore");
                this.Close();
            } 
                
            Prepare();
        }
        private void Prepare()
        {
            if (_person?.ID != -1)
            {
                lbTitle.Text = "Update Person";
                lbID.Text = _person.ID.ToString();
                lbNationalNo.Text = _person.NationalID.ToString();
            }
            else
            {
                lbTitle.Text = "Add New Person";
                lbPersonID.Text= string.Empty;
                lbNationalNo.Text = "N/A";
            }
            ctrlEditPersonInfo1.Load_Person(_person);
        }

        private void ctrlEditPersonInfo1_onSaveClick(object obj)
        {
            PersonIDBack?.Invoke(_person.ID);
            this.Close();
            Prepare();
        }

        private void ctrlEditPersonInfo1_onCloseClick(object obj)
        {
            this.Close();
        }
    }
}
