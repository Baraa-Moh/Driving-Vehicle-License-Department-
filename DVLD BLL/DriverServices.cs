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
    public class DriverServices
    {
        private readonly IDriverRepository _rep;

        public DriverServices(IDriverRepository rep)
        {
            _rep = rep;
        }
        public Driver GetDriver(int driverID)
        {
           return _rep.GetDriver(driverID);
        }
        public Driver GetDriverByPersonID(int personID)
        {
            return _rep.GetDriverByPersonID(personID);
        }
        public DataTable GetAllDrivers()
        {
            return _rep.GetAllDrivers();
        }
        private bool AddNew (Driver driver)
        {
            return _rep.AddNew(driver);
        }
        private bool Update (Driver driver)
        {
            return _rep.Update(driver);
        }
        public bool Delete (int driverID)
        {
            return _rep.Delete(driverID);
        }
        public bool Save(Driver driver)
        {
            if(driver.DriverID==-1 || (GetDriver(driver.DriverID)==null)) 
                return AddNew(driver);
            else return Update(driver);
        }
    }
}
