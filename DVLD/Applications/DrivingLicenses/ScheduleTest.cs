using Common;
using DVLD_BLL;
using DVLD_BLL.DTOs;
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

namespace DVLD.Applications.DrivingLicenses
{
    public partial class ScheduleTest : Form
    {
        private enum enMode { add,update};
        private enMode _mode;
        private int _LDLAppID;
        private TestAppointmentServices _testAppointmentServices;
        private TestAppointmentDto _testAppointment;
        private TestTypeServices _testTypeServices;
        private TestType _testType;
        private LicenseClassServices _licenseClassServices;
        private PersonServices _personServices;
        private TestServices _testServices;
        public ScheduleTest(int LDLAppID, int testType)
        {
            InitializeComponent();
            _mode = enMode.add;
            _LDLAppID = LDLAppID;
            _testAppointmentServices = new TestAppointmentServices(new SqlTestAppointmentRepository(), new ApplicationServices(new SqlApplicationRepository()), new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository()), new TestSharedServices());
            _testAppointment = _testAppointmentServices.SetNewTestAppointment(LDLAppID);
            _testTypeServices = new TestTypeServices(new SqlTestTypeRepository());
            _testType = _testTypeServices.GetTestType(testType);
            _licenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
            _personServices = new PersonServices(new SqlPersonRepository());
            _testServices = new TestServices(new SqlTestRepository(), new TestSharedServices());
        }
        public ScheduleTest(int testAppointmentID)
        {
            InitializeComponent();
            _mode = enMode.update; 
            _testAppointmentServices = new TestAppointmentServices(new SqlTestAppointmentRepository(), new ApplicationServices(new SqlApplicationRepository()), new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository()), new TestSharedServices());
            _testAppointment = _testAppointmentServices.GetTestAppointment(testAppointmentID);
            _testTypeServices = new TestTypeServices(new SqlTestTypeRepository());
            _testType = _testTypeServices.GetTestType(_testAppointment.TestAppointment.TestTypeID);
            _licenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
            _personServices = new PersonServices(new SqlPersonRepository());
            _testServices = new TestServices(new SqlTestRepository(), new TestSharedServices());
            _LDLAppID = _testAppointment.LDLApplicationDto.LDLApplication.ID;
        }
        private void ScheduleTest_Load(object sender, EventArgs e)
        {
            string error = null;
            if (!CheckQualified(ref error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
             else Prepare();
        }
        private bool CheckQualified(ref string error)
        {
            int foundID = 0; ;
            if (_testAppointmentServices.CheckHasActiveAppointment(_LDLAppID, _testType.ID,ref foundID)&& _mode==enMode.add)
            {
                error = $"Person already has an active appointment with ID[{foundID}]";
                return false;
            }
            if(_testAppointmentServices.GetTestTypeForTestAppointment(_LDLAppID)!= _testType.ID)
            {
                error = "Unqualified for this test type yet";
                return false; ;
            }
            else return true;
        }
        private void Prepare()
        {
            Fill_Fields();

            if (_testAppointment.TestAppointment.isLocked)
            {
                lbDisabledMessage.Text = "Person already sat for the test, appointment is locked.";
                dtpDate.Enabled = false;
                btSave.Enabled = false;
            }   
        }
        private void Fill_Fields()
        {
            groupBox1.Text = _testType.Title;
            lbLDLAppID.Text = _testAppointment.LDLApplicationDto.LDLApplication.ID.ToString();
            lbLicenseClass.Text = _licenseClassServices.GetLicenseClass(_testAppointment.LDLApplicationDto.LDLApplication.LicenseClassID).ToString();
            lbName.Text = _personServices.GetPerson(_testAppointment.LDLApplicationDto.Application.PersonID).FullName;
            lbTrial.Text = _testServices.GetNumberOfTrials(_LDLAppID, _testType.ID).ToString();
            dtpDate.Value = _testAppointment.TestAppointment.AppointmentDate;
            lbFees.Text = _testType.Fees.ToString(); ;

            if (_testType.ID == 1)
                pictureBox1.Image = Properties.Resources.Vision_512;
            else if (_testType.ID == 2)
                pictureBox1.Image = Properties.Resources.Written_Test_512;
            else pictureBox1.Image = Properties.Resources.Street_Test_321;

            ctrlRetakeTestInfo1.Load_Info(_testAppointment);
            if (_testAppointment.ReTakeApp == null)
                ctrlRetakeTestInfo1.Enabled = false;
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Fill_Appointment()
        {
            _testAppointment.TestAppointment.LDLApplicationID = Convert.ToInt32(lbLDLAppID.Text);
            _testAppointment.TestAppointment.AppointmentDate = dtpDate.Value;
            _testAppointment.TestAppointment.PaidFees = Convert.ToDouble(lbFees.Text);
            _testAppointment.TestAppointment.CreatedByUserID = Core.CurrentUser.UserID;
            _testAppointment.TestAppointment.isLocked = false;

            if (_testAppointment.ReTakeApp != null && _mode== enMode.add)
            {
                _testAppointment.ReTakeApp.Date =DateTime.Now;
                _testAppointment.ReTakeApp.LastStatuesDate = DateTime.Now;
                _testAppointment.ReTakeApp.PersonID = _testAppointment.LDLApplicationDto.Application.PersonID;
                _testAppointment.ReTakeApp.CreatedBy= Core.CurrentUser.UserID ;
                _testAppointment.ReTakeApp.Status = 1;
            }
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            Fill_Appointment();
            
            string error = null;
            if (_testAppointmentServices.Save(_testAppointment, ref error))
            {
                ctrlRetakeTestInfo1.Load_Info(_testAppointment);
                MessageBox.Show("Saved", "Saved");
            }
            else
            {
                MessageBox.Show(error,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
