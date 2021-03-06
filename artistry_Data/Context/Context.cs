﻿using artistry_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using artistry_Data.Dbo;

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

            modelBuilder.Entity<Images>()
       .HasOne(b => b.News)
       .WithMany()
       .HasForeignKey(b => b.NewsId)
       .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Administrators> Administrators { get; set; }
        public DbSet<AppLogs> AppLogs { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<ArtistMovements> ArtistMovements { get; set; }
        public DbSet<Artworks> Artworks { get; set; }
        public DbSet<ArtworkCollections> ArtworkCollections { get; set; }
        public DbSet<ArtworkTypes> ArtworkTypes { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Collections> Collections { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Museums> Museums { get; set; }
        public DbSet<MuseumTypes> MuseumTypes { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Styles> Styles { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TicketTypes> TicketTypes { get; set; }
        public DbSet<UserAccounts> UserAccounts { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }


        public DbSet<MuseumInfoVM> MuseumInfoVM { get; set; }
    }
}
