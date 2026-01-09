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

namespace DVLD.Users
{
    public partial class Login : Form
    {
        UserServices _userServices;
        public Login()
        {
            InitializeComponent();
            _userServices = new UserServices(new SqlUserRepository());
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (Settings1.Default.Username.Length != 0)
            {
                chbRememberMe.Checked = true;
                tbUsername.Text = Settings1.Default.Username;
                mtbPassword.Text = Settings1.Default.Password;
            }
            Core.CurrentUser = null;
        }
        private void Empty_Fields()
        {
            tbUsername.Text = string.Empty;
            mtbPassword.Text= string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Core.CurrentUser = _userServices.Validate_Login(tbUsername.Text, mtbPassword.Text);
            if (Core.CurrentUser == null)
            {
                MessageBox.Show("Invalid Password/Username", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Empty_Fields();
                return;
            }
            
            if(!Core.CurrentUser.IsActive)
            {
                MessageBox.Show("The user isn't active currently","Isn't active",MessageBoxButtons.OK, MessageBoxIcon.Error);
                Empty_Fields();
                return;
            }

            if(chbRememberMe.Checked)
            {
                Settings1.Default.Username = tbUsername.Text;
                Settings1.Default.Password = mtbPassword.Text;
            }
            else
            {
                Settings1.Default.Username =string.Empty;
                Settings1.Default.Password = string.Empty;
            }
            MainMenu form = new MainMenu();
            form.ShowDialog();
            if (!chbRememberMe.Checked)
                Empty_Fields();
        }
    }
}
