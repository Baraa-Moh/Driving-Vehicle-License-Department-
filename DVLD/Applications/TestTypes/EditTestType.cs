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
    public partial class EditTestType : Form
    {
        private TestType _testType;
        private TestTypeServices _services;
        public EditTestType(int testTypeID)
        {
            InitializeComponent();
            _services = new TestTypeServices(new SqlTestTypeRepository());
            _testType = _services.GetTestType(testTypeID);
        }

        private void EditTestType_Load(object sender, EventArgs e)
        {
            if( _testType == null )
            {
                MessageBox.Show("It doesn't exist anymore","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
            Fill_Controls();
        }
        private void Fill_Controls()
        {
            lbID.Text = _testType.ID.ToString();
            tbTitle.Text = _testType.Title.ToString();
            tbDescription.Text = _testType.Description.ToString();
            tbFees.Text = _testType.Fees.ToString();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Fill_TestType()
        {
            _testType.Title = tbTitle.Text;
            _testType.Description = tbDescription.Text;
            _testType.Fees = Convert.ToDouble(tbFees.Text);
        }
        private bool Validate_Fields()
        {
            bool valid = true;
            if(tbTitle.Text.Length <= 0)
            {
                valid = false;
                errorProvider1.SetError(tbTitle, "Required");
            }else errorProvider1.SetError(tbTitle,string.Empty);
            if(tbDescription.Text.Length <= 0)
            {
                valid = false;
                errorProvider1.SetError(tbDescription, "Required");
            }else errorProvider1.SetError(tbDescription, string.Empty); 
            if(tbFees.Text.Length <= 0)
            {
                valid=false;
                errorProvider1.SetError(tbFees, "Required");
            }else errorProvider1.SetError(tbFees , string.Empty);

            return valid;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!Validate_Fields())
                return;

            Fill_TestType();
            if(_services.Save(ref _testType))
            {
                MessageBox.Show("Data has been saved successfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Data hasn't been saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
