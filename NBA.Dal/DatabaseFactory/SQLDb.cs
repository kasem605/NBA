using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NBA.Dal.DatabaseFactory
{
    public class SQLDb : IConnection
    {
        string connectionString = ConfigurationManager.AppSettings["SQLConnect"];

        public IDbConnection GetConnection()
        {
            IDbConnection sqlConn = null;

            if(null == sqlConn)
            {
                sqlConn = new SqlConnection(connectionString);
            }

            return sqlConn;
        }
    }
}
