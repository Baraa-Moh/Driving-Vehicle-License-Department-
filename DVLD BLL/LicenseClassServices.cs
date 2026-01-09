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
    public class LicenseClassServices
    {
        private readonly ILicenseClassRepository _rep;
        public LicenseClassServices(ILicenseClassRepository rep)
        {
            _rep = rep;
        }

        public DataTable GetAllLicenseClass()
        {
            return _rep.GetAllLicenseClasses();
        }
        public LicenseClass GetLicenseClass(int id)
        {
            return _rep.GetLicenseClass(id);
        }
    }
}
