using Common;
using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class InternationalLicensesServices
    {
        private readonly IInternationalLicenseRepo _rep;
        private readonly LicenseServices _licenseServices;
        public InternationalLicensesServices(IInternationalLicenseRepo rep, LicenseServices licenseServices)
        {
            _rep = rep;
            _licenseServices = licenseServices;
        }

        public DataTable GetAllInternationalLicenses()
        {
            return _rep.GetAllInternationalLicenses();
        }
        public InternationalLicense GetInternationalLicense(int DriverID)
        {
            return _rep.GetInternationalLicenseByDriverID(DriverID);
        }
        private bool Validate(InternationalLicense internationalLicense, ref string error)
        {
            License license = _licenseServices.GetLicenseByDriverID(internationalLicense.DriverID);
            if (license == null || !license.isActive)
            {
                error = "The driver does not have an active driving license.";
                return false;
            }

            license = _licenseServices.GetLicense(internationalLicense.IssuedUsingLocalLicenseID);
            if (license.DriverID != internationalLicense.DriverID)
            {
                error= "The local license used to issue the international license does not belong to the same driver.";
                return false;
            }

            return true;
        }
        private bool AddNew(InternationalLicense internationalLicense, ref string error)
        {
            if(!Validate(internationalLicense, ref error))
            return false;

            internationalLicense.CreatedByUserID = Core.CurrentUser.UserID;
            internationalLicense.IssueDate = DateTime.Now;
            return _rep.AddNew(internationalLicense);
        }
        private bool Update(InternationalLicense internationalLicense, ref string error)
        {
            return _rep.Update(internationalLicense);
        }
        public bool Save(InternationalLicense internationalLicense, ref string error)
        {
            if (internationalLicense.InternationalLicenseID == -1 &&
                _rep.GetInternationalLicenseByDriverID(internationalLicense.DriverID) == null)
            {
                return AddNew(internationalLicense, ref error);
            }
            if(internationalLicense.InternationalLicenseID == -1)
            {
                error = "An international license for this driver already exists.";
                return false;
            }
            else
            {
                return Update(internationalLicense, ref error);
            }
        }
        public bool Delete(int LicenseID)
        {
            return _rep.Delete(LicenseID);
        }
    }
}
