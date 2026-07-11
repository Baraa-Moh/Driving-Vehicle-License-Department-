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
    public class SqlTestRepository : ITestRepository
    {
        private readonly string _connectionString;
        public SqlTestRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }

        public DataTable GetAllTestsByLDLAppID(int LDLappID)
        {
            DataTable tests = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"SELECT Tests.* FROM Tests 
INNER JOIN TestAppointments App ON Tests.TestAppointmentID = App.TestAppointmentID
WHERE App.LocalDrivingLicenseApplicationID = @LDLAppID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@LDLAppID", LDLappID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    tests.Load(reader);
                else tests = null;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return tests;
        }
        public Test GetTestByID(int testID)
        {
            Test test = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM Tests WHERE TestID = @ID";
            SqlCommand command = new SqlCommand(Query,conn);    
            command.Parameters.AddWithValue("@ID",testID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    test = MapTest(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return test;
        }
        public Test GetTestByAppointmentID(int testAppointmentID)
        {
            Test test = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query ="SELECT * FROM Tests WHERE TestAppointmentID = @AppointmentID";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@AppointmentID",testAppointmentID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    test = MapTest(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return test;
        }
        private Test MapTest(SqlDataReader reader)
        {
            return new Test((int)reader["TestID"], (int)reader["TestAppointmentID"],
                (bool)reader["TestResult"], reader["Notes"] as string, (int)reader["CreatedByUserID"]);
        }
        public bool AddNew(Test test)
        {
            bool added = false; 
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"INSERT INTO Tests (TestAppointmentID,TestResult,Notes,CreatedByUserID)
VALUES(@AppointmentID,@TestResult,@Notes,@CreatedByUserID)
SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query,conn);    
            command.Parameters.AddWithValue("@AppointmentID",test.TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult",test.TestResult);
            command.Parameters.AddWithValue("@Notes",test.Notes);   
            command.Parameters.AddWithValue("@CreatedByUserID",test.CreatedByUserID);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                if(int.TryParse(result?.ToString(),out int InsertedID)){
                    test.TestID = InsertedID;
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
        public bool Delete(int testID)
        {
            bool deleted = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "DELETE FROM Tests WHERE TestID = @ID";
            SqlCommand command = new SqlCommand(Query,conn);    
            command.Parameters.AddWithValue("@ID",testID);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery();
                deleted = (affected == 1);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return deleted;
        }
        public bool Update(Test test)
        {
            bool updated = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"UPDATE Tests SET TestAppointmentID = @TestAppointmentID,
TestResult = @TestResult, Notes = @Notes, CreatedByUserID = @CreatedByUserID
WHERE TestID = @ID";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@ID", test.TestID);
            command.Parameters.AddWithValue("@TestAppointmentID",test.TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", test.TestResult);
            command.Parameters.AddWithValue("@Notes",test.Notes);
            command.Parameters.AddWithValue("CreatedByUserID",test.CreatedByUserID);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery();
                updated = (affected == 1);
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
