using NBA.Dal.Interfaces;
using NBA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NBA.Dal.DatabaseFactory;

namespace NBA.Dal.DAO
{
    public class DAONBAStanding : DBAbstract, INBAStanding
    {
        public bool InsertNBAStandings(IEnumerable<NBAStanding> standings)
        {
            string storeProc = "sp_InsertNBAStanding";
            List<bool> insertList = null;

            IDbConnection sqlConn = null;
            IDbCommand sqlCmd = null;
            IDbDataParameter[] parameters = null;

            try
            {
                IConnection connection = DBFactory.CreateConnection(DBType.SQL);
                sqlConn = connection.GetConnection();
                sqlConn.Open();

                insertList = new List<bool>();

                foreach (NBAStanding s in standings)
                {

                    sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = storeProc;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlConn;

                    parameters = CreateParameters(s);

                    foreach(IDbDataParameter parameter in parameters)
                    {
                        sqlCmd.Parameters.Add(parameter);
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseAll(sqlCmd, sqlConn);
            }

            if (!insertList.Contains(false))
                return true;
            else
                return false;

        }

        private static IDbDataParameter[] CreateParameters(NBAStanding s)
        {
            IDbDataParameter[] parameters =
                                {
                        new SqlParameter("@TeamName", SqlDbType.NVarChar, 150),
                        new SqlParameter("@W", SqlDbType.Int, 4),
                        new SqlParameter("@L", SqlDbType.Int, 4),
                        new SqlParameter("@PCT", SqlDbType.Float),
                        new SqlParameter("@GB", SqlDbType.Int, 4),
                        new SqlParameter("@HomeWin", SqlDbType.NChar, 10),
                        new SqlParameter("@HomeLoss", SqlDbType.NChar, 10),
                        new SqlParameter("@AwayWin", SqlDbType.NChar, 10),
                        new SqlParameter("@AwayLoss", SqlDbType.NChar, 10),
                        new SqlParameter("@DIVWin", SqlDbType.NChar, 10),
                        new SqlParameter("@DIVLoss", SqlDbType.NChar, 10),
                        new SqlParameter("@CONFWin", SqlDbType.NChar, 10),
                        new SqlParameter("@CONFLoss", SqlDbType.NChar, 10),
                        new SqlParameter("@PPG", SqlDbType.NChar, 10),
                        new SqlParameter("@OPP_PPG", SqlDbType.NChar, 10),
                        new SqlParameter("@DIFF", SqlDbType.NChar, 10),
                        new SqlParameter("@STRK", SqlDbType.NChar, 10),
                        new SqlParameter("@L10", SqlDbType.NChar, 10)
                    };

            parameters[0].Value = s.TeamName;
            parameters[1].Value = s.W;
            parameters[2].Value = s.L;
            parameters[3].Value = s.PCT;
            parameters[4].Value = s.GB;
            parameters[5].Value = s.HomeWin;
            parameters[6].Value = s.HomeLoss;
            parameters[7].Value = s.AwayWin;
            parameters[8].Value = s.AwayLoss;
            parameters[9].Value = s.DIVWin;
            parameters[10].Value = s.DIVLoss;
            parameters[11].Value = s.CONFWin;
            parameters[12].Value = s.CONFLoss;
            parameters[13].Value = s.PPG;
            parameters[14].Value = s.OPP_PPG;
            parameters[15].Value = s.DIFF;
            parameters[16].Value = s.STRK;
            parameters[17].Value = s.L10;

            return parameters;
        }
    }

}

