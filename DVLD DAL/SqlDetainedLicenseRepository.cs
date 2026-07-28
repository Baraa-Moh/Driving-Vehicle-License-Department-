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
    public class SqlDetainedLicenseRepository : IDetainedLicenseRepository
    {

        private readonly string _connectionString;
        public SqlDetainedLicenseRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }
        public DataTable GetAllDetains()
        {
            DataTable detains = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM DetainedLicenses";
            SqlCommand cmd = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    detains.Load(reader);
                }
                else detains = null;
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return detains;
        }
        public DetainedLicense GetDetainByID(int detainID)
        {
            DetainedLicense detainedLicense = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@DetainID", detainID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    detainedLicense = MapReaderToDetainedLicense(reader);
                }

            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return detainedLicense;
        }
        private DetainedLicense MapReaderToDetainedLicense(SqlDataReader reader)
        {
            DetainedLicense detainedLicense = new DetainedLicense();
            detainedLicense.DetainID = Convert.ToInt32(reader["DetainID"]);
            detainedLicense.LicenseID = Convert.ToInt32(reader["LicenseID"]);
            detainedLicense.DetainDate = Convert.ToDateTime(reader["DetainDate"]);
            detainedLicense.FineFees = Convert.ToDouble(reader["FineFees"]);
            detainedLicense.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
            detainedLicense.IsReleased = Convert.ToBoolean(reader["IsReleased"]);
            detainedLicense.ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["ReleaseDate"]);
            detainedLicense.ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["ReleasedByUserID"]);
            detainedLicense.ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : Convert.ToInt32(reader["ReleaseApplicationID"]);
            return detainedLicense;
        }
        public DetainedLicense GetDetainByLicenseID(int licenseID)
        {
            DetainedLicense detainedLicense = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID AND ISReleased = 0";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    detainedLicense = MapReaderToDetainedLicense(reader);
                }
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return detainedLicense;
        }
        public bool AddNewDetain(DetainedLicense detainedLicense)
        {
            bool isAdded = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID) " +
                           "VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID)" +
                           "SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", detainedLicense.LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", detainedLicense.DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", detainedLicense.FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", detainedLicense.CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", detainedLicense.IsReleased);
            cmd.Parameters.AddWithValue("@ReleaseDate", detainedLicense.IsReleased ? (object)detainedLicense.ReleaseDate : DBNull.Value);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", detainedLicense.IsReleased ? (object)detainedLicense.ReleasedByUserID : DBNull.Value);
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", detainedLicense.IsReleased ? (object)detainedLicense.ReleaseApplicationID : DBNull.Value);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (int.TryParse(result?.ToString(), out int newID))
                {
                    isAdded = true;
                    detainedLicense.DetainID = newID;
                }
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return isAdded;
        }
        public bool UpdateDetain(DetainedLicense detainedLicense)
        {
            bool isUpdated = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "UPDATE DetainedLicenses SET LicenseID = @LicenseID, DetainDate = @DetainDate, FineFees = @FineFees, " +
                           "CreatedByUserID = @CreatedByUserID, IsReleased = @IsReleased, ReleaseDate = @ReleaseDate, " +
                           "ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID WHERE DetainID = @DetainID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@DetainID", detainedLicense.DetainID);
            cmd.Parameters.AddWithValue("@LicenseID", detainedLicense.LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", detainedLicense.DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", detainedLicense.FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", detainedLicense.CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", detainedLicense.IsReleased);
            cmd.Parameters.AddWithValue("@ReleaseDate", detainedLicense.IsReleased ? (object)detainedLicense.ReleaseDate : DBNull.Value);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", detainedLicense.IsReleased ? (object)detainedLicense.ReleasedByUserID : DBNull.Value);
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", detainedLicense.IsReleased ? (object)detainedLicense.ReleaseApplicationID : DBNull.Value);
            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return isUpdated;
        }
        public bool DeleteDetain(int detainID)
        {
            bool isDeleted = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "DELETE FROM DetainedLicenses WHERE DetainID = @DetainID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@DetainID", detainID);
            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                isDeleted = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return isDeleted;
        }
    }
}
