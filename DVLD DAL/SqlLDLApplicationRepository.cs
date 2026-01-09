using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DAL
{
    public class SqlLDLApplicationRepository : ILDLApplicationRepository
    {
        private readonly string _connectionString;
        public SqlLDLApplicationRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }

        public DataTable GetAllApplications()
        {
            DataTable apps = new DataTable();
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = @"SELECT 
             LDA.LocalDrivingLicenseApplicationID AS [L.D.L.AppID],
             LC.ClassName AS [Driving Class],
             Pe.NationalNo AS [National No.],
             Pe.FirstName + ' ' + Pe.SecondName + ' ' + Pe.ThirdName + ' ' + Pe.LastName AS [FullName],
             App.ApplicationDate AS [Application Date],
             (SELECT COUNT(*) 
              FROM Tests 
              WHERE TestAppointmentID IN (
                  SELECT TestAppointmentID 
                  FROM TestAppointments 
                  WHERE LocalDrivingLicenseApplicationID = LDA.LocalDrivingLicenseApplicationID
                  ) and TestResult =1
                 ) AS [Passed Tests],
                 CASE 
                     WHEN App.ApplicationStatus = 1 THEN 'New'
                     WHEN App.ApplicationStatus = 2 THEN 'Cancelled'
                     WHEN App.ApplicationStatus = 3 THEN 'Completed'
                     ELSE 'Unknown'  
                 END AS [Status]
              FROM LocalDrivingLicenseApplications LDA
              INNER JOIN Applications App ON LDA.ApplicationID = App.ApplicationID
              INNER JOIN LicenseClasses LC ON LC.LicenseClassID = LDA.LicenseClassID
              INNER JOIN People Pe ON Pe.PersonID = App.ApplicationPersonID;";
            SqlCommand command = new SqlCommand(Query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                    apps.Load(reader);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return apps;
        }
        public DataTable GetAllLDLApplicationsByPersonID(int PersonID)
        {
            DataTable apps = new DataTable();
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = @"SELECT * FROM Applications App INNER JOIN 
            LocalDrivingLicenseApplications LDLApp ON App.ApplicationID = LDLApp.ApplicationID
            WHERE App.ApplicationPersonID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", PersonID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    apps.Load(reader);
                else apps = null;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return apps;
        }
        private LDLApplication MapLDLApplication(SqlDataReader reader)
        {
            return new LDLApplication((int)reader["LocalDrivingLicenseApplicationID"],
                (int)reader["ApplicationID"], (int)reader["LicenseClassID"]);
        }
        public LDLApplication GetLDLApplication(int LDLappID)
        {
            LDLApplication LDLapp = null;
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@ID",LDLappID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LDLapp = MapLDLApplication(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return LDLapp;
        }
        public LDLApplication GetLDLApplicationByAppID(int AppID)
        {
            LDLApplication LDLApplication = null;
            SqlConnection conn = new SqlConnection(_connectionString );
            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@ID", AppID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LDLApplication = MapLDLApplication(reader) ;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return LDLApplication;
        }
        public bool AddNew(LDLApplication LDLapplication)
        {
            bool added = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
                             VALUES(@AppID,@LicenseClassID)
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@AppID",LDLapplication.ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LDLapplication.LicenseClassID);

            try
            {
                conn.Open();

                object result = command.ExecuteScalar();    
                if(result != null && result != DBNull.Value)
                {
                    LDLapplication.ID = Convert.ToInt32(result);
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
        public bool Delete (int LDLappID)
        {
            bool deleted = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"DELETE FROM LocalDrivingLicenseApplications 
                             WHERE LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID",LDLappID);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery();
                deleted= (affected > 0);    
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
