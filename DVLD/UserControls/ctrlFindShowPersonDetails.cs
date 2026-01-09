using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;


namespace DVLD.UserControls
{
    public partial class ctrlFindShowPersonDetails : UserControl
    {
        public int PersonID { get; set; }
        public bool EnableFilter { get
            { return ctrlFilterPerson1.Enabled; }
            set { ctrlFilterPerson1.Enabled = value; }
        }
        //I'll make fire it even if it's not found by returning -1
        public event Action<int> OnPersonFound;
        protected virtual void PersonFound(int personId)
        {
            Action<int> handler = OnPersonFound;
            if(handler != null) 
                handler(personId);
        }
        public ctrlFindShowPersonDetails()
        {
            InitializeComponent();
            PersonID = -1;
        }
        private void ctrlFindShowPersonDetails_Load(object sender, EventArgs e)
        {

        }
           
        
        public void Load_Information(int personID)
        {
            ctrlPersonDetails1.Load_Person(personID);
        }
        private void ctrlFilterPerson1_OnPersonFound(int obj)
        {
            if (obj != -1)
            {
                PersonID = obj;
                ctrlPersonDetails1.Load_Person(obj);
                PersonFound(obj);
            }

            else
            {
                ctrlPersonDetails1.Empty_Card();
                PersonID = -1;
                PersonFound(obj);
            }
        }
    }
}
