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
                        new SqlParameter("@Height", SqlDbType.NVarChar, 10),
                        new SqlParameter("@College", SqlDbType.NVarChar, 250),
                        new SqlParameter("@Salary", SqlDbType.Decimal, 18),
                        new SqlParameter("@TeamName", SqlDbType.NVarChar, 250)
                    };

            parameters[0].Value = s.FName.CheckNULLS();
            parameters[1].Value = s.MName.CheckNULLS();
            parameters[2].Value = s.LName.CheckNULLS();
            parameters[3].Value = s.JerseyNumber.CheckNULLS();
            parameters[4].Value = s.Pos.CheckNULLS();
            parameters[5].Value = s.Age.ToString().CheckIntegerNULLS();
            parameters[6].Value = s.Weight.CheckIntegerNULLS();
            parameters[7].Value = s.Height.CheckNULLS();
            parameters[8].Value = s.College.CheckNULLS();
            parameters[9].Value = s.Salary.CheckNULLS();
            parameters[10].Value = s.TeamName.CheckNULLS();

            return parameters;
        }

        public bool InsertPlayersData(List<Player> players)
        {
            bool returnState = false;
            string storeProc = "sp_InsertPlayer";
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
