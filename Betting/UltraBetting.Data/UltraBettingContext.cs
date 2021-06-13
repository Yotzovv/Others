using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UltraBetting.Data.Models;

namespace UltraBetting.Data
{
    public class UltraBettingContext : DbContext
    {
        public UltraBettingContext(DbContextOptions<UltraBettingContext> options)
            : base(options)
        {
        }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Odd> Odds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sport>().ToTable("Sports");
            builder.Entity<Event>().ToTable("Events");
            builder.Entity<Match>().ToTable("Matches");
            builder.Entity<Bet>().ToTable("Bets");
            builder.Entity<Odd>().ToTable("Odds");

            builder.Entity<Sport>()
                   .HasMany(e => e.Events)
                   .WithOne(s => s.Sport)
                   .HasForeignKey(fk => fk.SportId);

            builder.Entity<Event>()
                   .HasOne(s => s.Sport)
                   .WithMany(e => e.Events)
                   .HasForeignKey(fk => fk.SportId);

            builder.Entity<Match>()
                   .HasOne(e => e.Event)
                   .WithMany(m => m.Matches)
                   .HasForeignKey(fk => fk.EventId);

            builder.Entity<Match>()
                   .HasMany(b => b.Bets)
                   .WithOne(m => m.Match)
                   .HasForeignKey(fk => fk.MatchId);                   

            builder.Entity<Bet>()
                   .HasOne(m => m.Match)
                   .WithMany(b => b.Bets)
                   .HasForeignKey(fk => fk.MatchId);

            builder.Entity<Odd>()
                   .HasOne(b => b.Bet)
                   .WithMany(o => o.Odds)
                   .HasForeignKey(fk => fk.BetId);

        }
    }
}
