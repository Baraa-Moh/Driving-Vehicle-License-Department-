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
using DVLD_BLL;
using DVLD_DAL;

namespace DVLD.Users
{
    public partial class ManageUsers : Form
    {
        private User.enFilters _filter;
        private UserServices _userServices;
        private DataTable _users;
        public ManageUsers()
        {
            InitializeComponent();
            _userServices = new UserServices(new SqlUserRepository());
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            Load_Users();
        }
        private void Load_Users()
        {
            _users = _userServices.GetAllUsers();
            cbFilters.SelectedIndex = 0;
            dgvUsers.DataSource = _users;
            lbRecords.Text = dgvUsers.Rows.Count.ToString();
        }
        private string Custom_Like()
        {
            //Now I think it's better not to use it.
            if (_filter == User.enFilters.None)
                return null;
            if(_filter == User.enFilters.IsActive)
            {
                if (cbIsActiveFilter.SelectedIndex == 0)
                    return null;
                else if (cbIsActiveFilter.SelectedIndex == 1)
                    return "1";
                else return "0";
            }
            else 
                return tbLike.Text;
        }
        private void Filter_Users()
        {
            _filter = (User.enFilters)cbFilters.SelectedIndex;
            string Like = tbLike.Text.Trim();

            if (_filter == User.enFilters.None)
            {
                _users.DefaultView.RowFilter = null;
                _users.DefaultView.Sort = $"{User.enFilters.UserID}";
                lbRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

             if (_filter == User.enFilters.IsActive)
            {
                switch (cbIsActiveFilter.SelectedIndex)
                {
                    case 0:
                        _users.DefaultView.RowFilter = null;
                        _users.DefaultView.Sort = $"{_filter} DESC";
                        lbRecords.Text = dgvUsers.Rows.Count.ToString();
                        return;
                    case 1:
                        _users.DefaultView.RowFilter = $"{_filter} = 1";
                        break;
                    case 2:
                        _users.DefaultView.RowFilter = $"{_filter} = 0";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _users.DefaultView.RowFilter = $"Convert({_filter}, 'System.String') LIKE '{Like}%'";
            }

            _users.DefaultView.Sort = _filter.ToString();
            lbRecords.Text = dgvUsers.Rows.Count.ToString();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close(); ;
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filter = (User.enFilters)cbFilters.SelectedIndex;
            if(_filter== User.enFilters.None)
            {
                tbLike.Visible = false;
                cbIsActiveFilter.Visible = false;
            }
            else if (_filter == User.enFilters.IsActive)
            {
                tbLike.Visible = false;
                cbIsActiveFilter.Visible = true;
                cbIsActiveFilter.SelectedIndex = 0;
            }
            else
            {
                tbLike.Visible=true;
                cbIsActiveFilter.Visible = false;
            }
            Filter_Users(); 
        }

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                Filter_Users();
        }

        private void tbLike_TextChanged(object sender, EventArgs e)
        {
            Filter_Users();
        }

        private void tbLike_VisibleChanged(object sender, EventArgs e)
        {
            if (!tbLike.Visible)
                tbLike.Text = null;
        }

        private void btAddUser_Click(object sender, EventArgs e)
        {
            AddUpdateUser form = new AddUpdateUser();   
            form.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateUser form = new AddUpdateUser();
            form.ShowDialog();
            Load_Users();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateUser form = new AddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();  
            Load_Users();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID= (int)dgvUsers.CurrentRow.Cells [0].Value;
            if (MessageBox.Show($"Are you sure you want to delete the user with ID= {UserID}", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_userServices.Delete(UserID))
                {
                    MessageBox.Show("Has been deleted", "Deleted");
                }
                else MessageBox.Show("It has relations couldn't be deleted", "Failed");
            }
            Load_Users() ;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            ChangePassword form = new ChangePassword(UserID);
            form.ShowDialog();
            Load_Users();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            UserInfo form = new UserInfo(UserID);
            form.ShowDialog();
            Load_Users();   
        }
    }
}
