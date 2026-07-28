using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_DAL
{
    public class SqlCountryRepository : ICountryRepository
    {
        private  string _connectionString;
        public SqlCountryRepository()
        {
            _connectionString = DataSettings.ConnectionString;
        }
        public  DataTable GetAllCountries()
        {
            DataTable Countries = new DataTable();  
            SqlConnection conn = new SqlConnection( _connectionString );
            string Query = "SELECT * FROM Countries";
            SqlCommand command = new SqlCommand(Query,conn);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                    Countries.Load(reader); 
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return Countries;
        }
        public  Country GetCountry(string name)
        {
            Country country = new Country();
            SqlConnection conn = new SqlConnection(_connectionString);  
            string Query = "SELECT * FROM Countries WHERE CountryName = @name";
            SqlCommand command = new SqlCommand(Query,conn);
            command.Parameters.AddWithValue("@name", name);
            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    country.ID = (int)reader["CountryID"];
                    country.Name  = reader["CountryName"] as string;
                }
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return country;
        }
        public  Country GetCountry(int id)
        {
            Country country = new Country();
            SqlConnection conn = new SqlConnection(_connectionString);   
            string Query = "SELECT * FROM Countries WHERE CountryID = @id";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    country.ID = (int)reader["CountryID"];
                    country.Name = reader["CountryName"] as string;
                }
            }
            catch (Exception ex)
            {
                Core.LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
            finally { conn.Close(); }
            return country;
        }
        }
}
