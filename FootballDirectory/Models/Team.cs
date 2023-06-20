namespace FootballDirectory.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public int LeagueID { get; set; }
        public League League { get; set; }
        public int StadiumID { get; set; }
        public ICollection<Player> Players { get; set;}
    }
}
