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
using DVLD_BLL;
using DVLD_DAL;
namespace DVLD.UserControls
{
    public partial class ctrlLoginInformation : UserControl
    {
        private User _user;
        private UserServices _userServices;
        public ctrlLoginInformation()
        {
            InitializeComponent();
            _userServices = new UserServices(new SqlUserRepository());  
        }

        private void ctrlLoginInformation_Load(object sender, EventArgs e)
        {

        }
        public void Load_User(User user)
        {
            _user = user;
            if (_user != null)
                Fill_Controls();
            else Empty_Controls();
        }
        private void Fill_Controls()
        {
            lbUserID.Text= _user.UserID.ToString();
            lbUsername.Text = _user.Username.ToString();
            lbIsActive.Text = _user.IsActive ? "Yes" : "No";
        }
        private void Empty_Controls()
        {
            string uniformedText = "????";
            lbUserID.Text = uniformedText;
            lbUsername.Text = uniformedText;
            lbIsActive.Text = uniformedText;
        }
    }
}
