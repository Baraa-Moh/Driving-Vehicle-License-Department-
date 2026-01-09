using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DVLD_DAL
{
    public class SqlTestTypeRepository : ITestTypeRepository
    {
        private readonly string _connectionString;
        public SqlTestTypeRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }
        public DataTable GetAllTestTypes()
        {
            DataTable testTypes = new DataTable();
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = "SELECT * FROM TestTypes";
            SqlCommand command = new SqlCommand( Query, conn );

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    testTypes.Load(reader);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return testTypes;
        }
        public TestType GetTestType(int TestTypeID)
        {
            TestType testType = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @ID";
            SqlCommand command = new SqlCommand(Query, conn );
            command.Parameters.AddWithValue("@ID", TestTypeID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    testType = MapTestType(reader);
                }
            }
            catch (Exception)
            {

                throw;
            } finally { conn.Close(); }
            return testType;
        }
        public TestType MapTestType(SqlDataReader reader)
        {
            return new TestType((int)reader["TestTypeID"], reader["TestTypeTitle"] as string,
                reader["TestTypeDescription"] as string,Convert.ToDouble(reader["TestTypeFees"]));
        }
        public bool Update (TestType testType)
        {
            bool updated = false;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = @"Update TestTypes SET TestTypeTitle = @Title, TestTypeDescription = @Description,
                            TestTypeFees = @Fees WHERE TestTypeID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", testType.ID);
            command.Parameters.AddWithValue("@Title",testType.Title);
            command.Parameters.AddWithValue("@Description",testType.Description);
            command.Parameters.AddWithValue("@Fees", testType.Fees);

            try
            {
                conn.Open();
                int affected = command.ExecuteNonQuery();
                updated = affected > 0;
            }
            catch (Exception)
            {

                throw;
            } finally{ conn.Close(); }
            return updated;
        }
    }
}
