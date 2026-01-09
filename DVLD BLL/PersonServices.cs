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
    public class PersonServices
    {

        private readonly IPersonRepository _rep;
        public PersonServices(IPersonRepository rep)
        {
            _rep = rep;
        }

        public Person FindPersonByID(int ID)
        {
            return _rep.FindByID(ID);
        }
        public Person FindPersonByNationalNo(string NationalNo)
        {
            return _rep.FindByNationalNo(NationalNo);
        }
        public bool Delete(int ID)
        {
            return _rep.Delete(ID);
        }
        public bool Save(ref Person person)
        {
            if (person?.ID != -1)
                return _rep.Update(person);
            else return _rep.AddNew(ref person);
        }
        public bool CheckExistsByPersonID(int ID)
        {
            return _rep.ExistsByPersonID(ID);
        }
        public bool CheckExistsByNationalNo(string ID)
        {
            return _rep.ExistsByNationalNo(ID);
        }

        public DataTable GetAllPeople(Person.enFilters filter, string Like = null)
        {
            return _rep.GetAllPeople(filter, Like);
        }
        public DataView FilterPeople(Person.enFilters filter, DataTable People, string Like=null)
        {
            People.CaseSensitive = false;
            DataView dataView = People.DefaultView;
            filter = filter == Person.enFilters.none ? Person.enFilters.PersonID : filter;

                Like = Like == null ? "" : Like;
                dataView.RowFilter = $"Convert({filter}, 'System.String') LIKE '{Like}%'";
                dataView.Sort = $"{filter.ToString()}";

            return dataView;
            
        }
        public DataTable GetAllPeople()
        {
            return _rep.GetAllPeople();
        }
        public Person GetPerson(int ID)
        {
            return _rep.GetPerson(ID);
        }
    }
}
