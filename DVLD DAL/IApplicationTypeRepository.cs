using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DVLD_DAL
{
    public interface IApplicationTypeRepository
    {
        DataTable GetAllTypes();
        ApplicationType GetApplicationType(int appTypeID);
        bool Update(ApplicationType applicationType);
    }
}
