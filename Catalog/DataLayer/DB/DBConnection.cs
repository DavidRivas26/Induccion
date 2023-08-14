using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer.DB
{
    public class DBConnection
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
        public SqlConnection getConnection()
        {
            try
            {
                if(connection != null && connection.State == ConnectionState.Closed)
                    connection.Open();
                
            }
            catch (Exception ex)
            {

            }

            return connection;
        }
        public void closeConnection()
        {
            if (connection != null)
                connection.Close();
        }
    }
}
