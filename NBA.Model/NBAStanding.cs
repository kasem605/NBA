namespace NBA.Model
{
    public class NBAStanding : ModelBase
    {
        public NBAStanding()
        {
            TeamName = String_NULLValue;
            W = Integer_NULLValue;
            L = Integer_NULLValue;
            PCT = Float_NULLValue;
            GB = Integer_NULLValue;
            Home = String_NULLValue;
            Away = String_NULLValue;
            DIV = String_NULLValue;
            CONF = String_NULLValue;
            PPG = String_NULLValue;
            OPP_PPG = String_NULLValue;
            DIFF = String_NULLValue;
            STRK = String_NULLValue;
            L10 = String_NULLValue;
        }

        public string TeamName;

        public int W;

        public int L;

        public double PCT;

        public int GB;

        public string Home;

        public string HomeWin;

        public string HomeLoss;

        public string Away;
        public string AwayWin;
        public string AwayLoss;

        public string DIV;
        public string DIVWin;
        public string DIVLoss;

        public string CONF;
        public string CONFWin;
        public string CONFLoss;

        public string PPG;

        public string OPP_PPG;

        public string DIFF;

        public string STRK;

        public string L10;

    }
}
