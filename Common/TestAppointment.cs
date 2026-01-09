using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TestAppointment
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LDLApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public double PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool isLocked { get; set; }

        public TestAppointment(int testAppointmentID, int testTypeID, int lDLApplicationID, DateTime appointmentDate, double paidFees, int createdByUserID, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LDLApplicationID = lDLApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            this.isLocked = isLocked;
        }
        public TestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LDLApplicationID = -1;
        }
    }
}
