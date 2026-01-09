using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class User
    {
        public enum enFilters
        {
            None,UserID,Username,FullName,PersonID,IsActive
        }
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }


        public User(int UserID, int PersonID,  string Username, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
        }
        public User()
        {
            UserID = -1;
            IsActive = UserID != -1 ? true : false;
        }
    }
}
