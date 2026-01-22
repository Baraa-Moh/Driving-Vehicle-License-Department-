using DVLD.People;
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

namespace DVLD.UserControls
{
    public partial class ctrlAppBasicInfo : UserControl
    {
        private  Common.Application _app;
        private readonly ApplicationServices _appServices;
        //Better not to be handled here but for simplicity :)
        private readonly ApplicationTypeServices _appTypeServices;
        private readonly PersonServices _personServices;
        public ctrlAppBasicInfo()
        {
            InitializeComponent();
            _app = null;
            _appServices = new ApplicationServices(new SqlApplicationRepository());
            _appTypeServices = new ApplicationTypeServices(new SqlApplicationTypeRepository());
            _personServices = new PersonServices(new SqlPersonRepository());
        }
        public void Load_Application(int AppID)
        {
            _app = _appServices.GetApplicationByID(AppID);
            Fill_Fields();
        }
        public void Load_Application(Common.Application app)
        {
            _app = app;
            Fill_Fields();
        }
        private void Fill_Fields()
        {
            lbID.Text = _app.ID != -1 ? _app.ID.ToString() : "???";
            lbStatus.Text = _app.Status.ToString(); 
            lbType.Text = _appTypeServices.GetApplicationType(_app.TypeID).Title;
            lbApplicatnt.Text = _personServices.GetPerson(_app.PersonID)?.FullName ?? "???";
            lbFees.Text = _app.PaidFees.ToString(); 
            lbDate.Text = _app.Date.ToString();
            lbStatusDate.Text = _app.LastStatuesDate.ToString();
            lbCreatedBy.Text = _app.CreatedBy.ToString();   
        }
        private void ctrlAppBasicInfo_Load(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            lbID.Text = "???";
            lbStatus.Text = "???";
            lbType.Text = "???";
            lbApplicatnt.Text = "???";
            lbFees.Text = "???";
            lbDate.Text = "???";
            lbStatusDate.Text = "???";
            lbCreatedBy.Text = "???";
            _app = null;
        }
        private void lLbViewPersonInfo_Click(object sender, EventArgs e)
        {
            PersonDetails form = new PersonDetails(_app.PersonID);
            form.ShowDialog();
        }
    }
}
