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
        private readonly LicenseServices _licenseServices;
        private readonly ApplicationServices _applicationServices;
        private readonly DriverServices _driverServices;
        private readonly ApplicationTypeServices _applicationTypeServices;
        public DetainedLicenseServices(IDetainedLicenseRepository rep)
        {
            _rep = rep;
            LDLApplicationServices ldlServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _licenseServices = new LicenseServices(new SqlLicenseRepository(), new TestSharedServices(), ldlServices, new DriverServices(new SqlDriverRepository(), new PersonServices(new SqlPersonRepository()), new TestSharedServices()), new ApplicationServices(new SqlApplicationRepository()));
            _applicationServices = new ApplicationServices(new SqlApplicationRepository());
            _driverServices = new DriverServices(new SqlDriverRepository(),new PersonServices(new SqlPersonRepository()),new TestSharedServices());
            _applicationTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
        }
        public bool AddNewDetain(DetainedLicense detainedLicense, ref string error)
        {
            if (isDetained(detainedLicense.LicenseID))
            {
                error = "License already is detained";
                return false;
            }
            return _rep.AddNewDetain(detainedLicense);
        }
        public bool UpdateDetain(DetainedLicense detainedLicense, ref string error)
        {
            return _rep.UpdateDetain(detainedLicense);
        }
        private bool PrepareForRelease(DetainedLicense detainedLicense, ref string error)
        {
            License license = _licenseServices.GetLicense(detainedLicense.LicenseID);
            Application app = new Application();
            app.PersonID = _driverServices.GetDriver(license.DriverID).PersonID;
            app.Date = DateTime.Now;
            app.TypeID = (int)Core.ApplicationTypes.ReleaseDetainedLicense;
            app.Status = 3;
            app.LastStatuesDate = DateTime.Now;
            app.PaidFees = _applicationTypeServices.GetApplicationType((int)Core.ApplicationTypes.ReleaseDetainedLicense).Fees;
            app.CreatedBy = Core.CurrentUser.UserID;
            if (!_applicationServices.Save(app))
            {
                error = "Error with making an application";
                return false;
            }
            detainedLicense.ReleaseApplicationID = app.ID;
            detainedLicense.ReleaseDate = DateTime.Now;
            detainedLicense.IsReleased = true;
            detainedLicense.ReleasedByUserID = Core.CurrentUser.UserID;
            return true;
        }
        public bool ReleaseDetain(DetainedLicense detainedLicense, ref string error)
        {
            if (!PrepareForRelease(detainedLicense, ref error))
                return false;
            return UpdateDetain(detainedLicense,ref error);
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
