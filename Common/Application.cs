using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Application
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public DateTime Date { get; set; }
        public int TypeID { get; set; }
        public int Status {  get; set; }
        public DateTime LastStatuesDate { get; set; }
        public double PaidFees { get; set; }
        public int CreatedBy { get; set; }

        public Application (int iD, int personID, DateTime date, int typeID, int status, DateTime lastStatuesDate, double paidFees, int createdBy)
        {
            ID = iD;
            PersonID = personID;
            Date = date;
            TypeID = typeID;
            Status = status;
            LastStatuesDate = lastStatuesDate;
            PaidFees = paidFees;
            CreatedBy = createdBy;
        }
        public Application()
        {
            ID = -1;
            PersonID = -1;  
        }
    }
}
