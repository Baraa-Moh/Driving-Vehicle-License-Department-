using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DVLD_DAL
{
    public interface ICountryRepository
    {
        DataTable GetAllCountries();
        Country GetCountry(int id);
        Country GetCountry(string name);
    }
}
