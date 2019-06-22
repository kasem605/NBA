namespace NBA.Model
{
    public class Player : ModelBase
    {
        public Player()
        {
            PlayerName = String_NULLValue;
            FName = String_NULLValue;
            MName = String_NULLValue;
            LName = String_NULLValue;
            JerseyNumber = String_NULLValue;
            Pos = String_NULLValue;
            Age = String_NULLValue;
            Weight = String_NULLValue;
            Height = String_NULLValue;
            College = String_NULLValue;
            Salary = String_NULLValue;
            TeamName = String_NULLValue;
        }
        public string PlayerName { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string JerseyNumber { get; set; }
        public string Pos { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string College { get; set; }
        public string Salary{ get; set; }
        public string TeamName { get; set; }


    }
}
