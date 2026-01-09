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
    public partial class TestAppointment : Form
    {
        private readonly TestAppointmentServices _testAppointmentServices;
        //private TestAppointmentDto _testAppointment;
        private LDLApplicationDto _LDLapp;
        private LDLApplicationServices _LDLappServices;
        private TestTypeServices _testTypeServices;
        private TestType _testType;
        public TestAppointment(int lDLappID)
        {
            InitializeComponent();
            _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _LDLapp = _LDLappServices.GetLDLApplication(lDLappID);
            _testAppointmentServices = new TestAppointmentServices(new SqlTestAppointmentRepository(),new ApplicationServices(new SqlApplicationRepository()),new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()),new TestSharedServices(),new SqlLDLApplicationRepository()),new TestSharedServices());
            _testTypeServices = new TestTypeServices(new SqlTestTypeRepository());
        }

        private void TestAppointment_Load(object sender, EventArgs e)
        {
            if (!CheckQualified())
                Prevent();
            else Prepare();
        }
        private void Prepare()
        {
            ctrLDLApplicationInfo1.Load_LDLApp(_LDLapp.LDLApplication.ID);
            ctrlAppBasicInfo1.Load_Application(_LDLapp.Application.ID);
            LoadAppointments();

            lbTitle.Text = _testType.Title + " Appointments";
            lbRecords.Text = dataGridView1.Rows.Count.ToString();

            switch (_testType.ID)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.Vision_512;
                    break;
                    case 2:
                    pictureBox1.Image = Properties.Resources.Written_Test_512;
                    break;
                    case 3:
                    pictureBox1.Image= Properties.Resources.Street_Test_32;
                    break;

                default:
                    pictureBox1.Image = Properties.Resources.Vision_512;
                    break;
            }
        }
        private void Prevent()
        {
            MessageBox.Show("This application is unqualified to make appointments","Prohibited",MessageBoxButtons.OK,MessageBoxIcon.Error);
            this.Close();
        }
        private bool CheckQualified()
        {
            int testTypeID = _testAppointmentServices.GetTestTypeForTestAppointment(_LDLapp.LDLApplication.ID);
            
            if (testTypeID == 0)
                return false;

            _testType = _testTypeServices.GetTestType(testTypeID);
            return true;
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadAppointments()
        {
            dataGridView1.DataSource = _testAppointmentServices.GetAllTestAppointmentsByTestTypeByAppID(_LDLapp.LDLApplication.ID, _testType.ID);
        }
        private void btAddAppointment_Click(object sender, EventArgs e)
        {
            ScheduleTest form = new ScheduleTest(_LDLapp.LDLApplication.ID,_testType.ID);
            form.ShowDialog();
            LoadAppointments();

        }

        private void msIEdit_Click(object sender, EventArgs e)
        {
            int testAppointmentID= (int)dataGridView1.CurrentRow.Cells[0].Value;
            ScheduleTest form = new ScheduleTest(testAppointmentID);
            form.ShowDialog();
            LoadAppointments();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int testAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            TakeTest form = new TakeTest(testAppointmentID);
            form.ShowDialog();
            LoadAppointments();
        }
    }
    }

