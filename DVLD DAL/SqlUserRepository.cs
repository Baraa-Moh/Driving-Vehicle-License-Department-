using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_DAL
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public SqlUserRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }
        private User MapUser(SqlDataReader reader)
        {
            
           
            return new User(
                        (int)reader["UserID"],
                        (int)reader["PersonID"],
                        reader["Username"] as string,
                        reader["Password"] as string,
                        (bool)reader["IsActive"]
                        );
        }
        public User GetUserByUserID(int id)
        {
            User user = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"SELECT * FROM Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@UserID", id);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = MapUser(reader);
                }
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); }
            return user;
        }
        public User GetUserByPersonID(int id)
        {
            User user = null;
            SqlConnection conn = new SqlConnection(DataSettings.ConnectionString);
            string Query = @"SELECT * FROM Users WHERE PersonID = @PersonID";
            SqlCommand command =new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@PersonID", id);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = MapUser(reader);
                }
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); }
            return user;
        }
        public User GetUserByUsername(string username)
        {
            User user = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM Users WHERE Username = @Username";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@Username", username);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = MapUser(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return user;
        }
        public DataTable GetAllUsers()
        {
            DataTable Users = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"SELECT us.UserID,us.PersonID, FullName = pe.FirstName +' '+pe.SecondName+' '+
                             pe.ThirdName+' '+pe.LastName , us.Username, us.IsActive
                             FROM Users us INNER JOIN People pe ON us.PersonID = pe.PersonID";
            SqlCommand command = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Users.Load(reader);
                }
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); }
            return Users;
        }
        public bool AddNew(ref User user)
        {
            bool Added = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"INSERT INTO Users (PersonID,Username,Password,IsActive)
                           VALUES(@PersonID, @Username,@Password,@IsActive)
                           SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@PersonID",user.PersonID);
            command.Parameters.AddWithValue("@Username",user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);
            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                if(int.TryParse(result?.ToString(), out int insertedID))
                {
                    user.UserID = insertedID;
                    Added = true;
                }
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); }
            return Added;
        }
        public bool Update(User user)
        {
            bool Updated = false;
            SqlConnection conn = new SqlConnection (_connectionString);
            string Query = @"Update Users SET Username = @Username, Password = @Password, IsActive = @IsActive WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@UserID", user.UserID);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery();
                Updated = (affected > 0);
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); }
            return Updated;
        }
        public bool Delete(int id)
        {
            bool Deleted = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"DELETE FROM Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@UserID",id); ;

            try
            {
                conn.Open();
                int Affected = command.ExecuteNonQuery();
                Deleted = Affected > 0;
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); }
            return Deleted;
        }
        public bool CheckUserExistsByUserID(int id)
        {
            bool Found = false;
            SqlConnection conn = new SqlConnection( _connectionString);
            string Query = @"SELECT 1 FROM Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@UserID",id);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                Found = (result != null && result != DBNull.Value && Convert.ToInt32(result) == 1);
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); }
            return Found;
        }
        public bool CheckUserExistsByPersonID(int id)
        {
            bool Found = false; 
            SqlConnection conn = new SqlConnection( _connectionString);
            string Query = @"SELECT 1 FROM Users WHERE PersonID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                Found = (result != null && result != DBNull.Value && Convert.ToInt32(result) == 1);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return Found;
        }
        public string GetUserPassword(string username)
        {
            string password = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT Password FROM Users WHERE Username = @Username";
            SqlCommand command = new SqlCommand (Query, conn);
            command.Parameters.AddWithValue("@Username",username);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                password = result == null ? null : Convert.ToString(result);
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return password;
        }
        public bool CheckUserExistsByUsername(string username)
        {
            bool found = false;
            SqlConnection conn = new SqlConnection( _connectionString);
            string Query = "SELECT 1 FROM Users WHERE Username = @Username";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue ("@Username", username);

            try
            {
                conn.Open ();
                object result = command.ExecuteScalar();
                found = (result != null && result != DBNull.Value);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return found;
        }
        public bool ChangePassword(string username, string password)
        {
            bool changed = false;
            SqlConnection conn = new SqlConnection ( _connectionString);
            string Query = "Update Users SET Password = @Password WHERE Username = @Username";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue ("@Username", username);
            command.Parameters.AddWithValue("@Password",password);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery ();
                changed = (affected > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return changed;
        }
        public bool CheckUserIsActive(string Username)
        {
            bool active = false;
            SqlConnection conn = new SqlConnection( _connectionString);
            string Query = "SELECT 1 FROM Users WHERE Username = @Username";
            SqlCommand command = new SqlCommand (Query,conn);
            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                active = (result != null&& result != DBNull.Value);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return active;
        }
    }
}
