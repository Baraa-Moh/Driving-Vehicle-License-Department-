using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class SqlInternationalLicenseRepo : IInternationalLicenseRepo
    {
        private readonly string _connectionString;
        public SqlInternationalLicenseRepo()
        {
            _connectionString = DataSettings.ConnectionString;
        }

        public DataTable GetAllInternationalLicenses()
        {
            DataTable all = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM InternationalLicenses";
            SqlCommand cmd = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                    all.Load(reader);
                else all = null;
            }
            catch (Exception)
            {

                throw;
            }
            finally {conn.Close();}
            return all;
        }
        public InternationalLicense GetInternationalLicenseByDriverID(int id)
        {
            InternationalLicense license = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM InternationalLicenses WHERE DriverID = @Id";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    license = MapInternationalLicense(reader);
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return license;
        }
        public InternationalLicense MapInternationalLicense(SqlDataReader reader)
        {
            return new InternationalLicense
            {
                InternationalLicenseID = Convert.ToInt32(reader["InternationalLicenseID"]),
                ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                DriverID = Convert.ToInt32(reader["DriverID"]),
                IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]),
                IssueDate = Convert.ToDateTime(reader["IssueDate"]),
                ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]),
                IsActive = Convert.ToBoolean(reader["IsActive"]),
                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"])
            };
        }
        public bool AddNew(InternationalLicense license)
        {
            bool added = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"INSERT INTO InternationalLicenses 
                            (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID) 
                            VALUES 
                            (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", license.DriverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", license.IssuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", license.IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
            cmd.Parameters.AddWithValue("@IsActive", license.IsActive);
            cmd.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if(int.TryParse(result?.ToString(), out int newId))
                {
                    license.InternationalLicenseID = newId;
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
        public bool Update(InternationalLicense license)
        {
            bool updated = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"UPDATE InternationalLicenses SET 
                            ApplicationID = @ApplicationID, 
                            DriverID = @DriverID, 
                            IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID, 
                            IssueDate = @IssueDate, 
                            ExpirationDate = @ExpirationDate, 
                            IsActive = @IsActive, 
                            CreatedByUserID = @CreatedByUserID
                            WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", license.InternationalLicenseID);
            cmd.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", license.DriverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", license.IssuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", license.IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
            cmd.Parameters.AddWithValue("@IsActive", license.IsActive);
            cmd.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                updated = rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return updated;
        }
        public bool Delete(int id)
        {
            bool deleted = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", id);
            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                deleted = rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return deleted;
        }   
    }
}
