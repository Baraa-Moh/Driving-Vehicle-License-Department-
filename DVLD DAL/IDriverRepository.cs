using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public interface IDriverRepository
    {
        Driver GetDriver(int driverID);
        DataTable GetAllDrivers();
        bool AddNew(Driver driver);
        bool Delete(int driverID);  
        bool Update(Driver driver);
    }
}
