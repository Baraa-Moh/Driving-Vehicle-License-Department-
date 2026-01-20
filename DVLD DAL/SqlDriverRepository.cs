using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class SqlDriverRepository : IDriverRepository
    {
        private readonly string _connectionString;

        public SqlDriverRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }

        public Driver GetDriver(int driverID)
        {
            Driver driver = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM Drivers WHERE DriverID = @ID";
            SqlCommand command  = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", driverID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    driver = MapDriver(reader); 
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return driver;
        }
        public Driver GetDriverByPersonID(int personID)
        {
            Driver driver = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM Drivers WHERE PersonID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", personID);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    driver = MapDriver(reader);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return driver;
        }
        private Driver MapDriver(SqlDataReader reader)
        {
            return new Driver((int)reader["DriverID"], (int)reader["PersonID"],
                (int)reader["CreatedByUserID"], (DateTime)reader["CreatedDate"]);
        }
        public DataTable GetAllDrivers()
        {
            DataTable drivers = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM Drivers";
            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                    drivers.Load(reader);
                else drivers = null;
            }
            catch (Exception)
            {

                throw;
            }
            finally { sqlConnection.Close(); }
            return drivers;
        }
        public bool AddNew(Driver driver)
        {
            bool added = false;
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            string Query = @"INSERT INTO Drivers (PersonID,CreatedByUserID,CreatedDate)
VALUES (@PersonID,@CreatedByUserID,@CreatedDate)
SELECT SCOPE_IDENTITY();";
            SqlCommand sqlCommand = new SqlCommand( Query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", driver.PersonID);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID",driver.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", driver.CreatedDate);

            try
            {
                sqlConnection.Open();

                object result = sqlCommand.ExecuteScalar();
                if (int.TryParse(result?.ToString(),out int InsertedID))
                {
                    driver.DriverID = InsertedID;
                    added = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { sqlConnection.Close(); }
            return added;
        }
        public bool Delete(int driverID)
        {
            bool deleted = false;   
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "DELETE FROM Drivers WHERE DriverID = @ID";
            SqlCommand sqlCommand = new SqlCommand(Query, conn);
            sqlCommand.Parameters.AddWithValue("@ID",driverID);

            try
            {
                conn.Open();

                int affected = sqlCommand.ExecuteNonQuery();
                deleted = (affected > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return deleted;
        }
        public bool Update(Driver driver)
        {
            bool updated = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"UPDATE Drivers SET PersonID = @PersonID, CreatedByUserID = @CreatedByUserID,
CreatedDate = @CreatedDate";
            SqlCommand sqlCommand = new SqlCommand( Query, conn);
            sqlCommand.Parameters.AddWithValue("@PersonID",driver.PersonID);
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", driver.CreatedByUserID);
            sqlCommand.Parameters.AddWithValue("@CreatedDate",driver.CreatedDate); ;

            try
            {
                conn.Open();

                int affected = sqlCommand.ExecuteNonQuery();
                updated = (affected > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return updated;
        }
    }
}
