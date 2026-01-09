using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DVLD_BLL.DTOs
{
    public class LDLApplicationDto
    {
        public Application Application {  get; set; }
        public LDLApplication LDLApplication { get; set; }
        public int PassedTests { get; set; }
        public LDLApplicationDto(Application application, LDLApplication localDrivingLicenseApplication, int passedTests)
        {
            Application = application;
            LDLApplication = localDrivingLicenseApplication;
            PassedTests = passedTests;
        }
        public LDLApplicationDto()
        {
            Application = new Application();
            LDLApplication = new LDLApplication();
            PassedTests = 0;
        }
    }
}
