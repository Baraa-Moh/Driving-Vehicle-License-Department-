using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DVLD_BLL.DTOs
{
    public class TestAppointmentDto
    {
        public LDLApplicationDto LDLApplicationDto { get; set; }
        public TestAppointment TestAppointment { get; set; }
        public Common.Application ReTakeApp {  get; set; }
        public TestAppointmentDto(LDLApplicationDto LDLappDto , TestAppointment testAppointment,Application retakeApp=null)
        {
            LDLApplicationDto = LDLappDto;
            TestAppointment = testAppointment;
            ReTakeApp = retakeApp;

            TestAppointment.LDLApplicationID = LDLappDto.LDLApplication.ID;
        }
        public TestAppointmentDto()
        {
            LDLApplicationDto = new LDLApplicationDto();
            TestAppointment = new TestAppointment();
            ReTakeApp = null;
        }
    }
}
