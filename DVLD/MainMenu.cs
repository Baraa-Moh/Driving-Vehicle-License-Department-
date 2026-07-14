using Common;
using DVLD.People;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Applications;
using DVLD.Applications.DrivingLicenses;
namespace DVLD
{
    public partial class MainMenu : Form
    {
        Login _loginForm;
        bool _exitApp = true;
        public MainMenu(Login loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ManagePeople form = new ManagePeople();
            form.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageUsers form = new ManageUsers();
            form.ShowDialog();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo form = new UserInfo(Core.CurrentUser.UserID);
            form.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword(Core.CurrentUser.UserID);
            form.ShowDialog(); 
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Core.CurrentUser = null;
            _loginForm.Show();
            _exitApp = false;
            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypes form = new ManageApplicationTypes();
            form .ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypes form = new ManageTestTypes();
            form .ShowDialog();
        }

        private void localDrivingLicesnsApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLDLApplications form = new ManageLDLApplications();
            form .ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriversList form = new DriversList();
            form.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLDLApplication form = new NewLDLApplication();
            form.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInternationalLicenseApp form = new NewInternationalLicenseApp();
            form.ShowDialog();
        }

        private void renewDrivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLicenseApp form = new RenewLicenseApp();
            form.ShowDialog();
        }

        private void replacementForDamagedOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementForLostOrDamaged form = new ReplacementForLostOrDamaged();
            form.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLDLApplications form = new ManageLDLApplications();
            form.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicense form = new DetainLicense();
            form.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetain form = new ReleaseDetain();
            form.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(_exitApp)
                System.Windows.Forms.Application.Exit();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ManageDetainedLicenses form = new ManageDetainedLicenses();
            //form.ShowDialog();
        }
    }
}
