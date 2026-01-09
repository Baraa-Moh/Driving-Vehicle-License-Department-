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
    public partial class UserInfo : Form
    {
        private User _user;
        private UserServices _userServices;
        public UserInfo(int UserID)
        {
            InitializeComponent();
            _userServices = new UserServices(new SqlUserRepository());
            _user= _userServices.GetUserByUserID(UserID);
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails1.Load_Person(_user.PersonID);
            ctrlLoginInformation1.Load_User(_user);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
