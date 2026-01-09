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
    public partial class ChangePassword : Form
    {
        private User _user;
        private UserServices _userServices;
        public ChangePassword(int UserID)
        {
            InitializeComponent();
            _userServices = new UserServices(new SqlUserRepository());
            _user = _userServices.GetUserByUserID(UserID);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails1.Load_Person(_user.PersonID);
            ctrlLoginInformation1.Load_User(_user);
        }
        private bool Validate_Fields()
        {
            bool valid = true;
            if (mtbConfirmPassword.Text.Length == 0)
            {
                valid = false;
                errorProvider1.SetError(mtbCurrentPassword, "Required");
            }
            else errorProvider1.SetError(mtbCurrentPassword, string.Empty);

            if (mtbNewPassword.Text.Length == 0)
            {
                valid = false;
                errorProvider1.SetError(mtbNewPassword, "Required");
            }
            else errorProvider1.SetError(mtbNewPassword, string.Empty);

            if (mtbConfirmPassword.Text.Length == 0)
            {
                valid = false;
                errorProvider1.SetError(mtbConfirmPassword, "Required");
            }
            else errorProvider1.SetError(mtbConfirmPassword, string.Empty);

            if (mtbNewPassword.Text.Length != 0 && mtbNewPassword.Text != mtbConfirmPassword.Text)
            {
                valid = false;
                errorProvider1.SetError(mtbConfirmPassword, "Doesn't match");
            }
            else errorProvider1.SetError(mtbConfirmPassword, string.Empty);

                return valid;
        }
        private void Clear_Fields()
        {
            mtbCurrentPassword.Clear();
            mtbNewPassword.Clear();
            mtbConfirmPassword.Clear();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!Validate_Fields())
                return;

            string ErrorMessage = null;
            if (!_userServices.Change_Password(_user.Username, mtbCurrentPassword.Text, mtbNewPassword.Text, ref ErrorMessage))
            {
                MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Data Saved Successfully", "Saved");
                Clear_Fields();
            }
        }
    }
}
