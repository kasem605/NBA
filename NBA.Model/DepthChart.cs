namespace NBA.Model
{
    public class DepthChart : ModelBase
    {
        public DepthChart()
        {
            TeamName = String_NULLValue;
            Position = String_NULLValue;
            Starter = String_NULLValue;
            Second = String_NULLValue;
            Third = String_NULLValue;
            Fourth = String_NULLValue;
            Fifth = String_NULLValue;
        }

        public string TeamName { get; set; }
        public string Position { get; set; }
        public string Starter { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
        public string Fourth { get; set; }
        public string Fifth { get; set; }
    }
}
