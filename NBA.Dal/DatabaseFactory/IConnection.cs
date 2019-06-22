using System.Data;

namespace NBA.Dal.DatabaseFactory
{
    /// <summary>
    /// Interface for the  Database Factory to create the specific connection (ODBC or SQL)
    /// </summary>
    public interface IConnection
    {
        IDbConnection GetConnection();
    }
}
