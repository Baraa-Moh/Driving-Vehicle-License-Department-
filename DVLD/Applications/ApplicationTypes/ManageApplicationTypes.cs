using Common;
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
    public partial class ManageApplicationTypes : Form
    {
        private ApplicationType _appType;
        private ApplicationTypeServices _appTypeServices;
        public ManageApplicationTypes()
        {
            InitializeComponent();
            _appType = new ApplicationType();
            _appTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository()); 
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            Load_AppTypes();
        }
        private void Load_AppTypes()
        {
            dgvApplicationTypes.DataSource = _appTypeServices.GetAllTypes();
            lbRecords.Text = dgvApplicationTypes.Rows.Count.ToString();

            dgvApplicationTypes.Columns[0].Width = 50;
            dgvApplicationTypes.Columns[1].Width = 200;
            dgvApplicationTypes.Columns[2].Width = 50;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int appTypeID = (int)dgvApplicationTypes.CurrentRow.Cells[0].Value;
            EditApplicationType form = new EditApplicationType(appTypeID);
            form.ShowDialog();
            Load_AppTypes();
        }
    }
}
