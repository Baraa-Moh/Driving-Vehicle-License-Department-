using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LDLApplication
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public LDLApplication(int ID, int ApplicationID, int LicenseClassID)
        {
            this.ID = ID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }
        public LDLApplication()
        {
            ID = -1;
            ApplicationID = -1;
        }
    }
}
