using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DVLD_BLL.DTOs;

namespace DVLD_BLL
{
    public class TestServices 
    {
        private readonly ITestRepository _rep;
        private readonly TestSharedServices _sharedServices;
        public TestServices(ITestRepository rep, TestSharedServices testSharedServices)
        {
            _rep = rep;
            _sharedServices = testSharedServices;
        }
        public DataTable GetAllTestsByLDLAppID(int LDLAppID)
        {
            return _rep.GetAllTestsByLDLAppID(LDLAppID);
        }
        public TestDto GetTest(int testID)
        {
            return _sharedServices.GetTest(testID);
        }
        private bool ValidateAddNew(Test test, ref string error)
        {
            if(_sharedServices.GetTestAppointment(test.TestAppointmentID)== null)
            {
                error = "There's no Appointment for this test";
                    return false;
            }
            return true;
        }
        private bool AddNew(TestDto test, ref string error, TestAppointmentDto testAppointment=null)
        {
            error = null;
            if (!ValidateAddNew(test.Test, ref error))
                return false;

            if (!_rep.AddNew(test.Test))
            {
                error = "Error";
                return false;
            }
            else 
            {
                _sharedServices.LockAppointment(testAppointment);
                return true;
            }
        }
        private bool Update(TestDto test, ref string error)
        {
            error = null;
            if (!_rep.Update(test.Test)){
                error = "Error";
                return false;
            }
            else return true;
        }
        public bool Save(TestDto test, ref string error, TestAppointmentDto testAppointment=null)
        {
            if(test.Test.TestID==-1 || (GetTest(test.Test.TestID)==null))
                return AddNew(test, ref error, testAppointment);
            else return Update(test, ref error);    
        }
        public int GetNumberOfTrials(int LDLAppID, int TestType)
        {
            return _sharedServices.GetNumberOfPassedTests(LDLAppID, TestType);
        }
    }
}
