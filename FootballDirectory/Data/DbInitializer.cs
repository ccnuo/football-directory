using FootballDirectory.Data;
using FootballDirectory.Models;
using System.Diagnostics;
using FootballDirectory.Enums;

namespace FootballDirectory.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TeamContext context)
        {
            if (context.Teams.Any())
            {
                return;
            }

            var leagues = new League[]
            {
                new League{Name="Ligue 1",NumberOfTeams=20},
                new League{Name="English Premier League",NumberOfTeams=20},
                new League{Name="La Liga",NumberOfTeams=20},
                new League{Name="Serie A",NumberOfTeams=20},
                new League{Name="Bundesliga",NumberOfTeams=18}
            };

            context.Leagues.AddRange(leagues);
            context.SaveChanges();

            var teams = new Team[]
            {
                new Team{Name="Paris Saint Germain",LeagueID=1,StadiumID=1},
                new Team{Name="Tottenham Hotspur",LeagueID=2,StadiumID=2},
                new Team{Name="Real Madrid",LeagueID=3,StadiumID=3},
                new Team{Name="AC Milan",LeagueID=4,StadiumID=4},
                new Team{Name="Bayern Munich",LeagueID=5,StadiumID=5},
                new Team{Name="Chelsea",LeagueID=2,StadiumID=6},
                new Team{Name="Internazionale",LeagueID=4,StadiumID=4}
            };

            context.Teams.AddRange(teams);
            context.SaveChanges();

            var players = new Player[]
            {
                new Player{FirstName="Lionel",LastName="Messi",TeamID=1,Position=PlayerPosition.Midfielder},
                new Player{FirstName="Harry",LastName="Kane",TeamID=2,Position=PlayerPosition.Forward},
                new Player{FirstName="Vinicius",LastName="Jr",TeamID=3,Position=PlayerPosition.Forward},
                new Player{FirstName="Rafael",LastName="Leao",TeamID=4,Position=PlayerPosition.Forward},
                new Player{FirstName="Joshua",LastName="Kimmich",TeamID=5,Position=PlayerPosition.Defender},
                new Player{FirstName="Enzo",LastName="Fernandez",TeamID=6,Position=PlayerPosition.Midfielder},
                new Player{FirstName="Lautaro",LastName="Martinez",TeamID=7,Position=PlayerPosition.Forward}
            };

            context.Players.AddRange(players);
            context.SaveChanges();                      

            var stadiums = new Stadium[]
            {
                new Stadium{Name="Parc de Princes",TeamID=1,Capacity=50000},
                new Stadium{Name="Tottenham Hotspur Stadium",TeamID=2,Capacity=60000},
                new Stadium{Name="Santiago Bernabeu Stadium",TeamID=3,Capacity=80000},
                new Stadium{Name="San Siro",TeamID=4,Capacity=75000},
                new Stadium{Name="Aliianz Arena",TeamID=5,Capacity=75000},
                new Stadium{Name="Stamford Bridge",TeamID=6,Capacity=40000}
            };

            context.Stadiums.AddRange(stadiums);
            context.SaveChanges();
        }
    }
}