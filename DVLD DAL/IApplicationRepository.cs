using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public interface IApplicationRepository
    {
        DataTable GetAllApplications();
        Application GetApplicationByID(int id);
        bool AddNew(Application application);
        bool Update(Application application);
        bool Delete(int id);
        bool CheckApplicationExists(int ApplicationID);
    }
}
