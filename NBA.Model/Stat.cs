namespace NBA.Model
{
    public class Stat : ModelBase
    {
        public Stat()
        {
            Name = String_NULLValue;
            TeamName = String_NULLValue;
            MidseasonTrades = Boolean_NULLValue;
            GamesPlayed = String_NULLValue;
            GamesStarted = String_NULLValue;
            PointsPerGame = String_NULLValue;
            OffensiveReboundsPerGame = String_NULLValue;
            DefensiveReboundsPerGame = String_NULLValue;
            ReboundsPerGame = String_NULLValue;
            AssistsPerGame = String_NULLValue;
            StealsPerGame = String_NULLValue;
            BlocksPerGame = String_NULLValue;
            TurnOversPerGame = String_NULLValue;
            FoulsPerGame = String_NULLValue;
            PlayerEfficiencyRating = String_NULLValue;
            AverageFieldGoalsMade = String_NULLValue;
            AverageFieldGoalsAttempted = String_NULLValue;
            FieldGoalPercentage = String_NULLValue;
            Average3PointFieldGoalsMade = String_NULLValue;
            Average3PointFieldGoalsAttempted = String_NULLValue;
            ThreePointFieldGoalPercentage = String_NULLValue;
            AverageFreeThrowsMade = String_NULLValue;
            FreeThrowPercentage = String_NULLValue;
            TwoPointFieldGoalsMadePerGame = String_NULLValue;
            TwoPointFieldGoalsAttemptedPerGame = String_NULLValue;
            TwoPointFieldGoalPercentage = String_NULLValue;
            ScoringEfficiency = String_NULLValue;
            ShootingEfficiency = String_NULLValue;
        }

        public string Name { get; set; }
        public string TeamName { get; set; }
        public bool MidseasonTrades { get; set; }
        public string GamesPlayed { get; set; }
        public string GamesStarted { get; set; }
        public string MinutesPerGame { get; set; }
        public string PointsPerGame { get; set; }
        public string OffensiveReboundsPerGame { get; set; }
        public string DefensiveReboundsPerGame { get; set; }
        public string ReboundsPerGame { get; set; }
        public string AssistsPerGame { get; set; }
        public string StealsPerGame { get; set; }
        public string BlocksPerGame { get; set; }
        public string TurnOversPerGame { get; set; }
        public string FoulsPerGame { get; set; }
        public string AssistToTurnoverRatio { get; set; }
        public string PlayerEfficiencyRating { get; set; }
        public string AverageFieldGoalsMade { get; set; }
        public string AverageFieldGoalsAttempted { get; set; }
        public string FieldGoalPercentage { get; set; }
        public string Average3PointFieldGoalsMade { get; set; }
        public string Average3PointFieldGoalsAttempted { get; set; }
        public string ThreePointFieldGoalPercentage { get; set; }
        public string AverageFreeThrowsMade { get; set; }
        public string AverageFreeThrowsAttempted { get; set; }
        public string FreeThrowPercentage { get; set; }
        public string TwoPointFieldGoalsMadePerGame { get; set; }
        public string TwoPointFieldGoalsAttemptedPerGame { get; set; }
        public string TwoPointFieldGoalPercentage { get; set; }
        public string ScoringEfficiency { get; set; }
        public string ShootingEfficiency { get; set; }
    }
}
