using artistry_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace artistry_Data.Context
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options)
            :base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Images>()
        .HasOne(b => b.Artist)
        .WithMany()
        .HasForeignKey(b=>b.ArtistId)
        .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Administrators> Administrators { get; set; }
        public DbSet<AppLogs> AppLogs { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<ArtistMovements> ArtistMovements { get; set; }
        public DbSet<ArtworkTypes> ArtworkTypes { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Museums> Museums { get; set; }
        public DbSet<MuseumTypes> MuseumTypes { get; set; }
        public DbSet<Styles> Styles { get; set; }
        public DbSet<TicketTypes> TicketTypes { get; set; }
        public DbSet<UserAccounts> UserAccounts { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
    }
}
