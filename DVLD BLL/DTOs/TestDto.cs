using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL.DTOs
{
    public class TestDto
    {
        public Test Test { get; set; }
        public TestAppointment TestAppointment { get; set; }

        public TestDto(Test test, TestAppointment appointment)
        {
            this.Test = test;
            this.TestAppointment = appointment;
            test.TestAppointmentID = appointment.TestAppointmentID;
        }
        public TestDto()
        {
            Test = new Test();  
            TestAppointment = new TestAppointment();
        }
    }
}
