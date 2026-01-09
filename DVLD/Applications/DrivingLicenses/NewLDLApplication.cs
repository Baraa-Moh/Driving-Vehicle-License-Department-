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
using Common;
using DVLD_BLL.DTOs;
using DVLD.UserControls;

namespace DVLD.Applications.DrivingLicenses
{
    public partial class NewLDLApplication : Form
    {
        enum enMode { Add,Update}
        enMode _mode;
        private LDLApplicationDto _LDLapp;
        private LDLApplicationServices _LDLappServices;
        private PersonServices _personServices;
        private LicenseClassServices _licenseClassServices;
        ApplicationTypeServices _appTypeServices; 
        private readonly int _TypeID;
        private bool _allowTabChange;
        public NewLDLApplication()
        {
            InitializeComponent();
            _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository()); 
            _personServices = new PersonServices(new SqlPersonRepository());
            _licenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
            _appTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
            _TypeID = 1;
            _LDLapp = new LDLApplicationDto();
            _mode = enMode.Add;
        }
        public NewLDLApplication(int LDLappID)
        {
            InitializeComponent();
            _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _personServices = new PersonServices(new SqlPersonRepository());
            _appTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
            _TypeID = 1;
            _LDLapp = _LDLappServices.GetLDLApplication(LDLappID);
            _mode = enMode.Update;
        }
        private void NewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            if(_LDLapp == null || (_mode==enMode.Update&& _LDLapp.Application.Status!=1))
            {
                MessageBox.Show("This application doesn't exist anymore","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            if (_mode ==enMode.Update)
                Change_ToUpdate();
            else Fill_Controls();
        }
        private void Change_ToUpdate()
        {
            if (_mode != enMode.Update)
                return;

            ctrlFindShowPersonDetails1.EnableFilter = false;
            ctrlFindShowPersonDetails1.Load_Information(_LDLapp.Application.PersonID);
            _allowTabChange = true;
            lbLDLApplicationID.Text = _LDLapp.LDLApplication.ID.ToString();
            lbApplicationDate.Text = _LDLapp.Application.Date.ToString();   
        }
        private void Fill_Controls()
        {
            lbLDLApplicationID.Text = "??????";
            lbApplicationDate.Text = DateTime.Now.ToString();
            lbCreatedBy.Text = Core.CurrentUser.Username;
            lbFees.Text= _appTypeServices.GetApplicationType(_TypeID).Fees.ToString();
            Load_LicenseClasses();
        }
        private void Load_LicenseClasses()
        {
            cbClasses.DataSource = _licenseClassServices.GetAllLicenseClass();
            cbClasses.DisplayMember = "ClassName";
            cbClasses.ValueMember = "LicenseClassID";
            cbClasses.SelectedValue = 3;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_allowTabChange)
            {
                e.Cancel = true;
            }
        }

        private void btClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (!_personServices.CheckExistsByPersonID(_LDLapp.Application.PersonID))
            {
                _allowTabChange=false;
                btSave.Enabled = false;
                MessageBox.Show("First Find a person", "Find a person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _allowTabChange = true;
                btSave.Enabled = true;
                tabControl1.SelectedIndex = 1;
            }
        }

        private void ctrlFindShowPersonDetails1_OnPersonFound(int obj)
        {
            _LDLapp.Application.PersonID = obj;
            if(obj == -1)
            {
                _allowTabChange = false;
                btSave.Enabled=false;
            }
        }
        private void Fill_LDLapp()
        {
            _LDLapp.Application.Date = Convert.ToDateTime(lbApplicationDate.Text);
            _LDLapp.Application.TypeID = _TypeID;
            _LDLapp.LDLApplication.LicenseClassID = Convert.ToInt32(cbClasses.SelectedValue);
            _LDLapp.Application.PaidFees = Convert.ToDouble(lbFees.Text);
            _LDLapp.Application.CreatedBy = Core.CurrentUser.UserID;
            _LDLapp.Application.Status = 1;
            _LDLapp.Application.LastStatuesDate = DateTime.Now;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            Fill_LDLapp();
            string error = null;
            if (_LDLappServices.Save(_LDLapp,ref error))
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _mode=enMode.Update;
                Change_ToUpdate();
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
