using Common;
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

namespace DVLD.Users
{
    public partial class AddUpdateUser : Form
    {
        private bool _allowTabChange=false;
        private int _userID;
        private User _user;
        private UserServices _userServices;
        private enum enMode { Add, Update }
        private enMode _Mode;
        public AddUpdateUser()
        {
            InitializeComponent();
            _user = new User();
            _userServices = new UserServices(new SqlUserRepository());
            _Mode = enMode.Add;
        }
        public AddUpdateUser(int userID)
        {
            InitializeComponent();
            _userServices= new UserServices(new SqlUserRepository());
            _userID = userID;
            _Mode= enMode.Update;
        }
        private void AddUpdateUser_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                _user = _userServices.GetUserByUserID(_userID);
                Change_ToUpdate();
            }
                
            
               
        }
        private void Change_ToUpdate()
        {
            if (_Mode != enMode.Update)
                return;

            if (!_userServices.CheckUserExistsByUserID(_user.UserID))
            {
                MessageBox.Show("The user doesn't exist anymore","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            ctrlFindShowPersonDetails1.Load_Information(_user.PersonID);
            ctrlFindShowPersonDetails1.EnableFilter = false;
            lbUserID.Text = _user.UserID.ToString();
            tbUsername.Text = _user.Username;
            chbIsActive.Checked = _user.IsActive;
            lbTitle.Text = "Update User";            
        }
        
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(!_allowTabChange)
            {
                e.Cancel = true;
            }
        }
        private void btNext_Click(object sender, EventArgs e)
        {
            if(_user.PersonID == -1)
            {
                MessageBox.Show("First Find a person","Find a person",MessageBoxButtons.OK, MessageBoxIcon.Error);
                _allowTabChange = false;
                btSave.Enabled = false;
            }
            else
            {
                if(_userServices.CheckUserExistsByPersonID(_user.PersonID)&& _Mode== enMode.Add)
                {
                    _allowTabChange = false;
                    btSave.Enabled = false;
                    MessageBox.Show("Selected person already has a user, choose another one", "Select another person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _allowTabChange = true;
                    tabControl1.SelectedIndex = 1;
                    btSave.Enabled = true;
                }
            }
        }
        private void ctrlFindShowPersonDetails1_OnPersonFound(int obj)
        {
            _user.PersonID=obj;  
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool Validate_Fields()
        {
            bool Valid = true;
            if(tbUsername.Text.Length == 0)
            {
                Valid = false;
                errorProvider1.SetError(tbUsername, "Required");
            }else errorProvider1.SetError(tbUsername,string.Empty);
            if(mtbPassword.Text.Length == 0)
            {
                Valid =false;
                errorProvider1.SetError(mtbPassword, "Required");
            }else errorProvider1.SetError(mtbPassword, string.Empty);
            if(mtbConfirmPassword.Text.Length == 0)
            {
                Valid =false;
                errorProvider1.SetError(mtbConfirmPassword, "Required");
            }else errorProvider1.SetError(mtbConfirmPassword, string.Empty); 
            if(mtbPassword.Text.Length!=0 && mtbConfirmPassword.Text.Length != 0)
            {
                if (mtbPassword.Text != mtbConfirmPassword.Text)
                {
                    Valid=false;
                    errorProvider1.SetError(mtbConfirmPassword, "Doesn't Match");
                }else errorProvider1.SetError(mtbConfirmPassword,string.Empty);
            }
               return Valid; 
        }
        private void Fill_User()
        {
            _user.Username = tbUsername.Text;
            _user.Password = mtbPassword.Text;
            _user.IsActive = chbIsActive.Checked;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!Validate_Fields())
                return;

            Fill_User();
            if (_userServices.Save(ref _user))
            {
                MessageBox.Show("Data has been saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                Change_ToUpdate();
            }
            else MessageBox.Show("Data has not been saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ctrlFindShowPersonDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
