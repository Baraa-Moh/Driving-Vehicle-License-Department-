using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DVLD_DAL
{
    
    public  interface IPersonRepository
    {
        
        Person FindByID(int id);
        Person FindByNationalNo(string nationalNo);
        bool AddNew(ref Person person);
        bool Delete(int ID);
        bool Update(Person person);
        DataTable GetAllPeople(Person.enFilters filter,string Like);
        bool ExistsByPersonID(int ID);
        bool ExistsByNationalNo(string ID);
        DataTable GetAllPeople();
        Person GetPerson(int ID);   

    }
}
