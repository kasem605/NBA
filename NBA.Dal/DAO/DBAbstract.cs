using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NBA.Dal.DAO
{
    public abstract class DBAbstract
    {

        public void CloseAll(SqlCommand sqlCmd, SqlConnection sqlConn)
        {
            if (sqlCmd != null)
                sqlCmd.Dispose();

            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }

        public void CloseAll(IDbCommand sqlCmd, IDbConnection sqlConn)
        {
            if (sqlCmd != null)
                sqlCmd.Dispose();

            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }

        public void CloseAll(SqlDataReader sqlReader, SqlCommand sqlCmd, SqlConnection sqlConn)
        {
            if (!sqlReader.IsClosed)
                sqlReader.Close();

            if (sqlCmd != null)
                sqlCmd.Dispose();

            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
    }
}
