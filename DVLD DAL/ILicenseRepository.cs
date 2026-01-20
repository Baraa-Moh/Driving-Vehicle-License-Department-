using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public interface ILicenseRepository
    {

        DataTable GetAllLicensesByDriverID(int  driverID);
        Common.License GetLicenseByAppID(int appID);
        Common.License GetLicense(int LicenseID);
        Common.License GetLicenseByDriverID(int DriverID);
        bool Update(Common.License license);
        bool Delete(int licenseID);
        bool AddNew(Common.License license, ref string error);
    }
}
