namespace FootballDirectory.Models
{
    public class League
    {
        public int LeagueID { get; set; }
        public ICollection<Team> Teams { get; set; }
        public int NumberOfTeams { get; set; }
        public string Name { get; set; }
    }
}
