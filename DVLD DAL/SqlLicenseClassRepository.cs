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
    public class SqlLicenseClassRepository : ILicenseClassRepository
    {
        private readonly string _connectionString;
        public SqlLicenseClassRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }

        public DataTable GetAllLicenseClasses()
        {
            DataTable LicenseClasses = new DataTable();
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM LicenseClasses";
            SqlCommand command = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                    LicenseClasses.Load(reader);
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return LicenseClasses;
        }
        private LicenseClass MapClass(SqlDataReader reader)
        {
            return new LicenseClass((int)reader["LicenseClassID"], reader["ClassName"] as string,
                reader["ClassDescription"] as string, Convert.ToInt32(reader["MinimumAllowedAge"]),
                Convert.ToInt32(reader["DefaultValidityLength"]),Convert.ToDouble(reader["ClassFees"]));
        }
        public LicenseClass GetLicenseClass(int licenseClassId)
        {
            LicenseClass licenseClass = null;
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @ID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@ID", licenseClassId);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    licenseClass = MapClass(reader);
                }
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return licenseClass;
        }
    }
}
