using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DVLD_DAL
{
    public interface ITestTypeRepository
    {
        DataTable GetAllTestTypes();
        TestType GetTestType(int id);
        bool Update(TestType testType);
    }
}
