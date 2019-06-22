using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBA.Model;
using NBA.Dal.Interfaces;

namespace NBA.Biz
{
    public class PlayerBiz : IPlayerBiz
    {
        private IPlayer iPlayer;

        public PlayerBiz(IPlayer iPlayer)
        {
            this.iPlayer = iPlayer;
        }

        public bool InsertPlayersData(List<Player> players)
        {
            bool returnState = false;
            List<Player> pList = null;
            try
            {
                pList = new List<Player>();

                foreach(Player player in players)
                {
                    string[] strArr = BusinessRulesExtensions.ExtractNames(player.PlayerName);

                    Player p = new Player();

                    p.FName = strArr[0];
                    p.MName = strArr[1];
                    p.LName = strArr[2];
                    p.JerseyNumber  = strArr[3];
                    p.Pos = player.Pos;
                    p.Age = BusinessRulesExtensions.NumericCheck(player.Age);
                    p.Height = player.Height;
                    p.Weight = BusinessRulesExtensions.RemoveLBs(player.Weight);
                    p.College = player.College;
                    p.Salary = BusinessRulesExtensions.RemoveCurrencySigns(player.Salary,"$,-");
                    p.TeamName = player.TeamName;

                    pList.Add(p);
                }

                returnState = iPlayer.InsertPlayersData(pList);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.StackTrace + "\nFrom BIZ Layer" );
            }

            return returnState;
        }
    }
}
