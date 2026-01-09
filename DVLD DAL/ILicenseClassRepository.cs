using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public interface ILicenseClassRepository
    {
        DataTable GetAllLicenseClasses();
        LicenseClass GetLicenseClass(int licenseClassId);   
    }
}
