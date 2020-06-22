using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBA.Model;
using NBA.Dal.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using NBA.Dal.DatabaseFactory;

namespace NBA.Dal.DAO
{
    public class DAOStat : DBAbstract, IStat, IParameter<Stat>
    {
        public IDbDataParameter[] CreateParameters(Stat s)
        {
            IDbDataParameter[] paremeters =
            {
                        new SqlParameter("@Name", SqlDbType.VarChar, 50),
                        new SqlParameter("@TeamName", SqlDbType.VarChar,150),
                        new SqlParameter("@MidseasonTrades", SqlDbType.Bit),
                        new SqlParameter("@GamesPlayed", SqlDbType.VarChar),
                        new SqlParameter("@GamesStarted", SqlDbType.VarChar),
                        new SqlParameter("@MinutesperGame", SqlDbType.VarChar),
                        new SqlParameter("@PointsperGame", SqlDbType.VarChar),
                        new SqlParameter("@OffensiveReboundsPerGame", SqlDbType.VarChar),
                        new SqlParameter("@DefensiveReboundsPerGame", SqlDbType.VarChar),
                        new SqlParameter("@ReboundsPerGame", SqlDbType.VarChar),
                        new SqlParameter("@AssistsPerGame", SqlDbType.VarChar),
                        new SqlParameter("@StealsPerGame", SqlDbType.VarChar),
                        new SqlParameter("@BlocksPerGame", SqlDbType.VarChar),
                        new SqlParameter("@TurnOversPerGame", SqlDbType.VarChar),
                        new SqlParameter("@FoulsPerGame", SqlDbType.VarChar),
                        new SqlParameter("@PlayerEfficiencyRating", SqlDbType.VarChar),
                        new SqlParameter("@AverageFieldGoalsMade", SqlDbType.VarChar),
                        new SqlParameter("@AverageFieldGoalsAttempted", SqlDbType.VarChar),
                        new SqlParameter("@AverageFreeThrowsAttempted", SqlDbType.VarChar),
                        new SqlParameter("@FieldGoalPercentage", SqlDbType.VarChar),
                        new SqlParameter("@Average3PointFieldGoalsMade", SqlDbType.VarChar),
                        new SqlParameter("@Average3PointFieldGoalsAttempted", SqlDbType.VarChar),
                        new SqlParameter("@ThreePointFieldGoalPercentage", SqlDbType.VarChar),
                        new SqlParameter("@AverageFreeThrowsMade", SqlDbType.VarChar),
                        new SqlParameter("@FreeThrowPercentage", SqlDbType.VarChar),
                        new SqlParameter("@TwoPointFieldGoalsMadePerGame", SqlDbType.VarChar),
                        new SqlParameter("@TwoPointFieldGoalsAttemptedPerGame", SqlDbType.VarChar),
                        new SqlParameter("@TwoPointFieldGoalPercentage", SqlDbType.VarChar),
                        new SqlParameter("@ScoringEfficiency", SqlDbType.VarChar),
                        new SqlParameter("@ShootingEfficiency", SqlDbType.VarChar)
            };

            paremeters[0].Value = s.Name;
            paremeters[1].Value = s.TeamName;
            paremeters[2].Value = s.MidseasonTrades;
            paremeters[3].Value = s.GamesPlayed;
            paremeters[4].Value = s.GamesStarted;
            paremeters[5].Value = s.MinutesPerGame;
            paremeters[6].Value = s.PointsPerGame;
            paremeters[7].Value = s.OffensiveReboundsPerGame;
            paremeters[8].Value = s.DefensiveReboundsPerGame;
            paremeters[9].Value = s.ReboundsPerGame;
            paremeters[10].Value = s.AssistsPerGame;
            paremeters[11].Value = s.StealsPerGame;
            paremeters[12].Value = s.BlocksPerGame;
            paremeters[13].Value = s.TurnOversPerGame;
            paremeters[14].Value = s.FoulsPerGame;
            paremeters[15].Value = s.PlayerEfficiencyRating;
            paremeters[16].Value = s.AverageFieldGoalsMade;
            paremeters[17].Value = s.AverageFieldGoalsAttempted;
            paremeters[18].Value = s.AverageFreeThrowsAttempted;
            paremeters[19].Value = s.FieldGoalPercentage;
            paremeters[20].Value = s.Average3PointFieldGoalsMade;
            paremeters[21].Value = s.Average3PointFieldGoalsAttempted;
            paremeters[22].Value = s.ThreePointFieldGoalPercentage;
            paremeters[23].Value = s.AverageFreeThrowsMade;
            paremeters[24].Value = s.FreeThrowPercentage;
            paremeters[25].Value = s.TwoPointFieldGoalsMadePerGame;
            paremeters[26].Value = s.TwoPointFieldGoalsAttemptedPerGame;
            paremeters[27].Value = s.TwoPointFieldGoalPercentage;
            paremeters[28].Value = s.ScoringEfficiency;
            paremeters[29].Value = s.ShootingEfficiency;

            return paremeters;
        }

        public bool InsertStatData(List<Stat> stats)
        {
            string storeProc = "sp_InsertStat";
            List<bool> insertList = null;

            IDbConnection sqlConn = null;
            IDbCommand sqlCmd = null;
            IDbDataParameter[] parameters = null;

            IConnection connection = DBFactory.CreateConnection(DBType.SQL);
            sqlConn = connection.GetConnection();
            sqlConn.Open();

            insertList = new List<bool>();

            foreach (Stat s in stats)
            {
                try
                {
                    sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = storeProc;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlConn;

                    parameters = CreateParameters(s);

                    foreach (IDbDataParameter p in parameters)
                    {
                        sqlCmd.Parameters.Add(p);
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
                    throw new Exception(ex.Message);
                }

            }

            return !insertList.Contains(false);
        }
    }
}
