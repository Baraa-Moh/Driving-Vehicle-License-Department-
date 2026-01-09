using Common;
using System.Data;
namespace DVLD_DAL
{
    public interface IUserRepository
    {
        User GetUserByUserID(int id);
        User GetUserByPersonID(int id);
        User GetUserByUsername(string userName);
        DataTable GetAllUsers(); 
        bool AddNew(ref User user);
        bool Update(User user);
        bool CheckUserExistsByUserID(int id);
        bool CheckUserExistsByPersonID(int id);
        bool CheckUserExistsByUsername(string username);
        bool Delete(int id);
        string GetUserPassword(string username);
        bool ChangePassword(string username, string password);
        bool CheckUserIsActive(string Username);
    }
}
