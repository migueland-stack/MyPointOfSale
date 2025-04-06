using System.Configuration;
using System.Data.SqlClient;

namespace MyPointOfSale.DataAccessSQLServer
{
    public abstract class ConnectionToSql
    {
        private readonly string _connectionString;

        protected ConnectionToSql()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        }

        protected SqlConnection SqlConnection => new SqlConnection(_connectionString);
    }
}
