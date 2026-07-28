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
using Microsoft.Win32;
using System.Diagnostics;

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
            try
            {
                string value = Registry.GetValue(Core.KeyPath, "RememberMeChecked", null) as string ?? "False";
                chbRememberMe.Checked = value.Equals("True");

                if(chbRememberMe.Checked)
                {
                    tbUsername.Text = Registry.GetValue(Core.KeyPath, "Username", null) as string ?? "";
                    mtbPassword.Text = Registry.GetValue(Core.KeyPath, "Password", null) as string ?? "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Core.LogEvent("Error in retrieving user's credential", EventLogEntryType.Error);
                throw;
            }
        }
        private void Empty_Fields()
        {
            tbUsername.Text = string.Empty;
            mtbPassword.Text= string.Empty;
        }
        private void btLogin_Click(object sender, EventArgs e)
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

            Store_Credential();
            
            this.Hide();
            MainMenu form = new MainMenu(this);
            form.ShowDialog();

            if (!chbRememberMe.Checked)
                Empty_Fields();
        }
        private void button2_Click(object sender, EventArgs e)
        {
             this.Close();
        }
        private void Store_Credential()
        {
            string Username = chbRememberMe.Checked ? tbUsername.Text.Trim() : "";
            string Password = chbRememberMe.Checked ? mtbPassword.Text.Trim() : "";
                        
            try
            {
                Registry.SetValue(Core.KeyPath, "Username", Username);
                Registry.SetValue(Core.KeyPath, "Password", Password);
                Registry.SetValue(Core.KeyPath, "RememberMeChecked", chbRememberMe.Checked);
            }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
        }
    }
}
