using System;

namespace SharpEcho.CodeChallenge.Api.Team.Entities
{
    public class Match
    {
        public int  MatchID { get; set; }
        public DateTime MatchDate { get; set; }
        public int Team1ID { get; set; }
        public int Team2ID { get; set; }
        public int WinningTeamID { get; set; }
    }
}
