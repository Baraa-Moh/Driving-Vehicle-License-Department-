using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DVLD_DAL
{
    public class SqlApplicationRepository : IApplicationRepository
    {
        private readonly string _connectionString;
        public SqlApplicationRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }
        public DataTable GetAllApplications()
        {
            DataTable applications = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM Applications";
            SqlCommand command = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    applications.Load(reader);
                else applications = null;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return applications; 
        }
        
        private Application MapApplication(SqlDataReader reader)
        {
            return new Application((int)reader["ApplicationID"], (int)reader["ApplicationPersonID"],
                Convert.ToDateTime(reader["ApplicationDate"]), (int)reader["ApplicationTypeID"],
                Convert.ToInt32(reader["ApplicationStatus"]), Convert.ToDateTime(reader["LastStatusDate"]),
                Convert.ToDouble(reader["PaidFees"]), (int)reader["CreatedByUserID"]);
        }
        public Application GetApplicationByID(int id)
        {
            Application app = null;
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = "SELECT * FROM Applications WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                app = MapApplication(reader);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return app;
        }
        public bool AddNew(Application app)
        {
            bool added= false;
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = @"INSERT INTO Applications (ApplicationPersonID,ApplicationDate,
                            ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                            VALUES(@PersonID,@Date,@TypeID,@Status,@LastStatusDate,@PaidFees,@CreatedBy)
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@PersonID", app.PersonID);
            command.Parameters.AddWithValue("@Date",DateTime.Now);
            command.Parameters.AddWithValue("@TypeID",app.TypeID);
            command.Parameters.AddWithValue("@Status",app.Status);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            command.Parameters.AddWithValue("@PaidFees",app.PaidFees);
            command.Parameters.AddWithValue("@CreatedBy",app.CreatedBy);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                if(int.TryParse(result?.ToString(),out int InsertedID)){
                    app.ID = InsertedID;
                    added = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return added;
        }
        public bool Update(Application app)
        {
            bool updated= false;
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = @"Update Applications SET ApplicationStatus = @Status,
                           LastStatusDate = @LastStatusDate WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);   
            command.Parameters.AddWithValue("@ID",app.ID);
            command.Parameters.AddWithValue("@Status", app.Status);
            command.Parameters.AddWithValue("@LastStatusDate",DateTime.Now);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery();
                updated = affected > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return updated;
        }
        public bool Delete(int  appID)
        {
            bool deleted= false;
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = "DELETE FROM Applications WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", appID);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery();
                deleted = affected > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return deleted;
        }
        public bool CheckApplicationExists(int appID)
        {
            bool exists = false;
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = "SELECT 1 FROM Applications WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", appID);

            try
            {
                conn.Open();
                object result = (object)command.ExecuteScalar();
                exists = (result != DBNull.Value && result != null);
            }
            catch (Exception)
            {

                throw;
            }
            finally{ conn.Close(); }
            return exists;
        }
    }
}
