using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;
using Common;
using System.Dynamic;
namespace DVLD_BLL
{
    public class CountryServices
    {
        private readonly ICountryRepository _rep;
        public CountryServices(ICountryRepository rep)
        {
            _rep = rep;
        }
        

        public  DataTable GetAllCountries()
        {
            return _rep.GetAllCountries();
        }
        public  Country GetCountry(string countryName)
        {
            return _rep.GetCountry(countryName);
        }
        public  Country GetCountry(int countryId)
        {
            return _rep.GetCountry(countryId);
        }
    }
}
