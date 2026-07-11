using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DVLD_DAL
{
    public class SqlPersonRepository : IPersonRepository
    {
        
        private string _connectionString;
        public SqlPersonRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }
        public  Person FindByID(int id)
        {
            Person person = null;

            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = "SELECT * FROM People WHERE PersonID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    person = MapPerson(reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
            return person;
        }
        public  Person FindByNationalNo(string id)
        {
            Person person = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM People WHERE NationalNo = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    person = MapPerson(reader);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { conn.Close(); }
            return person;
        }
        private Person MapPerson(SqlDataReader reader)
        {

            return new Person
            (
                (int)reader["PersonID"],
                reader["NationalNo"] as string,
                 reader["FirstName"] as string,
                 reader["SecondName"] as string,
                 reader["LastName"] as string,
                 (DateTime)reader["DateOfBirth"],
                 Convert.ToByte(reader["Gender"]),
                 reader["Address"] as string,
                 reader["Phone"] as string,
                 reader["Email"] as string,
                 Convert.ToUInt16(reader["NationalityCountryID"]),
                 reader["ThirdName"] as string,
                 reader["ImagePath"] as string
            );
        }
        public  bool AddNew(Person person)
        {
            bool Added=false; 
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName,
                            DateOfBirth,Gender,Address,Email,Phone,NationalityCountryID,ImagePath)
                            VALUES(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,
                            @Gender,@Address,@Email,@Phone,@NationalityCountryID,@ImagePath)
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@NationalNo", person.NationalID);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@SecondName", person.SecondName);
            command.Parameters.AddWithValue("@ThirdName", (object)person.ThirdName ?? DBNull.Value);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender",person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Email",(object)person.Email ?? DBNull.Value);
            command.Parameters.AddWithValue("@Phone",person.Phone);
            command.Parameters.AddWithValue("@NationalityCountryID",(int)person.NationalityID);
            command.Parameters.AddWithValue("@ImagePath", (object)person.ImagePath ?? DBNull.Value);

            try
            {
                conn.Open();

                object result = command.ExecuteScalar();    

                if(int.TryParse(result?.ToString(), out int InsertedID))
                {
                    person.ID = InsertedID;
                    Added = true;
                }
                    

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return Added;
        }
        public  bool Update(Person person)
        {
            bool Updated = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"Update People SET NationalNo = @NationalID, FirstName = @First, SecondName= @Second, 
                             ThirdName= @Third, LastName= @Last, DateOfBirth = @Date,
                              Gender = @Gender, Address = @Address, Phone= @Phone,
                               Email = @Email, NationalityCountryID = @NationalityID,
                               ImagePath= @ImagePath
                               WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@PersonID", person.ID);
            command.Parameters.AddWithValue("@NationalID", person.NationalID);
            command.Parameters.AddWithValue("@First", person.FirstName);
            command.Parameters.AddWithValue("@Second",person.SecondName);
            command.Parameters.AddWithValue("@Third", (object)person.ThirdName ?? DBNull.Value);
            command.Parameters.AddWithValue("@Last", person.LastName);
            command.Parameters.AddWithValue("@Date",person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender",person.Gender);
            command.Parameters.AddWithValue("@Address",person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);
            command.Parameters.AddWithValue("@Email",(object) person.Email?? DBNull.Value);
            command.Parameters.AddWithValue("@NationalityID",(int)person.NationalityID);
            command.Parameters.AddWithValue("@ImagePath",(object)person.ImagePath?? DBNull.Value);

            try
            {
                conn.Open();

               int  result = command.ExecuteNonQuery();
                Updated = (result> 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return Updated;
        }
        public  bool Delete(int ID)
        {
            bool Deleted = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = $@"DELETE FROM People WHERE PersonID = @ID";
            SqlCommand command = new SqlCommand (Query,conn);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                conn.Open ();
                int result = command.ExecuteNonQuery();
                Deleted = (result> 0);
            }
            catch (Exception)
            {

            }
            finally { conn.Close (); }
            return Deleted;
        }
        public  bool ExistsByPersonID(int ID)
        {
            bool exists= false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = $"SELECT 1 FROM People WHERE PersonID = @ID";
            SqlCommand command = new SqlCommand (Query,conn);
            command.Parameters.AddWithValue("@ID",ID);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                exists = (result != null && result!= DBNull.Value && Convert.ToInt32(result)==1);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close (); }
            return exists;
        }
        public bool ExistsByNationalNo(string ID)
        {
            bool exists = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = $"SELECT 1 FROM People WHERE NationalNo = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                exists = (result != null && result != DBNull.Value && Convert.ToInt32(result) == 1);
            }
            catch (Exception)
            {

            }
            finally { conn.Close(); }
            return exists;
        }

        private string CustomQuery(Person.enFilters filter, string like = null)
        {
            if(like == null)
                like = string.Empty;    
            if(filter == Person.enFilters.none)                
                    return "SELECT * FROM People";
            else
                return $"SELECT * FROM People WHERE {filter} LIKE '{like}%' Order by {filter}";
                
        }
        public  DataTable GetAllPeople(Person.enFilters filter, string like = null)
        {
            DataTable People = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = CustomQuery(filter,like);
            SqlCommand command= new SqlCommand (Query,conn);

            try
            {
                conn.Open();
                
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows) 
                    People.Load (reader);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close (); }
            return People;
        }
        public DataTable GetAllPeople()
        {
            DataTable People = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);    
            string Query = @"SELECT PersonID, NationalNo, FirstName, SecondName, ThirdName, 
                           LastName, DateOfBirth, Gender = CASE 
                           WHEN Gender = 0 THEN 'Male'
                           WHEN Gender = 1 THEN 'Female'
                           END,
                           Address, Phone, Email, Countries.CountryName AS Nationality,
                           ImagePath
                           FROM People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID";
            SqlCommand command = new SqlCommand (Query,conn);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                    People.Load (reader);
                
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close (); }
           return People ;
        }
        public Person GetPerson(int id)
        {
            Person person = null;
            SqlConnection conn = new SqlConnection (_connectionString);
            string Query = "SELECT * FROM People WHERE PersonID = @ID";
            SqlCommand command = new SqlCommand(Query,conn);    
            command.Parameters.AddWithValue ("@ID", id);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   person = MapPerson(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close (); }
            return person;
        }
    }
}
