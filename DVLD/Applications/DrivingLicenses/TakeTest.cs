using DVLD_BLL;
using DVLD_BLL.DTOs;
using DVLD_DAL;
using Common;
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
    public partial class TakeTest : Form
    {
        private TestAppointmentDto _testAppointment;
        private TestDto _testDto;
        private TestServices _testServices;
        private TestAppointmentServices _testAppointmentServices;
        private LicenseClassServices _licenseClassServices;
        private PersonServices _personServices;
        public TakeTest(int testAppointmentID)
        {
            InitializeComponent();
            _testAppointmentServices = new TestAppointmentServices(new SqlTestAppointmentRepository(), new ApplicationServices(new SqlApplicationRepository()), new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository()), new TestSharedServices());
            _testAppointment = _testAppointmentServices.GetTestAppointment(testAppointmentID);
            _testServices = new TestServices(new SqlTestRepository(), new TestSharedServices());
            _licenseClassServices = new LicenseClassServices(new SqlLicenseClassRepository());
            _personServices = new PersonServices(new SqlPersonRepository());
            _testDto = new TestDto(new Test(), _testAppointment.TestAppointment);
        }

        private void TakeTest_Load(object sender, EventArgs e)
        {
            Prepare();
        }
        private void Prepare()
        {
            Fill_Fields();
        }
        private void Fill_Fields()
        {
            lbLDLAppID.Text = _testAppointment.TestAppointment.LDLApplicationID.ToString();
            lbName.Text = _personServices.GetPerson(_testAppointment.LDLApplicationDto.Application.PersonID).FullName;
            lbLicenseClass.Text = _licenseClassServices.GetLicenseClass(_testAppointment.LDLApplicationDto.LDLApplication.LicenseClassID).Name;
            lbTrial.Text = _testServices.GetNumberOfTrials(_testAppointment.LDLApplicationDto.LDLApplication.ID,
                _testAppointment.TestAppointment.TestTypeID).ToString();
            lbDate.Text = _testAppointment.TestAppointment.AppointmentDate.ToString();
            lbFees.Text = _testAppointment.TestAppointment.PaidFees.ToString();

            if (_testDto.Test.TestID == -1)
                lbTestID.Text = "Not Taken Yet";
            else lbTestID.Text = _testDto.Test.TestID.ToString();

            if (_testAppointment.TestAppointment.TestTypeID == 1)
            {
                pictureBox1.Image = Properties.Resources.Vision_512;
                groupBox1.Text = "Vision Test";
            }
            else if (_testAppointment.TestAppointment.TestTypeID == 2)
            {
                pictureBox1.Image = Properties.Resources.Written_Test_512;
                groupBox1.Text = "Written Test";
            }
            else
            {
                pictureBox1.Image = Properties.Resources.Street_Test_321;
                groupBox1.Text = "Street Test";
            }
        }
        private void Fill_Test()
        {
            _testDto.Test.Notes=tbNotes.Text;
            _testDto.Test.TestResult = rbPass.Checked ? true : false;
            _testDto.Test.CreatedByUserID = Core.CurrentUser.UserID;
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Fill_Test();

            string error = null;
            

            if (_testServices.Save(_testDto, ref error, _testAppointment))
            {
                MessageBox.Show("Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
