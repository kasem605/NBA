using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBA.Dal.Interfaces;
using NBA.Model;
using NBA.Dal.DatabaseFactory;

namespace NBA.Dal.DAO
{
    public class DAODepthChart : DBAbstract, IDepthChart, IParameter<DepthChart>
    {
        public IDbDataParameter[] CreateParameters(DepthChart s)
        {
            IDbDataParameter[] parameters =
            {
                new SqlParameter( "@PlayerName", SqlDbType.NVarChar, 150),
                new SqlParameter( "@teamName", SqlDbType.NVarChar, 150),
                new SqlParameter( "@Position", SqlDbType.NVarChar, 10),
                new SqlParameter( "@Depth", SqlDbType.NVarChar, 10)
            };

            parameters[0].Value = s.PlayerName;
            parameters[1].Value = s.TeamName;
            parameters[2].Value = s.Position;
            parameters[3].Value = s.Depth;
            return parameters;
        }

        public bool InsertDepthChart(List<DepthChart> dCharts)
        {
            List<bool> insertList = null;

            string storeProc = "InsertDepthChart";

            IDbConnection sqlConn = null;
            IDbCommand sqlCmd = null;
            IDbDataParameter[] parameters = null;

            IConnection connection = DBFactory.CreateConnection(DBType.SQL);
            sqlConn = connection.GetConnection();
            sqlConn.Open();

            foreach (DepthChart chart in dCharts)
            {
                try
                {
                    sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = storeProc;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlConn;

                    insertList = new List<bool>();

                    parameters = CreateParameters(chart);

                    foreach (IDbDataParameter d in parameters)
                    {
                        sqlCmd.Parameters.Add(d);
                    }

                    int returnValue = sqlCmd.ExecuteNonQuery();

                    if (returnValue == 1)
                    {
                        insertList.Add(true);
                    }
                    else
                    {
                        insertList.Add(false);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Concat(ex.Message,": From InsertDepthChart method in DAL"));
                }

            }

            return !insertList.Contains(false);
        }
    }
}
