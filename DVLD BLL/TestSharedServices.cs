using Common;
using DVLD_BLL.DTOs;
using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class TestSharedServices
    {
        private readonly ITestRepository _testRep;
        private readonly ITestAppointmentRepository _testAppointmentRep;
        private readonly IApplicationRepository _appRep;
        public TestSharedServices()
        {
            _testRep = new SqlTestRepository();
            _testAppointmentRep = new SqlTestAppointmentRepository();
            _appRep = new SqlApplicationRepository();
        }

        public TestDto GetTest(int testID)
        {
            TestDto test = new TestDto();
            test.Test = _testRep.GetTestByID(testID);
            test.TestAppointment = _testAppointmentRep.GetTestAppointment(testID);

            return test;
        }
        public bool HasFailedTest(int LDLAppID, int TestTypeID)
        {
            TestDto[] tests = ConvertDataTable(_testRep.GetAllTestsByLDLAppID(LDLAppID));
            if (tests == null)
                return false;

            foreach (TestDto test in tests)
            {
                if (test.TestAppointment.TestTypeID == TestTypeID && !test.Test.TestResult)
                    return true;
            }
            return false;
        }
        public TestDto[] ConvertDataTable(DataTable tests)
        {
            if (tests == null)
                return null;

            TestDto[] tests2 = new TestDto[tests.Rows.Count];
            int i = 0;
            foreach (DataRow row in tests.Rows)
            {
               
                tests2[i] = ConvertDataRow(row);
                i++;
            }
            return tests2;
        }
        public TestDto ConvertDataRow(DataRow row)
        {
            Test test = new Test((int)row["TestID"], (int)row["TestAppointmentID"], (bool)row["TestResult"],
                row["Notes"] as string, (int)row["CreatedByUserID"]);
            TestAppointment tAppointment = _testAppointmentRep.GetTestAppointment((int)row["TestAppointmentID"]);

            return new TestDto(test, tAppointment);
        }
        public TestAppointment GetTestAppointment(int testAppointmentID)
        {
            return _testAppointmentRep.GetTestAppointment(testAppointmentID); ;
        }
        public bool CheckPassedTestType(int LDLAppID, int TestTypeID)
        {
            bool passed = false;
            TestDto[] tests = ConvertDataTable(_testRep.GetAllTestsByLDLAppID(LDLAppID));
            if (tests == null)
                return passed;

            foreach (TestDto test in tests)
            {
                if (test.TestAppointment.TestTypeID == TestTypeID && test.Test.TestResult)
                    passed = true;
            }
            return passed;
        }
        public int GetNumberOfPassedTests(int LDLAppID)
        {
            int Passed = 0;
            DataTable tests = _testRep.GetAllTestsByLDLAppID(LDLAppID);
            if (tests == null)
                return ++Passed;

            TestDto[] testDTOs = ConvertDataTable(tests);
            
            foreach (TestDto test in testDTOs)
            {
                if (test.Test.TestResult)
                    Passed++;
            }
            return Passed;
        }
        public int GetNumberOfPassedTests(int LDLAppID, int TestTypeID)
        {
            int Trials = 0;
            DataTable tests = _testRep.GetAllTestsByLDLAppID(LDLAppID);

            if(tests == null)
                return Trials;

            TestDto[] testDTOs = ConvertDataTable(tests); 

            foreach (TestDto test in testDTOs)
            {
                if((!test.Test.TestResult) && test.TestAppointment.TestTypeID==TestTypeID)
                    Trials++;
            }
            return Trials;
        }
        public int GetNextTestType(int LDLApp)
        {
            if (!CheckPassedTestType(LDLApp, 1))
                return 1;

            if (!CheckPassedTestType(LDLApp, 2))
                return 2;

            if (!CheckPassedTestType(LDLApp, 3))
                return 3;

            return 0;
        }
        public bool LockAppointment(TestAppointmentDto testAppointment)
        {
            testAppointment.TestAppointment.isLocked = true;

                if (_testAppointmentRep.Update(testAppointment.TestAppointment))
                {
                if (testAppointment.ReTakeApp != null)
                {
                    testAppointment.ReTakeApp.Status = 3;
                    _appRep.Update(testAppointment.ReTakeApp);
                }
                return true;
                }
            else return false;
        }
    }
}
