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

namespace DVLD.UserControls
{
    public partial class ctrlRetakeTestInfo : UserControl
    {
        private readonly TestAppointmentServices _testAppointmentServices;
        private TestAppointmentDto _testAppointmentDto;
        private ApplicationTypeServices _appTypeServices;
        private TestTypeServices _testTypeServices;
        public ctrlRetakeTestInfo()
        {
            InitializeComponent();
            _testAppointmentServices = new TestAppointmentServices(new SqlTestAppointmentRepository(), new ApplicationServices(new SqlApplicationRepository()), new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository()), new TestSharedServices());
            _appTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
            _testTypeServices = new TestTypeServices(new SqlTestTypeRepository());
        }

        private void ctrlRetakeTestInfo_Load(object sender, EventArgs e)
        {

        }
        public void Load_Info(TestAppointmentDto testAppointment)
        {
            _testAppointmentDto = testAppointment;
            if(_testAppointmentDto.ReTakeApp != null)
            Fill_Controls();
            else Empty_Controls();
        }
        private void Fill_Controls()
        {
            double AppFees = _testAppointmentDto.ReTakeApp==null ? 0 : _appTypeServices.GetApplicationType(_testAppointmentDto.ReTakeApp.TypeID).Fees;
            double TotalFees = AppFees + _testTypeServices.GetTestType(_testAppointmentDto.TestAppointment.TestTypeID)?.Fees ?? 0;

            lbID.Text = _testAppointmentDto.ReTakeApp?.ID == -1 ? "N\\A" : _testAppointmentDto.ReTakeApp?.ID.ToString();
            lbAppFees.Text = AppFees.ToString();
            lbTotalFees.Text = TotalFees.ToString();
        }
        private void Empty_Controls()
        {
            lbID.Text = "N\\A";
            lbAppFees.Text = "0";
            lbTotalFees.Text = _testTypeServices.GetTestType(_testAppointmentDto.TestAppointment.TestTypeID)?.Fees.ToString() ?? "0";
        }
    }
}
