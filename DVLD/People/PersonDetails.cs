using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class PersonDetails : Form
    {
        private int _personID;
        public PersonDetails(int id)
        {
            InitializeComponent();
            _personID = id;
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails1.Load_Person(_personID);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
