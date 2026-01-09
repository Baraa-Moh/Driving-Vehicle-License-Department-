using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TestType
    {
        public int ID {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Fees { get; set; }

        public TestType(int iD, string title, string description, double fees)
        {
            ID = iD;
            Title = title;
            Description = description;
            this.Fees = fees;
        }

        public TestType()
        {
            ID = -1;
        }
    }
}
