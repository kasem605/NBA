namespace NBA.Model
{
    public class DepthChart : ModelBase
    {
        public DepthChart()
        {
            PlayerName = String_NULLValue;
            TeamName = String_NULLValue;
            Position = String_NULLValue;
            Depth = String_NULLValue;
        }
        public string PlayerName { get; set; }
        public string TeamName { get; set; }
        public string Position { get; set; }
        public string Depth { get; set; }
    }
}
