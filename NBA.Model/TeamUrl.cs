namespace NBA.Model
{
    public class TeamUrl : ModelBase
    {
        public TeamUrl()
        {
            ID = 0;
            TeamName = String_NULLValue;
            TeamURL = String_NULLValue;
            Description = String_NULLValue;
        }
        public int ID { get; set; }
        public string TeamName { get; set; }
        public string TeamURL { get; set; }
        public string Description { get; set; }
    }
}
