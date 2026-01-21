using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public interface IInternationalLicenseRepo
    {
        DataTable GetAllInternationalLicenses();
        DataTable GetAllInternationalLicensesByDriverID(int driverID);
        InternationalLicense GetInternationalLicenseByDriverID(int id);
        InternationalLicense GetInternationalLicense(int id);
        bool AddNew(InternationalLicense internationalLicense);
        bool Update(InternationalLicense internationalLicense);
        bool Delete(int id);
    }
}
