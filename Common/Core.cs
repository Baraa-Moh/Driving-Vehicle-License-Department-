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
        private Core() { }  

    }
}
