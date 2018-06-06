﻿// <auto-generated />
using artistry_Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace artistry_Data.Migrations
{
    [DbContext(typeof(Context.Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("artistry_Data.Models.Administrators", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Phone");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("artistry_Data.Models.AppLogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Application")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CallSite")
                        .HasMaxLength(4000);

                    b.Property<string>("Exception")
                        .HasMaxLength(2000);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Logged");

                    b.Property<string>("Logger")
                        .HasMaxLength(255);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(4000);

                    b.Property<bool>("Seen");

                    b.HasKey("Id");

                    b.ToTable("AppLogs");
                });

            modelBuilder.Entity("artistry_Data.Models.ArtistMovements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArtistId");

                    b.Property<int>("StyleId");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("StyleId");

                    b.ToTable("ArtistMovements");
                });

            modelBuilder.Entity("artistry_Data.Models.Artists", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography");

                    b.Property<int>("Born");

                    b.Property<int>("CountryId");

                    b.Property<int?>("Died");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("artistry_Data.Models.Artworks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("artistry_Data.Models.ArtworkTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ArtworkTypes");
                });

            modelBuilder.Entity("artistry_Data.Models.Countries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("artistry_Data.Models.Currencies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Currency");

                    b.Property<string>("Symbol");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("artistry_Data.Models.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArtistId");

                    b.Property<int?>("ArtworkId");

                    b.Property<string>("Caption");

                    b.Property<byte[]>("Image");

                    b.Property<byte[]>("ImageThumb");

                    b.Property<int?>("MuseumId");

                    b.Property<bool>("Primary");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ArtworkId");

                    b.HasIndex("MuseumId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("artistry_Data.Models.Materials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("artistry_Data.Models.Messages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("ReceiverId");

                    b.Property<bool>("Seen");

                    b.Property<int?>("SenderId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("artistry_Data.Models.Museums", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<int>("MuseumTypeId");

                    b.Property<string>("Name");

                    b.Property<bool>("OnlineTickets");

                    b.Property<int>("OpeningYear");

                    b.Property<string>("Phone");

                    b.Property<bool>("QrScanning");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MuseumTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Museums");
                });

            modelBuilder.Entity("artistry_Data.Models.MuseumTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("MuseumTypes");
                });

            modelBuilder.Entity("artistry_Data.Models.Styles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("artistry_Data.Models.TicketTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrencyId");

                    b.Property<int>("MuseumId");

                    b.Property<double>("Price");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("MuseumId");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("artistry_Data.Models.UserAccounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("artistry_Data.Models.WorkingHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CloseTime");

                    b.Property<int>("Day");

                    b.Property<int>("MuseumId");

                    b.Property<DateTime>("OpenTime");

                    b.HasKey("Id");

                    b.HasIndex("MuseumId");

                    b.ToTable("WorkingHours");
                });

            modelBuilder.Entity("artistry_Data.Models.Administrators", b =>
                {
                    b.HasOne("artistry_Data.Models.UserAccounts", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("artistry_Data.Models.ArtistMovements", b =>
                {
                    b.HasOne("artistry_Data.Models.Artists", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("artistry_Data.Models.Styles", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("artistry_Data.Models.Artists", b =>
                {
                    b.HasOne("artistry_Data.Models.Countries", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("artistry_Data.Models.Currencies", b =>
                {
                    b.HasOne("artistry_Data.Models.Countries", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("artistry_Data.Models.Images", b =>
                {
                    b.HasOne("artistry_Data.Models.Artists", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("artistry_Data.Models.Artworks", "Artwork")
                        .WithMany()
                        .HasForeignKey("ArtworkId");

                    b.HasOne("artistry_Data.Models.Museums", "Museum")
                        .WithMany()
                        .HasForeignKey("MuseumId");
                });

            modelBuilder.Entity("artistry_Data.Models.Messages", b =>
                {
                    b.HasOne("artistry_Data.Models.UserAccounts", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("artistry_Data.Models.UserAccounts", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("artistry_Data.Models.Museums", b =>
                {
                    b.HasOne("artistry_Data.Models.MuseumTypes", "MuseumType")
                        .WithMany()
                        .HasForeignKey("MuseumTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("artistry_Data.Models.UserAccounts", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("artistry_Data.Models.TicketTypes", b =>
                {
                    b.HasOne("artistry_Data.Models.Currencies", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("artistry_Data.Models.Museums", "Museum")
                        .WithMany()
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("artistry_Data.Models.WorkingHours", b =>
                {
                    b.HasOne("artistry_Data.Models.Museums", "Museum")
                        .WithMany()
                        .HasForeignKey("MuseumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
