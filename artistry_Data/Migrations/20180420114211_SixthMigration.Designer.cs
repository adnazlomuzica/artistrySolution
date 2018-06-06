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
    [Migration("20180420114211_SixthMigration")]
    partial class SixthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("artistry_Data.Models.Administrators", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

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

            modelBuilder.Entity("artistry_Data.Models.Materials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

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

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("artistry_Data.Models.MuseumTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MuseumTypes");
                });

            modelBuilder.Entity("artistry_Data.Models.Styles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("artistry_Data.Models.UserAccounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("artistry_Data.Models.Administrators", b =>
                {
                    b.HasOne("artistry_Data.Models.UserAccounts", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
#pragma warning restore 612, 618
        }
    }
}
