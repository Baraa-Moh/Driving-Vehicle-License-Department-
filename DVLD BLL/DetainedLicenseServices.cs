using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
namespace DVLD_BLL
{
    public class DetainedLicenseServices
    {
        private readonly IDetainedLicenseRepository _rep;
        public DetainedLicenseServices(IDetainedLicenseRepository rep)
        {
            _rep = rep;
        }
        public bool AddNewDetain(DetainedLicense detainedLicense)
        {
            return _rep.AddNewDetain(detainedLicense);
        }
        public bool UpdateDetain(DetainedLicense detainedLicense)
        {
            return _rep.UpdateDetain(detainedLicense);
        }
        public bool DeleteDetain(int detainID)
        {
            return _rep.DeleteDetain(detainID);
        }
        public DetainedLicense GetDetainByID(int detainID)
        {
            return _rep.GetDetainByID(detainID);
        }
        public DetainedLicense GetDetainByLicenseID(int licenseID)
        {
            return _rep.GetDetainByLicenseID(licenseID);
        }
        public DataTable GetAllDetains()
        {
            return _rep.GetAllDetains();
        }   
        public bool isDetained(int licenseID)
        {
            DetainedLicense detainedLicense = _rep.GetDetainByLicenseID(licenseID);
            if (detainedLicense != null && !detainedLicense.IsReleased)
            {
                return true;
            }
            return false;
        }
    }
}
