using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public interface ITestAppointmentRepository
    {
        DataTable GetAllTestAppointmentsByAppID(int LDLAppID);
        TestAppointment GetTestAppointment(int testAppointmentID);
        bool AddNew(TestAppointment testAppointment);
        bool Delete(int testAppointmentID);
        bool Update(TestAppointment testAppointment);

    }
}
