using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Core
    {
        public static User CurrentUser;
        public static Person CurrentPerson;
        public  enum enIssueReason {FirstTime, Renew, ReplacementOrDamaged };
        public enum enDriversFilter { None=0, DriverID, PersonID, NationalNo, FullName };
        public enum ApplicationTypes {NewLocalDrivingLicense = 1, RenewDrivingLicense=2,
            ReplacementForLost=3,ReplacementForDamaged=4, ReleaseDetainedLicense=5,
            NewInternationalLicense=6, RetakeTest=8};
        public enum Status { New=1, Canceled=2,Completed=3};
        private Core() { }  

    }
}
