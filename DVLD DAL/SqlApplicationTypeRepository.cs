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
    public class SqlApplicationTypeRepository : IApplicationTypeRepository
    {
        private readonly string _connectionString;
        public SqlApplicationTypeRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }

        public DataTable GetAllTypes()
        {
            DataTable ApplicationTypes = new DataTable();   
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = "SELECT * FROM ApplicationTypes";
            SqlCommand command = new SqlCommand( Query, conn );

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    ApplicationTypes.Load(reader);
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return ApplicationTypes;
        }
        public ApplicationType GetApplicationType(int id)
        {
            ApplicationType appType = null;
            SqlConnection conn = new SqlConnection(_connectionString );
            string Query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ID";
            SqlCommand command = new SqlCommand( Query, conn );
            command.Parameters.AddWithValue("@ID", id);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    appType = MapApplicationType(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return appType; 
        }
        private ApplicationType MapApplicationType(SqlDataReader reader)
        {
            return new ApplicationType((int)reader["ApplicationTypeID"],
                reader["ApplicationTypeTitle"] as string, Convert.ToDouble(reader["ApplicationFees"]));
        }
        public bool Update(ApplicationType appType)
        {
            bool updated = false;
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = @"Update ApplicationTypes SET ApplicationTypeTitle = @Title,
                           ApplicationFees = @Fees WHERE ApplicationTypeID = @ID";
            SqlCommand command = new SqlCommand(Query, conn );
            command.Parameters.AddWithValue("@ID", appType.ID);
            command.Parameters.AddWithValue("@Title", appType.Title);
            command.Parameters.AddWithValue("@Fees",appType.Fees);

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
    }
}
