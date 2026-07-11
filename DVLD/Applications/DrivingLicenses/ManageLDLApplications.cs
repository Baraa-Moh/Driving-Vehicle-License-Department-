using Common;
using DVLD_BLL;
using DVLD_BLL.DTOs;
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
    public partial class ManageLDLApplications : Form
    {
        private DataView _LDLApps;
        private LDLApplicationServices _LDLappServices;
        private TestAppointmentServices _testAppointmentServices;
        private LDLApplicationDto _LDLApp;
        private int _selectedLDLAppID;
        public ManageLDLApplications()
        {
            InitializeComponent();
            _LDLappServices = new LDLApplicationServices(new ApplicationServices(new SqlApplicationRepository()), new TestSharedServices(), new SqlLDLApplicationRepository());
            _LDLApps = new DataView();
            _LDLApp = null;
        }

        private void ManageNewLDLApplications_Load(object sender, EventArgs e)
        {
            Load_LDLApps();
        }
        private void Load_LDLApps()
        {
            _LDLApps = _LDLappServices.GetAllLDLApplications();
            cbFilter.SelectedIndex = 0;
            dataGridView1.DataSource = _LDLApps;
            lbRecords.Text = dataGridView1.Rows.Count.ToString();   
        }
        private void Filter_LDLApps()
        {
            _LDLappServices.FilterView(_LDLApps, cbFilter.SelectedItem.ToString(), tbLike.Text);
            dataGridView1.DataSource = _LDLApps;
            lbRecords.Text = dataGridView1.Rows.Count.ToString();
        }
        
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 0)
                tbLike.Visible = false;
            else tbLike.Visible = true;

            Filter_LDLApps();
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            NewLDLApplication form = new NewLDLApplication();   
            form.ShowDialog();
            Load_LDLApps();
        }

        private void tbLike_TextChanged(object sender, EventArgs e)
        {
            Filter_LDLApps();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure to delete the Application with ID({_selectedLDLAppID}) ? ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (_LDLappServices.Delete(_selectedLDLAppID))
                    MessageBox.Show("Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Has not been deleted","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            Load_LDLApps();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure to cancel the Application? ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string error = null;
                LDLApplicationDto app = _LDLappServices.GetLDLApplication(_selectedLDLAppID);
                app.Application.Status = 2;

                if (_LDLappServices.Save(app, ref error))
                    MessageBox.Show("Canceled Successfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(error, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Load_LDLApps();
        }
        private void Adjust_MenuStrip(object sender, EventArgs e)
        {
            _selectedLDLAppID = (int)dataGridView1.CurrentRow?.Cells[0].Value;
            int nextTestType = _LDLappServices.GetNextTestType(_selectedLDLAppID);
            _LDLApp = _LDLappServices.GetLDLApplication(_selectedLDLAppID);

            scheduleTestToolStripMenuItem.Enabled = true;
            issueDrivingLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            switch (nextTestType)
            {
                case 1:
                    sheduleTestVisionToolStripMenuItem.Enabled = true;
                    sheduleWrittenTestToolStripMenuItem.Enabled = false;
                    sheToolStripMenuItem.Enabled = false;
                    break;
                case 2:
                    sheduleWrittenTestToolStripMenuItem.Enabled = true;
                    sheduleTestVisionToolStripMenuItem.Enabled = false;
                    sheToolStripMenuItem.Enabled = false;
                    
                    break;
                case 3:
                    sheToolStripMenuItem.Enabled = true;
                    sheduleWrittenTestToolStripMenuItem.Enabled = false;
                    sheduleTestVisionToolStripMenuItem.Enabled = false;
                    break;
                default:
                    if (_LDLApp.Application.Status == 3)
                    {
                        scheduleTestToolStripMenuItem.Enabled = false ; 
                        showLicenseToolStripMenuItem.Enabled = true;
                        issueDrivingLicenseToolStripMenuItem.Enabled = false;
                        cancelApplicationToolStripMenuItem.Enabled = false;
                        deleteApplicationToolStripMenuItem.Enabled = false;
                        editApplicationToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        scheduleTestToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = false;
                        issueDrivingLicenseToolStripMenuItem.Enabled = true;
                    }
                    break;
            }
        }
        
        private void Schedule_Tests_OnClick(object sender, EventArgs e)
        {
            TestAppointment form = new TestAppointment(_LDLApp.LDLApplication.ID);
            form.ShowDialog();
            Load_LDLApps();
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueDrivingLicenseForFirstTime form = new IssueDrivingLicenseForFirstTime(_LDLApp.LDLApplication.ID);
            form.ShowDialog();
            Load_LDLApps();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseInfo form = new LicenseInfo(_selectedLDLAppID);
            form.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseHistory form = new LicenseHistory(_LDLApp.Application.PersonID);
            form.ShowDialog();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            LDLApplicationDetails form = new LDLApplicationDetails(_selectedLDLAppID);
            form.ShowDialog();
        }
    }
}
