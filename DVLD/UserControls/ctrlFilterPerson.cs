using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using DVLD.People;
using DVLD_BLL;
using DVLD_DAL;

namespace DVLD.UserControls
{
    public partial class ctrlFilterPerson : UserControl
    {
        private int _personID;
        private PersonServices _personServices;
        //Here I use it even if it's not found then I send -1
        public event Action<int> OnPersonFound;
        protected virtual void PersonFound(int personID)
        {
            Action<int> handler = OnPersonFound;
            if (handler != null) 
                handler(personID);
        }
        public ctrlFilterPerson()
        {
            InitializeComponent();
            _personServices = new PersonServices(new SqlPersonRepository());
        }

        private void ctrlFilterPerson_Load(object sender, EventArgs e)
        {
            cbFilters.SelectedIndex = 0;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if(cbFilters.SelectedIndex == 0)
            {
                if (_personServices.CheckExistsByNationalNo(tbID.Text))
                {
                    _personID = _personServices.FindPersonByNationalNo(tbID.Text).ID;
                    PersonFound(_personID);
                }
                else
                {
                    MessageBox.Show($"No person with NationalNo = {tbID.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PersonFound(-1);
                }
            }
            else if(cbFilters.SelectedIndex == 1)
            {
                if (_personServices.CheckExistsByPersonID(Convert.ToInt32(tbID.Text))){
                    _personID = Convert.ToInt32(tbID.Text);
                    PersonFound(_personID);
                }
                else
                {
                    MessageBox.Show($"No person with PersonID = {tbID.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PersonFound(-1);

                }
            }
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.SelectedIndex == 1)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }
        
        private void btAddPerson_Click(object sender, EventArgs e)
        {
            AddUpdatePerson form = new AddUpdatePerson();
            form.PersonIDBack += PersonID_Back;
            form.ShowDialog();
        }
        private void PersonID_Back(int id)
        {
            _personID = id;
            PersonFound(id);
            if(cbFilters.SelectedIndex == 0)
                tbID.Text = _personServices.FindPersonByID(_personID).NationalID;
            if (cbFilters.SelectedIndex == 1)
                tbID.Text = _personID.ToString();
        }
    }
}
