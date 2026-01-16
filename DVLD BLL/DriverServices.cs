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
        private readonly PersonServices _personServices;
        private readonly TestSharedServices _testSharedServices;

        public DriverServices(IDriverRepository rep, PersonServices personServices, TestSharedServices testSharedServices)
        {
            _rep = rep;
            _personServices = personServices;
            _testSharedServices = testSharedServices;
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
            DataTable drivers = _rep.GetAllDrivers();
            return AdjustDataTable(drivers);
        }
        private DataTable AdjustDataTable(DataTable drivers)
        {
            DataTable drivers2 = new DataTable();
            drivers2.Columns.Add("Driver ID", typeof(int));
            drivers2.Columns.Add("Person ID", typeof(int));
            drivers2.Columns.Add("National No.", typeof(string));
            drivers2.Columns.Add("Full Name", typeof(string));   
            drivers2.Columns.Add("Date", typeof(DateTime));  
            drivers2.Columns.Add("Active License", typeof(short));

            foreach (DataRow row in drivers.Rows)
            {
                Person person = _personServices.FindPersonByID((int)row["PersonID"]);
                short activeLicense = _testSharedServices.NumberOfActiveLicenses((int)row["DriverID"]);
                drivers2.Rows.Add(
                    row["DriverID"],
                    person.ID,
                    person.NationalID,
                    person.FullName,
                    row["CreatedDate"],
                    activeLicense
                    );
            }
            return drivers2;
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
