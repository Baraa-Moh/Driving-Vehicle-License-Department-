using DVLD_BLL;
using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class ManageTestTypes : Form
    {
        private TestTypeServices _services;
        public ManageTestTypes()
        {
            InitializeComponent();
            _services = new TestTypeServices(new SqlTestTypeRepository());
        }

        private void ManageTestTypes_Load(object sender, EventArgs e)
        {
            Load_TestTypes();
        }
        private void Load_TestTypes()
        {
            dgvTestTypes.DataSource = _services.GetAllTestTypes();
            lbRecords.Text = dgvTestTypes.Rows.Count.ToString();    
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int testTypeID = (int)dgvTestTypes.CurrentRow.Cells[0].Value;
            EditTestType form = new EditTestType(testTypeID);
            form.ShowDialog();
            Load_TestTypes();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
