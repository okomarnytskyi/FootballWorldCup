using System;

namespace FootballWorldCup.Implementation.Models
{
    public class FootballMatch
    {
        public string HomeTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public string AwayTeamName { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime AddedRecordTime { get; set; }
    }
}
