using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FootballDirectory.Models;

namespace FootballDirectory.Data
{
    public class TeamContext : DbContext
    {
        public TeamContext (DbContextOptions<TeamContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<League>().ToTable("League");
            modelBuilder.Entity<Stadium>().ToTable("Stadium");
        }
    }
}
