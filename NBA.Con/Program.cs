using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Web;
using NBA.Scraper;
using NBA.Model;
using NBA.Dal;
using NBA.Dal.DAO;
using NBA.Dal.Interfaces;
using NBA.Biz;
using System.IO;
using static System.Console;


namespace NBA.Con
{
    class Program
    {
        static void Main(string[] args)
        {


            string homeURL = "http://www.espn.com";
            string URLString = "http://www.espn.com/nba/team/roster/_/name/atl/atlanta-hawks";
            string xPath = "//*[@class='dropdown__select']";
            string header = string.Empty;
            string columns = string.Empty;

            bool returnState = false;

            URLScraper us = new URLScraper();

            #region Scrape data for player Roster (Done)

            us.URLString = URLString;
            us.XPath = xPath;
            List<TeamUrl> urls = us.GetURLs();

            WriteLine("Getting player roster ...");

            foreach (TeamUrl url in urls)
            {
                Console.WriteLine("    Getting data for {0} ...", url.TeamName);
                us.TeamName = url.TeamName;
                us.URLString = string.Concat(homeURL, url.TeamURL);
                us.XPath = "//*[@id='fittPageContainer']/div[2]/div[5]/div[1]/div/section/div/section/div[2]/section/div[2]/div/div[2]/table/tbody/tr";
                List<Player> players = us.GetTeamData();
                IPlayer pDAO = new DAOPlayer();
                PlayerBiz pbiz = new PlayerBiz(pDAO);

                returnState = pbiz.InsertPlayersData(players);
            }

            #endregion

            #region NBA Standings (Done)

            URLString = "http://www.espn.com/nba/standings/_/group/league";
            xPath = "//*[@id='fittPageContainer']/div[3]/div[1]/div/section/div/section/div[2]/div/section/div[1]/section/div[2]/table/tbody";
            us.XPath = xPath;
            us.URLString = URLString;

            WriteLine("Getting NBA Standings ...");
            List<NBAStanding> nsList = us.GetNBAStandings();

            INBAStanding nDAO = new DAONBAStanding();
            NBAStandingBiz nBiz = new NBAStandingBiz(nDAO);

            returnState = nBiz.InsertNBAStandings(nsList);

            #endregion

            #region STAT  (Done)

            URLString = "http://www.espn.com/nba/team/stats/_/name/lac";
            xPath = "//*[@class='dropdown__select']";

            us.XPath = xPath;
            us.URLString = URLString;

            List<TeamUrl> urlst = us.GetURLsForStats();

            List<TeamUrl> url30 = urlst.GetRange(0, 29);

            WriteLine("Getting Team Stats ...");

            foreach (TeamUrl url in url30)
            {
                Console.WriteLine("    Getting stats for {0} ...", url.TeamName);

                us.URLString = string.Concat(homeURL, url.TeamURL);
                us.XPath = "//*[@class='flex']";

                List<Stat> stats = us.GetStats(url.TeamName);

                IStat sDAO = new DAOStat();
                StatBiz sbiz = new StatBiz(sDAO);

                returnState = sbiz.InsertStatData(stats);

            }

            #endregion

            #region Depth Chart (Done)

            homeURL = "http://www.espn.com";
            URLString = "http://www.espn.com/nba/team/depth/_/name/lac/la-clippers";


            string team = string.Empty;

            xPath = "//*[@class='dropdown__select']";
            us.XPath = xPath;
            us.URLString = URLString;

            List<TeamUrl> urlt = us.GetURLs();

            xPath = "//*[@id='fittPageContainer']/div[2]/div[5]/div[1]/div/article/div/section/div[2]/div/section/table/tbody/tr/td[2]/div/div/div[2]/table/tbody/tr/td/div/table/tbody";
            us.XPath = xPath;

            WriteLine("Getting Depth Chart ...");

            foreach (TeamUrl url in urlt)
            {
                team = url.TeamName;

                Console.WriteLine("    Creating depth chart for {0}", team);

                us.URLString = string.Concat(homeURL, url.TeamURL);

                List<DepthChart> dcList = us.GetDepthChart(team).ToList();

                IDepthChart cDAO = new DAODepthChart();
                DepthChartBiz cBiz = new DepthChartBiz(cDAO);

                returnState = cBiz.InsertDepthChart(dcList);

            }
            #endregion

            Console.WriteLine("All Done!");

            Console.Read();
        }


    }
}
