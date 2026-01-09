using Common;
using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class ApplicationServices
    {
        private readonly IApplicationRepository _rep;
        public ApplicationServices(IApplicationRepository rep)
        {
            _rep = rep;
        }

        public DataTable GetAllApplications()
        {
            return _rep.GetAllApplications();
        }
        public Application GetApplicationByID(int id)
        {
            return _rep.GetApplicationByID(id);
        }
        private bool AddNew(Application app)
        {
            return _rep.AddNew(app);
        }
        private bool Update(Application app)
        {
            return _rep.Update(app);
        }
        public bool Save(Application app)
        {
            if (app.ID == -1 || !CheckApplicationExists(app.ID))
            {
                
                return _rep.AddNew(app);
            }
                
            else return _rep.Update(app);
        }
        public bool Delete(int appID)
        {
            return _rep.Delete(appID);  
        }
        public bool CheckApplicationExists(int appID)
        {
            return _rep.CheckApplicationExists(appID);
        }
    }
}
