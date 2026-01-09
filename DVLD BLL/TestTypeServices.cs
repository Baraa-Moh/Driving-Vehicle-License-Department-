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
    public class TestTypeServices
    {
        private readonly ITestTypeRepository _rep;
        public TestTypeServices(ITestTypeRepository rep)
        {
            _rep = rep; 
        }

        public DataTable GetAllTestTypes()
        {
            return _rep.GetAllTestTypes();
        }
        public TestType GetTestType(int id)
        {
            return _rep.GetTestType(id);
        }
        private bool Update(TestType testType)
        {
            return _rep.Update(testType);
        }
        public bool Save(ref TestType testType)
        {
            return Update(testType);
        }
    }
}
