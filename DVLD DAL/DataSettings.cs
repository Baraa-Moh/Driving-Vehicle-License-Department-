using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public  class DataSettings
    {
        
        public DataSettings() { }
        public static string ConnectionString { get
            { return "Server= .; Database= DVLD; User Id= sa; Password= 123456;"; } }
    }
}
