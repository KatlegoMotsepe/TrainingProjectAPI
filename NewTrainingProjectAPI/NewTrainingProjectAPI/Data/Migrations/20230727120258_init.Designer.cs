﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewTrainingProjectAPI.Data;

#nullable disable

namespace NewTrainingProjectAPI.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230727120258_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewTrainingProjectAPI.Models.Entries", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionDetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SessionDetailsId");

                    b.HasIndex("UerId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.Points", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<Guid>("SessionDetailsID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SessionDetailsID");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.SessionDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SessionDetails");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.SessionStats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AvePace")
                        .HasColumnType("float");

                    b.Property<double>("AveSpeed")
                        .HasColumnType("float");

                    b.Property<Guid>("EntriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LowSpeed")
                        .HasColumnType("float");

                    b.Property<double>("TopSpeed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EntriesId");

                    b.ToTable("SessionStats");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PassHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PassSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.Entries", b =>
                {
                    b.HasOne("NewTrainingProjectAPI.Models.SessionDetails", "SessionDetails")
                        .WithMany()
                        .HasForeignKey("SessionDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewTrainingProjectAPI.Models.User", "User")
                        .WithMany("Entries")
                        .HasForeignKey("UerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SessionDetails");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.Points", b =>
                {
                    b.HasOne("NewTrainingProjectAPI.Models.SessionDetails", "SessionDetails")
                        .WithMany("Points")
                        .HasForeignKey("SessionDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SessionDetails");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.SessionStats", b =>
                {
                    b.HasOne("NewTrainingProjectAPI.Models.Entries", "Entries")
                        .WithMany("SessionStats")
                        .HasForeignKey("EntriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entries");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.Entries", b =>
                {
                    b.Navigation("SessionStats");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.SessionDetails", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("NewTrainingProjectAPI.Models.User", b =>
                {
                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
