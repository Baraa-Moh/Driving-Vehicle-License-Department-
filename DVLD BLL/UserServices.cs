using Common;
using DVLD_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_BLL
{
    public class UserServices
    {
        private readonly IUserRepository _rep;
        public UserServices(IUserRepository rep)
        {
            _rep = rep;
        }
        public User GetUserByUserID(int id)
        {
            return _rep.GetUserByUserID(id);
        }
        public User GetUserByPersonID(int id)
        {
            return _rep.GetUserByPersonID(id); 
        }
        public DataTable GetAllUsers()
        {
            return _rep.GetAllUsers();
        }
        public DataView FilterUsers(DataTable users, User.enFilters filter, string Like=null)
        {
            users.CaseSensitive = false;
            DataView view = users.DefaultView;
            filter = filter==User.enFilters.None ? User.enFilters.UserID : filter;
            Like = Like ?? "";

            view.Sort= filter.ToString();
            view.RowFilter = $"Convert({filter}, 'System.String') LIKE '{Like}%'";
            return view;
        }
        private bool AddNew(ref User user)
        {
            return _rep.AddNew(ref user);
        }
        public bool Delete(int id)
        {
            return _rep.Delete(id);
        }
        private bool Update(User user)
        {
            return _rep.Update(user);
        }
        public bool Save(ref User user)
        {
            if(user.UserID == -1)
                return AddNew(ref user);
            else return Update(user);
        }
        public bool CheckUserExistsByUserID(int id)
        {
            return _rep.CheckUserExistsByUserID(id);
        }
        public bool CheckUserExistsByPersonID(int id)
        {
            return _rep.CheckUserExistsByPersonID(id);
        }
        public User Validate_Login(string Username, string Password)
        {
            if (Password == null)
                return null;
            if (!_rep.CheckUserExistsByUsername(Username))
                return null;

            if (_rep.GetUserPassword(Username) == Password && _rep.CheckUserIsActive(Username))
            {
                return _rep.GetUserByUsername(Username);
            }
            else return null;
        }
        public bool Change_Password(string Username,string CurrentPassword, string NewPassword, ref string ErrorMessage)
        {
            if (!_rep.CheckUserExistsByUsername(Username)){
                ErrorMessage = "User doesn't exist anymore";
            }
            if (Validate_Login(Username, CurrentPassword)==null)
            {
                ErrorMessage = "Invalid Current Password";
                return false;
            }
            return _rep.ChangePassword(Username, NewPassword);
        }
    }
}
