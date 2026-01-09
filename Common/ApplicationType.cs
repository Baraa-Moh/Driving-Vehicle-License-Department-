using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ApplicationType
    {
        public int ID  { get; set; }
        public string Title { get; set; }
        public double Fees { get; set; }


        public ApplicationType(int id,string title, double fees)
        {
            ID = id;
            Title = title;
            Fees = fees;
        }
        public ApplicationType()
        {
            ID = -1;
        }
    }
}
