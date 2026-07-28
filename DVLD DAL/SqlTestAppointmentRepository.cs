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
    public class SqlTestAppointmentRepository : ITestAppointmentRepository
    {

        private readonly string _connectionString;
        public SqlTestAppointmentRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }

        public DataTable GetAllTestAppointmentsByAppID(int LDLAppID)
        {
            DataTable testAppointments = new DataTable();
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = @"SELECT TA.* FROM TestAppointments TA INNER JOIN
LocalDrivingLicenseApplications LDLApp ON 
TA.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID
INNER JOIN Applications App ON LDLApp.ApplicationID = App.ApplicationID
WHERE LDLApp.LocalDrivingLicenseApplicationID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID",LDLAppID);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    testAppointments.Load(reader);
                else testAppointments = null;
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return testAppointments;
        }
        public TestAppointment GetTestAppointment(int testAppointmentID)
        {
            TestAppointment testAppointment = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID",testAppointmentID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    testAppointment = MapTestAppointment(reader);
                }
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return testAppointment;
        }
        private TestAppointment MapTestAppointment(SqlDataReader reader)
        {
            return new TestAppointment((int)reader["TestAppointmentID"], (int)reader["TestTypeID"],
                (int)reader["LocalDrivingLicenseApplicationID"], Convert.ToDateTime(reader["AppointmentDate"]),
                Convert.ToDouble(reader["PaidFees"]), (int)reader["CreatedByUserID"], (bool)reader["IsLocked"]);
        }
        public bool AddNew(TestAppointment testAppointment)
        {
            bool added = false;
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = @"INSERT INTO TestAppointments
(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked)
VALUES(@TestTypeID,@LDLAppID,@AppointmentDate,@PaidFees,@CreatedByUserID,@IsLocked)
SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@TestTypeID",testAppointment.TestTypeID);
            command.Parameters.AddWithValue("@LDLAppID", testAppointment.LDLApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", testAppointment.AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees",testAppointment.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID",testAppointment.CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked",testAppointment.isLocked);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                if (int.TryParse(result?.ToString(), out int InsertedID)){
                    testAppointment.TestAppointmentID = InsertedID;
                    added = true;
                }
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return added;
        }
        public bool Delete(int testAppointmentID)
        {
            bool deleted = false;
            SqlConnection conn = new SqlConnection(_connectionString );
            string Query = "DELETE FROM TestAppointments WHERE TestAppointmentsID = @ID";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@ID", testAppointmentID);

            try
            {
                conn.Open();
                int affectedRows = command.ExecuteNonQuery();
                deleted = (affectedRows > 0);
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return deleted;
        }
        public bool Update(TestAppointment testAppointment)
        {
            bool updated = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"UPDATE TestAppointments SET TestTypeID = @TestTypeID,
LocalDrivingLicenseApplicationID = @LDLAppID, AppointmentDate = @AppointmentDate,
PaidFees = @PaidFees, CreatedByUserID = @CreatedByUserID, IsLocked = @IsLocked
WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@TestAppointmentID",testAppointment.TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID",testAppointment.TestTypeID);
            command.Parameters.AddWithValue("@LDLAppID", testAppointment.LDLApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", testAppointment.AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees",testAppointment.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID",testAppointment.CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", testAppointment.isLocked);

            try
            {
                conn.Open();
                int affectedRows = command.ExecuteNonQuery();
                updated = (affectedRows > 0);
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally{ conn.Close(); }
            return updated;
        }
    }
}
