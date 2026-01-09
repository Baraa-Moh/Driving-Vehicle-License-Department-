using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DVLD_DAL;
namespace DVLD_BLL
{
    public class ApplicationTypeServices
    {
        private readonly IApplicationTypeRepository _rep;
        public ApplicationTypeServices(IApplicationTypeRepository rep)
        {
            _rep = rep;
        }   
        public ApplicationType GetApplicationType(int appTypeID)
        {
            return _rep.GetApplicationType(appTypeID);
        }
        public DataTable GetAllTypes()
        {
            return _rep.GetAllTypes();
        }
        private bool Update(ApplicationType applicationType)
        {
            return _rep.Update(applicationType);
        }
        public bool Save(ApplicationType appType)
        {
            return Update(appType); 
        }
    }
}
