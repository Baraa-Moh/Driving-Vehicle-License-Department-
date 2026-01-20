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

namespace DVLD.Applications.DrivingLicenses
{
    public partial class DriversList : Form
    {
        private readonly DriverServices _driverServices;
        private DataTable _drivers;
        public DriversList()
        {
            InitializeComponent();
            _driverServices = new DriverServices(new SqlDriverRepository(), new PersonServices(new SqlPersonRepository()), new TestSharedServices());
        }

        private void DriversList_Load(object sender, EventArgs e)
        {
            LoadDrivers();

        }
        private void LoadDrivers()
        {
            _drivers = _driverServices.GetAllDrivers();
            dataGridView1.DataSource = _drivers;
            lbRecords.Text = dataGridView1.Rows.Count.ToString();
            comboBox1.SelectedIndex = 0;
        }
        private void FilterDrivers()
        {
            Core.enDriversFilter filter = (Core.enDriversFilter)comboBox1.SelectedIndex;
            string Like = tbLike.Text;
            dataGridView1.DataSource = _driverServices.FilterDrivers(_drivers,filter, Like);
            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                tbLike.Visible = false;
                tbLike.Text = "";
            }
            else
            {
                tbLike.Visible = true;
                tbLike.Text = "";
            }
            FilterDrivers();
        }

        private void tbLike_TextChanged(object sender, EventArgs e)
        {
            FilterDrivers();
        }
    }
}
