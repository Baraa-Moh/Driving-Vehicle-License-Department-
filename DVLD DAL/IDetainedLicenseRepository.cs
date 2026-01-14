using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DVLD_DAL
{
    public interface IDetainedLicenseRepository
    {
        DataTable GetAllDetains();
        DetainedLicense GetDetainByID(int detainID);   
        DetainedLicense GetDetainByLicenseID(int licenseID);
        bool AddNewDetain(DetainedLicense detainedLicense);
        bool UpdateDetain(DetainedLicense detainedLicense);
        bool DeleteDetain(int detainID);

    }
}
