using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DVLD_BLL.DTOs;
using DVLD_DAL;
namespace DVLD_BLL
{
    public class LDLApplicationServices 
    {
        private readonly ApplicationServices _applicationServices;
        private readonly ILDLApplicationRepository _rep;
        private readonly TestSharedServices _testSharedServices;
        public LDLApplicationServices(ApplicationServices applicationServices, TestSharedServices testSharedServices, ILDLApplicationRepository rep)
        {
            _applicationServices = applicationServices;
            _testSharedServices = testSharedServices;
            _rep = rep;
        }

        public DataView GetAllLDLApplications()
        {
            DataView apps = _rep.GetAllApplications().DefaultView;
            apps.Sort = "L.D.L.AppID DESC";
            return apps;
        }
        public void FilterView(DataView view, string ColumnName, string like)
        {
            if(ColumnName == "None")
            {
                view.Sort = "L.D.L.AppID DESC";
                view.RowFilter = string.Empty;
            }
            else
            {
                view.Sort = ColumnName + " DESC";
                view.RowFilter = $"Convert([{ColumnName}], 'System.String') LIKE '{like}%'";
            }
        }
        public LDLApplicationDto  GetLDLApplication(int LDLappID)
        {
            LDLApplicationDto LDLappDto = new LDLApplicationDto();
            LDLappDto.LDLApplication= _rep.GetLDLApplication(LDLappID);

            if(LDLappDto.LDLApplication== null )
                return null;
            LDLappDto.PassedTests= _testSharedServices.GetNumberOfPassedTests(LDLappID);
            LDLappDto.Application= _applicationServices.GetApplicationByID(LDLappDto.LDLApplication.ApplicationID);

            return LDLappDto;
        }
        public LDLApplicationDto GetLDLApplicationByAppID(int appID)
        {
            LDLApplicationDto LDLAppDTO = new LDLApplicationDto();
            LDLAppDTO.LDLApplication = _rep.GetLDLApplicationByAppID(appID);

            if(LDLAppDTO.LDLApplication == null )
                return null;
            LDLAppDTO.PassedTests = _testSharedServices.GetNumberOfPassedTests(LDLAppDTO.LDLApplication.ID);
            LDLAppDTO.Application = _applicationServices.GetApplicationByID(appID);
            
            return LDLAppDTO;
        }
        public DataTable GetAllLDLApplicationsByPersonID(int PersonID)
        {
            return _rep.GetAllLDLApplicationsByPersonID(PersonID);
        }
        public int GetNextTestType(int LDLAppID)
        {
            return _testSharedServices.GetNextTestType(LDLAppID);
        }
        private bool AddNew(LDLApplicationDto LDLapp)
        {
            if(!_applicationServices.Save(LDLapp.Application))
                return false;

            LDLapp.LDLApplication.ApplicationID=LDLapp.Application.ID;
            return _rep.AddNew(LDLapp.LDLApplication);
        } 
        public bool Save(LDLApplicationDto LDLapp, ref string error)
        {
            if (LDLapp.Application.ID == -1 || !_applicationServices.CheckApplicationExists(LDLapp.Application.ID))
            {
                int FoundApp = -1;
                
                if (HasActiveLDLApplication(LDLapp.Application.PersonID, LDLapp.LDLApplication.LicenseClassID, ref FoundApp))
                {
                    error = $@"Choose another License Class, the selected Person already
has an active application with the selected class with ID = {FoundApp}";
                    return false;
                }
                if(HasCompletedLDLApplication(LDLapp.Application.PersonID,LDLapp.LDLApplication.LicenseClassID))
                {
                    error = @"Person already has a license with the same applied driving class, 
Choose different driving class";
                    return false;
                }
                return AddNew(LDLapp);
            }
            else
            {
                if (!isApplicationForLDL(LDLapp.Application.ID))
                    return false;
                return Update(LDLapp);
            }
        }
        private bool HasActiveLDLApplication(int PersonID, int LicenseClassID, ref int FoundID)
        {
            bool Has = false;
            DataTable apps = GetAllLDLApplicationsByPersonID(PersonID);
            if (apps != null)
            {
                foreach (DataRow row in apps.Rows)
                {
                    if ((int)row["LicenseClassID"] == LicenseClassID && Convert.ToInt32(row["ApplicationStatus"])==1)
                    {
                        Has = true;
                        FoundID = (int)row["LocalDrivingLicenseApplicationID"];
                        break;
                    }
                }
                return Has;
            }
            return Has; 
        }
        private bool HasCompletedLDLApplication(int PersonID, int LicenseClassID)
        {
            bool has = false;
            DataTable apps = GetAllLDLApplicationsByPersonID(PersonID); 
            if(apps == null)
                return has;

            foreach(DataRow row in apps.Rows)
            {
                if((int)row["LicenseClassID"] == LicenseClassID && Convert.ToInt32(row["ApplicationStatus"]) == 3)
                    has = true;
            }
            return has;
        }
        public bool Delete (int LDLappID)
        {
            return _rep.Delete(LDLappID);
        }
        private bool Update(LDLApplicationDto LDLapp)
        {
            //could be detailed..
            return _applicationServices.Save(LDLapp.Application);
        }
        private bool isApplicationForLDL(int appID)
        {
            return (_applicationServices.GetApplicationByID(appID)?.TypeID == 1);
        }
    }
}
