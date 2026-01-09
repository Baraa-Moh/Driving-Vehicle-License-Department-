using Common;
using DVLD_BLL.DTOs;
using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class TestAppointmentServices 
    {
        private readonly ITestAppointmentRepository _rep;
        private readonly TestSharedServices _sharedServices;
        private readonly LDLApplicationServices _LDLAppServices;
        private readonly ApplicationServices _appServices;
        public TestAppointmentServices(ITestAppointmentRepository rep, ApplicationServices appServices, LDLApplicationServices LDLApplicationServices, TestSharedServices sharedServices)
        {
            _rep = rep;
            _appServices = appServices;
            _LDLAppServices = LDLApplicationServices;
            _sharedServices = sharedServices;
        }

        public DataTable GetAllTestAppointmentsByAppID(int personID)
        {
            return _rep.GetAllTestAppointmentsByAppID(personID);
        }
        public TestAppointmentDto GetTestAppointment(int testAppointmentID)
        {
            TestAppointmentDto testAppointment = new TestAppointmentDto();
            testAppointment.TestAppointment = _rep.GetTestAppointment(testAppointmentID);

            if (testAppointment.TestAppointment == null)
                return null;

            testAppointment.LDLApplicationDto = _LDLAppServices.GetLDLApplication(testAppointment.TestAppointment.LDLApplicationID);
            return testAppointment;
        }
        public DataTable GetAllTestAppointmentsByTestTypeByAppID(int LDLAppID, int TestTypeID)
        {
            DataTable testAppointments = GetAllTestAppointmentsByAppID(LDLAppID);
            if(testAppointments == null)
                return null;

            DataRow[] filteredRows = testAppointments.Select($"TestTypeID = {TestTypeID}");
            if (filteredRows.Length == 0)
                return null;

            DataTable filteredTable = filteredRows.CopyToDataTable();
            AdjustTestAppointmentsTable(filteredTable);
            return filteredTable;
        }
        public TestAppointmentDto SetNewTestAppointment(int LDLAppID)
        {
            LDLApplicationDto LDLApp = _LDLAppServices.GetLDLApplication(LDLAppID);
            TestAppointment testAppointment= new TestAppointment();
            Application retakeApp = null;
            
            testAppointment.LDLApplicationID = LDLAppID;
            testAppointment.TestTypeID = GetTestTypeForTestAppointment(LDLAppID);
            testAppointment.AppointmentDate = DateTime.Now;

            if (_sharedServices.HasFailedTest(LDLAppID, testAppointment.TestTypeID))
            {
                retakeApp = new Application();
                retakeApp.TypeID = 8;
                retakeApp.PersonID = LDLApp.Application.PersonID;
                retakeApp.CreatedBy = Core.CurrentUser.UserID;
            }
            return new TestAppointmentDto(LDLApp, testAppointment,retakeApp);
        }
        public int GetTestTypeForTestAppointment(int LDLApp)
        {
            if (!_sharedServices.CheckPassedTestType(LDLApp, 1))
                return 1;

            if (!_sharedServices.CheckPassedTestType(LDLApp, 2))
                return 2;

            if (!_sharedServices.CheckPassedTestType(LDLApp, 3))
                return 3;

            return 0;
        }
        private void AdjustTestAppointmentsTable(DataTable testAppointments)
        {
            testAppointments.Columns.Remove("TestTypeID");
            testAppointments.Columns.Remove("CreatedByUserID");
            testAppointments.Columns.Remove("LocalDrivingLicenseApplicationID");

            testAppointments.Columns["TestAppointmentID"].ColumnName = "Appointment ID";
            testAppointments.Columns["AppointmentDate"].ColumnName = "Appointment Date";
            testAppointments.Columns["PaidFees"].ColumnName = "Paid Fees";
            testAppointments.Columns["IsLocked"].ColumnName = "Is Locked";
        }
        public bool CheckHasActiveAppointment(int LDLAppID, int testTypeID, ref int FoundID)
        {
            bool has = false;
            DataTable appointments = GetAllTestAppointmentsByTestTypeByAppID(LDLAppID, testTypeID);
            if(appointments == null)
                return has;

            foreach(DataRow row in appointments.Rows)
            {
                if (!(bool)row["Is Locked"])
                {
                    has = true;
                    FoundID = (int)row[0];
                    break;
                }
            }
            return has;
        }
        private bool ValidateAddNewInfo(TestAppointmentDto testAppointment, ref string error)
        {
            if (GetTestTypeForTestAppointment(testAppointment.TestAppointment.LDLApplicationID)
                != testAppointment.TestAppointment.TestTypeID)
            {
                error = "Not Qualified to take this test";
                return false;
            }

            if (_sharedServices.HasFailedTest(testAppointment.TestAppointment.LDLApplicationID, testAppointment.TestAppointment.TestTypeID)
                && (testAppointment.ReTakeApp == null || testAppointment.ReTakeApp.TypeID != 8))
            {
                error = "Fill Retake Application Info";
                return false;
            }

            return true;
        }
        private bool AddNew(TestAppointmentDto testAppointment, ref string error)
        {
            error = null;
            if(!ValidateAddNewInfo(testAppointment, ref error))
                return false;

            if(testAppointment.ReTakeApp != null)
            {
                _appServices.Save(testAppointment.ReTakeApp);
            }

            if (!_rep.AddNew(testAppointment.TestAppointment)){
                error = "Error";
                return false;
            }
            else return true;
        }
        private bool Update(TestAppointmentDto testAppointment, ref string error)
        {
            error = null;
            if (testAppointment.TestAppointment.isLocked)
            {
                error = "Appointment is Locked";
                return false;
            }

            if (_rep.Update(testAppointment.TestAppointment))
            {
                if (testAppointment.ReTakeApp != null)
                {
                    testAppointment.ReTakeApp.Status = 2;
                    _appServices.Save(testAppointment.ReTakeApp);
                }
                return true;
            }
            else return false;
        }
        public bool Save(TestAppointmentDto testAppointment, ref string error)
        {
            if(testAppointment.TestAppointment.TestAppointmentID==-1 ||
                GetTestAppointment(testAppointment.TestAppointment.TestAppointmentID)==null)
                return AddNew(testAppointment, ref error);

            else return Update(testAppointment, ref error); 
        }
    }
}
