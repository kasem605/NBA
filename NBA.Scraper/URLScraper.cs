using HtmlAgilityPack;
using NBA.Model;
using NBA.Utility;
using System.Collections.Generic;
using System.Web;


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

        /// <summary>
        /// Creates an URL list of the existing teams in the NBA by acrpping the URL's from the drop down on a team's web page
        /// </summary>
        /// <returns></returns>
        public List<TeamUrl> GetURLs()
        {
            List<TeamUrl> urls = new List<TeamUrl>();

            doc = GetDocument(URLString);

            HtmlNode urlNode = doc.DocumentNode.SelectSingleNode(XPath);

            HtmlNodeCollection options = urlNode.SelectNodes("//option");

            foreach(HtmlNode option in options)
            {
                if (!string.IsNullOrWhiteSpace(option.InnerText) && !option.InnerText.ToUpper().Equals("MORE NBA TEAMS"))
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

        /// <summary>
        /// creates a list of the team URLs prepending the associated url path
        /// </summary>
        /// <returns>generic list of teamURL</returns>
        public List<TeamUrl> GetURLsForStats()
        {
            string rootURL = @"/nba/team/stats/_/name/";

            List<TeamUrl> urls = new List<TeamUrl>();

            doc = GetDocument(URLString);

            HtmlNode urlNode = doc.DocumentNode.SelectSingleNode(XPath);

            HtmlNodeCollection options = urlNode.SelectNodes("//option");

            foreach (HtmlNode option in options)
            {
                if (!string.IsNullOrWhiteSpace(option.InnerText) && !option.InnerText.ToUpper().Equals("MORE NBA TEAMS"))
                {
                    TeamUrl tu = new TeamUrl();
                    tu.ID = ++count;
                    tu.TeamName = option.InnerText;
                    tu.TeamURL = string.Concat(rootURL,option.Attributes["data-param-value"].Value.ToString());
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

            this.XPath = "//*[@id='fittPageContainer']/div[2]/div[5]/div[1]/div/section/div/section[1]/div[2]/table";
            HtmlNode  playerTable = doc.DocumentNode.SelectSingleNode(XPath);

            HtmlDocument playerDoc = new HtmlDocument();
            playerDoc.LoadHtml(playerTable.InnerHtml);

            HtmlNodeCollection trRows = playerDoc.DocumentNode.SelectNodes("//tr/td");

            for (int i = 0; i < trRows.Count; i++)
            {
                if (!trRows[i].InnerText.ToLower().Equals("total"))
                {
                    Stat s = new Stat();
                    s.Name = trRows[i].InnerText;
                    s.TeamName = teamName;
                    if (s.Name.Contains("*"))
                        s.MidseasonTrades = true;
                    stats.Add(s);
                }
            }


            XPath = "//*[@id='fittPageContainer']/div[2]/div[5]/div[1]/div/section/div/section[1]/div[2]/div/div[2]/table";
            HtmlNode playerTable2 = doc.DocumentNode.SelectSingleNode(XPath);

            HtmlDocument playerDoc2 = new HtmlDocument();
            playerDoc2.LoadHtml(playerTable2.InnerHtml);

            HtmlNodeCollection trRows2 = playerDoc2.DocumentNode.SelectNodes("//tr");

            int j = 0;


            for (int i = 0; i < trRows2.Count-1;i++)
            {
                HtmlDocument playerDoc3 = new HtmlDocument();
                playerDoc3.LoadHtml(trRows2[i].InnerHtml);

                HtmlNodeCollection tdRows = playerDoc3.DocumentNode.SelectNodes("//td");

                if (tdRows != null)
                {
                    stats[j].GamesPlayed = tdRows[0].InnerText;            //1
                    stats[j].GamesStarted = tdRows[1].InnerText;           //2
                    stats[j].MinutesPerGame = tdRows[2].InnerText;         //3
                    stats[j].PointsPerGame = tdRows[3].InnerText;          //4
                    stats[j].OffensiveReboundsPerGame = tdRows[4].InnerText;//5
                    stats[j].DefensiveReboundsPerGame = tdRows[5].InnerText;//6
                    stats[j].ReboundsPerGame = tdRows[6].InnerText;        //7
                    stats[j].AssistsPerGame = tdRows[7].InnerText;         //8
                    stats[j].StealsPerGame = tdRows[8].InnerText;          //9
                    stats[j].BlocksPerGame = tdRows[9].InnerText;          //10
                    stats[j].TurnOversPerGame = tdRows[10].InnerText;      //11
                    stats[j].FoulsPerGame = tdRows[11].InnerText;          //12
                    stats[j].AssistToTurnoverRatio = tdRows[12].InnerText; //13
                    stats[j].PlayerEfficiencyRating = tdRows[13].InnerText;//14
                    j++;
                }

            }


            XPath = "//*[@id='fittPageContainer']/div[2]/div[5]/div[1]/div/section/div/section[2]/div[2]/div/div[2]/table/tbody";
            HtmlNode playerTable3 = doc.DocumentNode.SelectSingleNode(XPath);

            HtmlDocument playerDoc4 = new HtmlDocument();
            playerDoc4.LoadHtml(playerTable3.InnerHtml);

            HtmlNodeCollection trRows3 = playerDoc4.DocumentNode.SelectNodes("//tr");

            int u = 0;

            for (int v = 0; v < trRows3.Count-1; v++)
            {
                HtmlDocument tdDoc = new HtmlDocument();
                tdDoc.LoadHtml(trRows3[v].InnerHtml);

                HtmlNodeCollection tdNodes = tdDoc.DocumentNode.SelectNodes("//td");
                if (tdNodes != null)
                {
                    stats[u].AverageFieldGoalsMade = tdNodes[0].InnerText;              //1
                    stats[u].AverageFieldGoalsAttempted = tdNodes[1].InnerText;         //2
                    stats[u].FieldGoalPercentage = tdNodes[2].InnerText;                //3
                    stats[u].Average3PointFieldGoalsMade = tdNodes[3].InnerText;        //4
                    stats[u].Average3PointFieldGoalsAttempted = tdNodes[4].InnerText;   //5
                    stats[u].ThreePointFieldGoalPercentage = tdNodes[5].InnerText;      //6
                    stats[u].AverageFreeThrowsMade = tdNodes[6].InnerText;              //7
                    stats[u].AverageFreeThrowsAttempted = tdNodes[7].InnerText;         //8
                    stats[u].FreeThrowPercentage = tdNodes[8].InnerText;                //9
                    stats[u].TwoPointFieldGoalsMadePerGame = tdNodes[9].InnerText;      //10
                    stats[u].TwoPointFieldGoalsAttemptedPerGame = tdNodes[10].InnerText;//11
                    stats[u].TwoPointFieldGoalPercentage = tdNodes[11].InnerText;       //12
                    stats[u].ScoringEfficiency = tdNodes[12].InnerText;                 //13
                    stats[u].ShootingEfficiency = tdNodes[13].InnerText;                //14

                    u++;
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


            for (int i = 1; i <= 30; i++)
            {
                HtmlNodeCollection data = dataNode.SelectNodes(string.Concat("//tr[", i,"]/td"));

                NBAStanding ns = new NBAStanding();

                ns.TeamName = data[0].InnerText;
                ns.W = data[1].InnerText.CheckIntegerNULLS();
                ns.L = data[2].InnerText.CheckIntegerNULLS();
                ns.PCT = data[3].InnerText.CheckDoubleNULLS();
                ns.GB = data[4].InnerText.CheckFloatNULLS();

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

            this.XPath = "//*[@id='fittPageContainer']/div[2]/div[5]/div[1]/div/section/div/section/div[2]/div[1]/section/div[2]/table";
            HtmlNode dcTable = doc.DocumentNode.SelectSingleNode(XPath);

            HtmlDocument dcDoc = new HtmlDocument();
            dcDoc.LoadHtml(dcTable.InnerHtml);

            HtmlNodeCollection trRows = dcDoc.DocumentNode.SelectNodes("//tr");

            for (int i = 0; i < trRows.Count; i++)
            {
                if (!string.IsNullOrEmpty(trRows[i].InnerText))
                {
                    DepthChart dc = new DepthChart();
                    dc.TeamName = team;
                    dc.Position = trRows[i].InnerText;
                    dcList.Add(dc);
                }
            }

            XPath = "//*[@id='fittPageContainer']/div[2]/div[5]/div[1]/div/section/div/section/div[2]/div[1]/section/div[2]/div/div[2]/table";
            HtmlNode tableNode = doc.DocumentNode.SelectSingleNode(XPath);

            HtmlDocument dcDoc2 = new HtmlDocument();
            dcDoc2.LoadHtml(tableNode.InnerHtml);

            HtmlNodeCollection dcTrRows = dcDoc2.DocumentNode.SelectNodes("//tr");

            int j = 0;

            for (int i = 0; i < dcTrRows.Count; i++)
            {
                HtmlDocument dcDoc3 = new HtmlDocument();
                dcDoc3.LoadHtml(dcTrRows[i].InnerHtml);

                HtmlNodeCollection tdRows = dcDoc3.DocumentNode.SelectNodes("//td");

                if (tdRows != null)
                {
                    dcList[j].Starter = tdRows[0].InnerText;   //1
                    dcList[j].Second = tdRows[1].InnerText;   //2
                    dcList[j].Third = tdRows[2].InnerText;   //3
                    dcList[j].Fourth = tdRows[3].InnerText;   //4
                    dcList[j].Fifth = tdRows[4].InnerText;   //5

                    j++;
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
