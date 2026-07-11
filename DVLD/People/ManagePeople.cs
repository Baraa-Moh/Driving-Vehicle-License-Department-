using DVLD_BLL;
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
using DVLD_DAL;
namespace DVLD.People
{
    public partial class ManagePeople : Form
    {
        Person.enFilters filter;
        private PersonServices _services ;
        private DataTable People;
        public ManagePeople()
        {
            InitializeComponent();
            _services = new PersonServices(new SqlPersonRepository());
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            Load_People();
            
        }
        private void Load_People()
        {
            People = _services.GetAllPeople();
            cbFilters.SelectedIndex = 0;
            dgvAllPeople.DataSource = People;
            lbRecords.Text= dgvAllPeople.Rows.Count.ToString();
            AdjustDataGrid();
        }
        private void AdjustDataGrid()
        {
            if (dgvAllPeople.Columns.Count > 0)
            {
                dgvAllPeople.Columns[0].HeaderText ="ID";
                dgvAllPeople.Columns[0].Width = 110;

                dgvAllPeople.Columns[1].HeaderText = "National No.";
                dgvAllPeople.Columns[1].Width = 120;

                dgvAllPeople.Columns[2].HeaderText = "First Name";
                dgvAllPeople.Columns[2].Width = 120;

                dgvAllPeople.Columns[3].HeaderText = "Second Name";
                dgvAllPeople.Columns[3].Width = 120;

                dgvAllPeople.Columns[4].HeaderText = "Third Name";
                dgvAllPeople.Columns[4].Width = 120;

                dgvAllPeople.Columns[5].HeaderText = "Last Name";
                dgvAllPeople.Columns[5].Width = 120;

                dgvAllPeople.Columns[6].HeaderText = "Birth Date";
                dgvAllPeople.Columns[6].Width = 170;

                dgvAllPeople.Columns[7].HeaderText = "Gender";
                dgvAllPeople.Columns[7].Width = 100;

                dgvAllPeople.Columns[8].HeaderText = "Address";
                dgvAllPeople.Columns[8].Width = 200;

                dgvAllPeople.Columns[9].HeaderText = "Phone";
                dgvAllPeople.Columns[9].Width = 120;

                dgvAllPeople.Columns[10].HeaderText = "Email";
                dgvAllPeople.Columns[10].Width = 120;

                dgvAllPeople.Columns[11].HeaderText = "Nationality";
                dgvAllPeople.Columns[11].Width = 120;
            }
        }
        private void Filter_People()
        {
            filter = (Person.enFilters)cbFilters.SelectedIndex;
            string Like = cbFilters.SelectedIndex == 0 ? null : tbLike.Text;
            dgvAllPeople.DataSource = _services.FilterPeople(filter,People,Like);
            lbRecords.Text = dgvAllPeople.Rows.Count.ToString();
        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.SelectedIndex != 0)
                tbLike.Visible = true;
            else tbLike.Visible = false;
            Filter_People();
        }

        private void Refresh_People()
        {
            Load_People();
            Filter_People();
        }
        private void tbLike_TextChanged(object sender, EventArgs e)
        {
            Filter_People();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPerson_Click(object sender, EventArgs e)
        {
            AddUpdatePerson form = new AddUpdatePerson(); 
            form.ShowDialog();
            Load_People();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddUpdatePerson form = new AddUpdatePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            Refresh_People();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID =(int) dgvAllPeople.CurrentRow.Cells[0].Value;
            if (MessageBox.Show($"Are you sure to delete the person with ID({PersonID}) ? ", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.OK)
            {
                if (_services.Delete(PersonID))
                    MessageBox.Show("Deleted Successfully");
                else MessageBox.Show("it has relations, couldn't be deleted");
            }
            Refresh_People();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int _id = (int)dgvAllPeople.CurrentRow.Cells[0].Value;
            PersonDetails form = new PersonDetails(_id);
            form.ShowDialog();
        }
    }
}
