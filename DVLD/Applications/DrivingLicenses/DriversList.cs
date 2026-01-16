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
            dataGridView1.DataSource = _driverServices.GetAllDrivers();
            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
