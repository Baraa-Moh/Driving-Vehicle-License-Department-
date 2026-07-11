using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public interface ITestRepository
    {
        DataTable GetAllTestsByLDLAppID(int LDLAppID);
        Test GetTestByID(int testID);
        Test GetTestByAppointmentID(int testAppointmentID);
        bool AddNew(Test test);
        bool Update(Test test); 
        bool Delete(int testID);

    }
}
