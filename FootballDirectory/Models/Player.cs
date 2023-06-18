using FootballDirectory.Enums;

namespace FootballDirectory.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamID { get; set; }
        public Team Team { get; set; }
        public PlayerPosition Position { get; set; }
    }
}
