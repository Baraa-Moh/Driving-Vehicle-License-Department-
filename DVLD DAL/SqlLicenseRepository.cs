using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DVLD_DAL
{
    public class SqlLicenseRepository : ILicenseRepository
    {
        private readonly string _connectionString;

        public SqlLicenseRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }

        public DataTable GetAllLicensesByDriverID(int driverID)
        {
            DataTable licenses =new DataTable();
            SqlConnection conn= new SqlConnection(_connectionString);
            string Query = "SELECT * FROM Licenses WHERE DriverID = @ID";
            SqlCommand command = new SqlCommand (Query ,conn);
            command.Parameters.AddWithValue("@ID", driverID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    licenses.Load(reader);
                else licenses = null;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return licenses;
        }
        public Common.License GetLicense(int LicenseID)
        {
            Common.License license = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM Licenses WHERE LicenseID = @ID";
            SqlCommand command = new SqlCommand(Query ,conn);
            command.Parameters.AddWithValue("@ID",LicenseID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    license = MapLicense(reader);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return license;
        }
        public Common.License GetLicenseByAppID(int appID)
        {
            Common.License license = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM Licenses WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", appID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    license = MapLicense(reader);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return license;
        }
        private Common.License MapLicense(SqlDataReader reader)
        {
            return new Common.License((int)reader["LicenseID"], (int)reader["ApplicationID"],
                (int)reader["DriverID"], Convert.ToInt32(reader["LicenseClass"]),
                (DateTime)reader["IssueDate"], (DateTime)reader["ExpirationDate"],
                reader["Notes"] as string, Convert.ToDouble(reader["PaidFees"]),
                (bool)reader["IsActive"], Convert.ToByte(reader["IssueReason"]),
                (int)reader["CreatedByUserID"]);
        }
        public bool Delete(int LicenseID)
        {
            bool deleted = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "DELETE FROM Licenses WHERE LicenseID = @ID";
            SqlCommand command  = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@ID", LicenseID);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery();
                deleted = (affected > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return deleted;
        }
        public bool AddNew (Common.License license, ref string error)
        {
            bool added = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"INSERT INTO Licenses (ApplicationID,DriverID,LicenseClass,
IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID)
VALUES(@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,
@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID)
SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@ApplicationID",license.ApplicationID);
            command.Parameters.AddWithValue("@DriverID",license.DriverID);
            command.Parameters.AddWithValue("@LicenseClass",license.LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate",license.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate",license.ExpirationDate);
            command.Parameters.AddWithValue("@Notes",license.Notes);
            command.Parameters.AddWithValue("@PaidFees",license.PaidFees);
            command.Parameters.AddWithValue("@IsActive", license.isActive);
            command.Parameters.AddWithValue("@IssueReason", license.IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID",license.CreatedByUserID);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();    

                if(int.TryParse(result?.ToString(),out int InsertedID)){
                    license.LicenseID = InsertedID;
                    added = true;   
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                throw;
            }
            finally { conn.Close(); }
            return added;
        }
        public bool Update(Common.License license)
        {
            bool updated = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"UPDATE Licenses SET ApplicationID = @ApplicationID,
DriverID = @DriverID, LicenseClassID = @LicenseClassID, IssueDate = @IssueDate,
ExpirationDate= @ExpirationDate, Notes = @Notes, PaidFees = @PaidFees,
IsActive = @IsActive, IssueReason = @IssueReason, CreatedByUserID= @CreatedByUserID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ApplicationID",license.ApplicationID);
            command.Parameters.AddWithValue("@DriverID",license.DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", license.LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate",license.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate",license.ExpirationDate);
            command.Parameters.AddWithValue("@Notes",license.Notes);
            command.Parameters.AddWithValue("@PaidFees",license.PaidFees);
            command.Parameters.AddWithValue("@IsActive", license.isActive);
            command.Parameters.AddWithValue("@IssueReason", license.IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID",license.CreatedByUserID);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery();
                updated = (affected > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally {  conn.Close(); }
            return updated;
        }
    }
}
