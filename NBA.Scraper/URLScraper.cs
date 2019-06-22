using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NBA.Model;
using System.Web;
using NBA.Utility;


namespace NBA.Scraper
{
    public class URLScraper
    {
        public string URLString { get; set; }
        public string XPath { get; set; }
        public string TeamName { get; set; }
        private HtmlDocument doc = null;
        private HtmlWeb web = null;
        private int count = 0;

        public URLScraper()
        {
        }

        public List<TeamUrl> GetURLs()
        {
            List<TeamUrl> urls = new List<TeamUrl>();

            doc = GetDocument(URLString);

            HtmlNode urlNode = doc.DocumentNode.SelectSingleNode(XPath);

            HtmlNodeCollection options = urlNode.SelectNodes("//option");

            foreach(HtmlNode option in options)
            {
                if (!string.IsNullOrWhiteSpace(option.InnerText) && !option.InnerText.Equals("More NBA teams"))
                {
                    TeamUrl tu = new TeamUrl();
                    tu.ID = ++count;
                    tu.TeamName = option.InnerText;
                    tu.TeamURL = option.Attributes["data-url"].Value;
                    tu.Description = option.InnerText;

                    urls.Add(tu);
                }
            }

            return urls;
        }

        private HtmlDocument GetDocument(string url)
        {
            web = new HtmlWeb();
            web.AutoDetectEncoding = false;
            doc = web.Load(URLString);

            return doc;
        }

        public List<Player> GetTeamData()
        {

            doc = GetDocument(URLString);

            List<Player> players = GetPlayers(doc);

            return players;
        }

        private List<Player> GetPlayers(HtmlDocument doc)
        {
            List<Player> pList = new List<Player>();

            HtmlNodeCollection rows = doc.DocumentNode.SelectNodes(XPath);

            foreach (HtmlNode row in rows)
            {
                HtmlDocument hDoc = new HtmlDocument();
                hDoc.LoadHtml(row.InnerHtml);
                HtmlNodeCollection cols = hDoc.DocumentNode.SelectNodes("//td");
                int count = cols.Count;

                Player p = new Player();
                for (int i = 0; i<8; i++)
                {


                    if (i == 1)
                        p.PlayerName = HttpUtility.HtmlDecode(cols[i].InnerText);
                    if (i == 2)
                        p.Pos = HttpUtility.HtmlDecode(cols[i].InnerText);
                    if (i == 3)
                        p.Age = HttpUtility.HtmlDecode(cols[i].InnerText);
                    if (i == 4)
                        p.Height = HttpUtility.HtmlDecode(cols[i].InnerText);
                    if (i == 5)
                        p.Weight = HttpUtility.HtmlDecode(cols[i].InnerText);
                    if (i == 6)
                        p.College = HttpUtility.HtmlDecode(cols[i].InnerText);
                    if (i == 7)
                        p.Salary = HttpUtility.HtmlDecode(cols[i].InnerText);
                    p.TeamName = TeamName;

                }
                pList.Add(p);

            }
            return pList;
        }

        public List<Stat> GetStats(string teamName)
        {
            List<Stat> stats = new List<Stat>();

            doc = GetDocument(URLString);
            HtmlNodeCollection divs = doc.DocumentNode.SelectNodes(XPath);

            for (int i = 0; i < divs.Count; i++)
            {
                HtmlDocument hDoc = new HtmlDocument();
                hDoc.LoadHtml(divs[i].InnerHtml);

                if (i == 0)
                {
                    HtmlNodeCollection rows = hDoc.DocumentNode.SelectNodes("//tr");

                    foreach (HtmlNode row in rows)
                    {
                        HtmlDocument tdDoc = new HtmlDocument();
                        tdDoc.LoadHtml(row.InnerHtml);

                        HtmlNodeCollection cols = tdDoc.DocumentNode.SelectNodes("//td");

                        for (int j = 0; j < cols.Count; j++)
                        {
                            Stat s = new Stat();
                            s.Name = cols[j].InnerText;
                            s.TeamName = teamName;
                            if (s.Name.Contains("*"))
                                s.MidseasonTrades = true;
                            stats.Add(s);
                        }

                    }
                }
                else if (i == 1)
                {
                    HtmlNodeCollection rows = hDoc.DocumentNode.SelectNodes("//tr");

                    for (int u = 0; u < rows.Count; u++)
                    {
                        HtmlDocument tdDoc = new HtmlDocument();
                        tdDoc.LoadHtml(rows[u].InnerHtml);

                        HtmlNodeCollection cols = tdDoc.DocumentNode.SelectNodes("//td");

                            stats[u].GamesPlayed = cols[0].InnerText;            //1
                            stats[u].GamesStarted = cols[1].InnerText;           //2
                            stats[u].MinutesPerGame = cols[2].InnerText;         //3
                            stats[u].PointsPerGame = cols[3].InnerText;          //4
                            stats[u].OffensiveReboundsPerGame = cols[4].InnerText;//5
                            stats[u].DefensiveReboundsPerGame = cols[5].InnerText;//6
                            stats[u].ReboundsPerGame = cols[6].InnerText;        //7
                            stats[u].AssistsPerGame = cols[7].InnerText;         //8
                            stats[u].StealsPerGame = cols[8].InnerText;          //9
                            stats[u].BlocksPerGame = cols[9].InnerText;          //10
                            stats[u].TurnOversPerGame = cols[10].InnerText;      //11
                            stats[u].FoulsPerGame = cols[11].InnerText;          //12
                            stats[u].AssistToTurnoverRatio = cols[12].InnerText; //13
                            stats[u].PlayerEfficiencyRating = cols[13].InnerText;//14

                    }
                }
                else if (i == 3)
                {
                    HtmlNodeCollection rows = hDoc.DocumentNode.SelectNodes("//tr");

                    for (int v = 0; v < rows.Count; v++)
                    {
                        HtmlDocument tdDoc = new HtmlDocument();
                        tdDoc.LoadHtml(rows[v].InnerHtml);

                        HtmlNodeCollection tdNodes = tdDoc.DocumentNode.SelectNodes("//td");

                        stats[v].AverageFieldGoalsMade = tdNodes[0].InnerText;              //1
                        stats[v].AverageFieldGoalsAttempted = tdNodes[1].InnerText;         //2
                        stats[v].FieldGoalPercentage = tdNodes[2].InnerText;                //3
                        stats[v].Average3PointFieldGoalsMade = tdNodes[3].InnerText;        //4
                        stats[v].Average3PointFieldGoalsAttempted = tdNodes[4].InnerText;   //5
                        stats[v].ThreePointFieldGoalPercentage = tdNodes[5].InnerText;      //6
                        stats[v].AverageFreeThrowsMade = tdNodes[6].InnerText;              //7
                        stats[v].AverageFreeThrowsAttempted = tdNodes[7].InnerText;         //8
                        stats[v].FreeThrowPercentage = tdNodes[8].InnerText;                //9
                        stats[v].TwoPointFieldGoalsMadePerGame = tdNodes[9].InnerText;      //10
                        stats[v].TwoPointFieldGoalsAttemptedPerGame = tdNodes[10].InnerText;//11
                        stats[v].TwoPointFieldGoalPercentage = tdNodes[11].InnerText;       //12
                        stats[v].ScoringEfficiency = tdNodes[12].InnerText;                 //13
                        stats[v].ShootingEfficiency = tdNodes[13].InnerText;                //14


                    }
                }
            }

            return stats;
        }

        public List<NBAStanding> GetNBAStandings()
        {
            doc = GetDocument(URLString);

            List<NBAStanding> standings = GetStandings(doc);

            return standings;
        }

        private List<NBAStanding> GetStandings(HtmlDocument doc)
        {
            List<NBAStanding> nsList = new List<NBAStanding>();

            HtmlNode dataNode = doc.DocumentNode.SelectSingleNode(XPath);


            for (int i = 4; i < 30; i++)
            {
                HtmlNodeCollection data = dataNode.SelectNodes(string.Concat("//tr[", i,"]/td"));

                NBAStanding ns = new NBAStanding();

                ns.TeamName = data[0].InnerText;
                ns.W = int.Parse(data[1].InnerText);
                ns.L = int.Parse(data[2].InnerText);
                ns.PCT = double.Parse(data[3].InnerText);
                ns.GB = int.Parse(data[4].InnerText);

                ns.Home = data[5].InnerText;
                ns.HomeWin = Extensions.ExtractWin(ns.Home);
                ns.HomeLoss = Extensions.ExtractLoss(ns.Home);

                ns.Away = data[6].InnerText;
                ns.AwayWin = Extensions.ExtractWin(ns.Away);
                ns.AwayLoss = Extensions.ExtractLoss(ns.Away);

                ns.DIV = data[7].InnerText;
                ns.DIVWin = Extensions.ExtractWin(ns.DIV);
                ns.DIVLoss = Extensions.ExtractLoss(ns.DIV);

                ns.CONF = data[8].InnerText;
                ns.CONFWin = Extensions.ExtractWin(ns.CONF);
                ns.CONFLoss = Extensions.ExtractLoss(ns.CONF);

                ns.PPG = data[9].InnerText;
                ns.OPP_PPG = data[10].InnerText;
                ns.DIFF = data[11].InnerText;
                ns.STRK = data[12].InnerText;
                ns.L10 = data[13].InnerText;

                nsList.Add(ns);

            }

            return nsList;
        }

        public IEnumerable<DepthChart> GetDepthChart(string team)
        {
            List<DepthChart> dcList = new List<DepthChart>();

            HtmlDocument doc = GetDocument(URLString);

            HtmlNodeCollection rows = doc.DocumentNode.SelectNodes(XPath);

            int rowCount = 0;

            foreach (HtmlNode row in rows)
            {
                ++rowCount;

                HtmlDocument hDoc = new HtmlDocument();
                hDoc.LoadHtml(row.InnerHtml);
                HtmlNodeCollection cols = hDoc.DocumentNode.SelectNodes("//td/span");

                int colCount = 0;
                foreach (HtmlNode col in cols)
                {
                    ++colCount;

                    if (!col.InnerText.Contains("- ") && !string.IsNullOrEmpty(col.InnerText))
                    {
                        DepthChart dc = new DepthChart();
                        dc.PlayerName = col.InnerText;
                        dc.TeamName = team;
                        dc.Position = GetPosition(rowCount);
                        dc.Depth = GetDepth(colCount);

                        dcList.Add(dc);
                    }
                }
            }

            return dcList;
        }

        private string GetDepth(int col)
        {
            string depth = string.Empty;

            switch (col)
            {
                case 1:
                    depth = "Starter";
                    break;
                case 2:
                    depth = "2nd";
                    break;
                case 3:
                    depth = "3rd";
                    break;
                case 4:
                    depth = "4th";
                    break;
                case 5:
                    depth = "5th";
                    break;

            }

            return depth;
        }

        private string GetPosition(int row)
        {
            string position = string.Empty;

            switch (row)
            {
                case 1:
                    position = "PG";
                    break;
                case 2:
                    position = "SG";
                    break;
                case 3:
                    position = "SF";
                    break;
                case 4:
                    position = "PF";
                    break;
                case 5:
                    position = "C";
                    break;

            }

            return position;
        }
    }
}
