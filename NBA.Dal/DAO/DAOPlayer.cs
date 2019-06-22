using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBA.Model;
using NBA.Dal.Interfaces;
using System.Data.SqlClient;
using System.Data;
using NBA.Utility;
using Newtonsoft.Json;
using NBA.Dal.DatabaseFactory;

namespace NBA.Dal.DAO
{
    public class DAOPlayer : DBAbstract, IPlayer, IParameter<Player>
    {
        public IDbDataParameter[] CreateParameters(Player s)
        {
            IDbDataParameter[] parameters = {
                        new SqlParameter("@playerFName", SqlDbType.NVarChar, 100),
                        new SqlParameter("@playerMName", SqlDbType.NVarChar, 100), // player.MName;
                        new SqlParameter("@playerLName", SqlDbType.NVarChar, 100),
                        new SqlParameter("@jerseyNumber", SqlDbType.VarChar, 20),
                        new SqlParameter("@Position", SqlDbType.NChar, 2),
                        new SqlParameter("@Age", SqlDbType.Int, 8),
                        new SqlParameter("@Weight", SqlDbType.Int, 8),
                        new SqlParameter("@Height", SqlDbType.VarChar, 10),
                        new SqlParameter("@College", SqlDbType.VarChar, 250),
                        new SqlParameter("@Salary", SqlDbType.Decimal, 18),
                        new SqlParameter("@TeamName", SqlDbType.VarChar, 250)
                    };

            parameters[0].Value = s.FName;
            parameters[1].Value = Extensions.CheckNULLS(s.MName);
            parameters[2].Value = s.LName;
            parameters[3].Value = s.JerseyNumber;
            parameters[4].Value = s.Pos;
            parameters[5].Value = Int32.Parse(s.Age);
            parameters[6].Value = Int32.Parse(s.Weight);
            parameters[7].Value = s.Height;
            parameters[8].Value = s.College;
            parameters[9].Value = s.Salary;
            parameters[10].Value = s.TeamName;

            return parameters;
        }

        public bool InsertPlayersData(List<Player> players)
        {
            bool returnState = false;
            string storeProc = "InsertPlayer";
            IDbConnection sqlConn = null;
            IDbCommand sqlCmd = null;
            IDbDataParameter[] parameters = null;

            IConnection connection = DBFactory.CreateConnection(DBType.SQL);
            sqlConn = connection.GetConnection();
            sqlConn.Open();

            foreach (Player player in players)
            {
                try
                {
                    sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = storeProc;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlConn;

                    parameters = CreateParameters(player);

                    foreach(IDbDataParameter p in parameters)
                    {
                        sqlCmd.Parameters.Add(p);
                    }

                    int returnValue = sqlCmd.ExecuteNonQuery();

                    if(returnValue == 1)
                    {
                        returnState = true;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

            return returnState;
        }
    }
}
