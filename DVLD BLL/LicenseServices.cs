using Common;
using DVLD_BLL.DTOs;
using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class LicenseServices
    {
        private readonly ILicenseRepository _rep;
        private readonly TestSharedServices _sharedServices;
        private readonly LDLApplicationServices _LDLappServices;
        private readonly DriverServices _driverServices;
        private readonly ApplicationServices _applicationServices;
        public LicenseServices(ILicenseRepository rep, TestSharedServices testSharedServices,
            LDLApplicationServices lDLApplicationServices, DriverServices driverServices, ApplicationServices applicationServices)
        {
            _rep = rep;
            _sharedServices = testSharedServices;
            _LDLappServices = lDLApplicationServices;
            _driverServices = driverServices;
            _applicationServices = applicationServices;
        }

        public DataTable GetAllLicensesByDriverID(int driverID)
        {
            return _rep.GetAllLicensesByDriverID(driverID);
        }
        public Common.License GetLicense(int licenseID)
        {
            return _rep.GetLicense(licenseID);
        }
        public Common.License GetLicenseByAppID(int appID)
        {
            return _rep.GetLicenseByAppID(appID);
        }
        public string GetIssueReason(int issueReasonID)
        {
            switch (issueReasonID)
            {
                case 1:
                    return "New";
                case 2:
                    return "Renew";
                    case 3:
                    return "Damaged";
                    case 4:
                    return "Replacement";
                default:
                    return "Unknown";
            }
        }
        private bool CheckSetForFirstIssue(int LDLappId)
        {
            bool set = true;
            if (!_sharedServices.CheckPassedTestType(LDLappId, 1))
                return false;
            if(!_sharedServices.CheckPassedTestType(LDLappId,2))
                return false;
            if(!_sharedServices.CheckPassedTestType(LDLappId,3))
                return false;

            return set;
        }
        private bool AddAsFirstTime(License license, ref string error)
        {
            LDLApplicationDto LDLApp = _LDLappServices.GetLDLApplicationByAppID(license.ApplicationID);
            if (LDLApp == null)
            {
                error = "There's no application related to this license";
                return false;
            }


            if (CheckSetForFirstIssue(LDLApp.LDLApplication.ID) || GetAllLicensesByDriverID(license.DriverID)==null)
            {
                Driver driver = new Driver();
                driver.PersonID = LDLApp.Application.PersonID;
                driver.CreatedByUserID = Core.CurrentUser.UserID;
                driver.CreatedDate = DateTime.Now;
                license.isActive = true;

                if (!_rep.AddNew(license,ref error))
                {
                    error += " ERROR";
                    return false;
                }
                else {
                    LDLApp.Application.Status = 3;
                    _LDLappServices.Save(LDLApp, ref error);
                    _driverServices.Save(driver);
                    return true;
                }
            }
            else
            {
                error = "Unqualified yet";
                return false;
            }
        }
        private bool AddAsRenew(License newLicense, License license2, ref string error)
        {
            if(newLicense ==null )
            {
                error = "Fill license info";
                return false;
            }
            if (_rep.GetLicense(license2.LicenseID) == null)
            {
                error = "Invalid expired license";
                return false;
            }
            newLicense.IssueReason = 2;
            if (_rep.AddNew(newLicense, ref error))
            {
                Application app = _applicationServices.GetApplicationByID(newLicense.ApplicationID);
                app.Status = 3;
                _applicationServices.Save(app);
                return true;
            }
            else
            {
                { 
                    error += " ERROR";
                    return false;
                }
            }
        }
        private bool AddAsReplacementOrDamaged(License newLicense, License license2, ref string error)
        {
            if(newLicense ==null)
            {
                error = "Fill License Info";
                return false;   
            }
            if (_rep.GetLicense(license2.LicenseID) == null)
            {
                error = "There's no license to be replaced";
                return false;
            }
            newLicense.IssueReason = 3;
            if (_rep.AddNew(newLicense, ref error))
            {
                license2.isActive = false;
                _rep.Update(license2);
                Application app = _applicationServices.GetApplicationByID(newLicense.ApplicationID);
                app.Status = 3;
                _applicationServices.Save(app);
                return true;
            }
            else
            {
                error += " ERROR";
                return false;
            }
        }
        private bool AddNew(Common.License license, ref string error, Core.enIssueReason issueReason, Common.License license2= null)
        {
            if (license == null)
            {
                error = "Fill Info";
                return false;
            }

            switch (issueReason)
            {
                case Core.enIssueReason.FirstTime:
                    return AddAsFirstTime(license,ref error);

                case Core.enIssueReason.Renew:
                    return AddAsRenew(license, license2, ref error);
                    
                case Core.enIssueReason.ReplacementOrDamaged:
                    return AddAsReplacementOrDamaged(license,license2, ref error);
                default:
                    return false;
            }
        }
        private bool Update(Common.License license, ref string error)
        {
            if (license == null)
            {
                error = "Fill Info";
                return false;
            }
            return _rep.Update(license);
        }
        public bool Save(Common.License license, ref string error,Core.enIssueReason issueReason, Common.License license2= null)
        {
            if(license.LicenseID ==-1 || GetLicense(license.LicenseID)==null)
                return AddNew(license, ref error, issueReason, license2);
            else return Update(license, ref error);
        }
    }
}
