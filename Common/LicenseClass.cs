using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LicenseClass
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinimumAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public double Fees { get; set; }

        public LicenseClass(int iD,string name,string description, int minimumAge, int defaultValidityLength, double fees)
        {
            ID = iD;
            Name = name;
            Description = description;
            MinimumAge = minimumAge;
            DefaultValidityLength = defaultValidityLength;
            Fees = fees;
        }
        public LicenseClass()
        {
            ID = -1;
        }
    }
}
