﻿// <auto-generated />
using System;
using FormuleCirkelEntity.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FormuleCirkelEntity.Migrations
{
    [DbContext(typeof(FormulaContext))]
    [Migration("20190919120442_Pace")]
    partial class Pace
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FormuleCirkelEntity.Models.Championship", b =>
                {
                    b.Property<int>("ChampionshipId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ActiveChampionship");

                    b.Property<string>("ChampionshipName");

                    b.HasKey("ChampionshipId");

                    b.ToTable("Championships");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation");

                    b.Property<bool>("Archived");

                    b.Property<string>("Biography");

                    b.Property<int>("DriverNumber");

                    b.Property<string>("Name");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.DriverResult", b =>
                {
                    b.Property<int>("DriverResultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DNFCause");

                    b.Property<int>("DSQCause");

                    b.Property<int>("Grid");

                    b.Property<string>("PenaltyReason");

                    b.Property<int>("Points");

                    b.Property<int>("Position");

                    b.Property<int>("RaceId");

                    b.Property<int>("SeasonDriverId");

                    b.Property<int>("Status");

                    b.Property<string>("StintResults");

                    b.HasKey("DriverResultId");

                    b.HasIndex("RaceId");

                    b.HasIndex("SeasonDriverId");

                    b.ToTable("DriverResults");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Engine", b =>
                {
                    b.Property<int>("EngineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<bool>("Available");

                    b.Property<string>("Name");

                    b.Property<int>("Power");

                    b.HasKey("EngineId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Qualification", b =>
                {
                    b.Property<int>("QualyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Accent")
                        .HasMaxLength(7);

                    b.Property<string>("Colour")
                        .HasMaxLength(7);

                    b.Property<int>("DriverId");

                    b.Property<string>("DriverName");

                    b.Property<double?>("PenaltyPosition");

                    b.Property<int?>("Position");

                    b.Property<int>("RaceId");

                    b.Property<int?>("Score");

                    b.Property<string>("TeamName");

                    b.HasKey("QualyId");

                    b.ToTable("Qualification");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("RaceState");

                    b.Property<int>("Round");

                    b.Property<int>("SeasonId");

                    b.Property<int>("StintProgress");

                    b.Property<string>("Stints");

                    b.Property<int>("TrackId");

                    b.Property<int>("Weather");

                    b.HasKey("RaceId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TrackId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Season", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChampionshipId");

                    b.Property<string>("PointsPerPosition");

                    b.Property<int>("PolePoints");

                    b.Property<int>("QualificationRNG");

                    b.Property<int>("QualificationRemainingDriversQ2");

                    b.Property<int>("QualificationRemainingDriversQ3");

                    b.Property<int>("SeasonNumber");

                    b.Property<DateTime?>("SeasonStart");

                    b.Property<int>("State");

                    b.HasKey("SeasonId");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.SeasonDriver", b =>
                {
                    b.Property<int>("SeasonDriverId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChassisMod");

                    b.Property<int>("DriverId");

                    b.Property<int>("DriverStatus");

                    b.Property<int>("Points");

                    b.Property<int>("QualyPace");

                    b.Property<int>("RacePace");

                    b.Property<int>("ReliabilityMod");

                    b.Property<int>("SeasonId");

                    b.Property<int>("SeasonTeamId");

                    b.Property<int>("Skill");

                    b.Property<int>("Style");

                    b.Property<int>("Tires");

                    b.HasKey("SeasonDriverId");

                    b.HasIndex("DriverId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("SeasonTeamId");

                    b.ToTable("SeasonDrivers");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.SeasonTeam", b =>
                {
                    b.Property<int>("SeasonTeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Acceleration");

                    b.Property<int>("Chassis");

                    b.Property<int>("EngineId");

                    b.Property<int>("Handling");

                    b.Property<int>("Points");

                    b.Property<string>("Principal");

                    b.Property<int>("Reliability");

                    b.Property<int>("SeasonId");

                    b.Property<int>("Stability");

                    b.Property<int>("TeamId");

                    b.Property<int>("Topspeed");

                    b.HasKey("SeasonTeamId");

                    b.HasIndex("EngineId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("SeasonTeams");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Accent")
                        .HasMaxLength(7);

                    b.Property<bool>("Archived");

                    b.Property<string>("Biography");

                    b.Property<string>("Colour")
                        .HasMaxLength(7);

                    b.Property<string>("Name");

                    b.HasKey("TeamId");

                    b.HasIndex("Abbreviation")
                        .IsUnique()
                        .HasFilter("[Abbreviation] IS NOT NULL");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived");

                    b.Property<int>("DNFodds");

                    b.Property<decimal>("LengthKM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Location");

                    b.Property<int?>("MostRecentWinnerDriverId");

                    b.Property<string>("Name");

                    b.Property<int>("RNGodds");

                    b.Property<int>("Specification");

                    b.HasKey("TrackId");

                    b.HasIndex("MostRecentWinnerDriverId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.DriverResult", b =>
                {
                    b.HasOne("FormuleCirkelEntity.Models.Race", "Race")
                        .WithMany("DriverResults")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FormuleCirkelEntity.Models.SeasonDriver", "SeasonDriver")
                        .WithMany("DriverResults")
                        .HasForeignKey("SeasonDriverId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Race", b =>
                {
                    b.HasOne("FormuleCirkelEntity.Models.Season", "Season")
                        .WithMany("Races")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FormuleCirkelEntity.Models.Track", "Track")
                        .WithMany("Races")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Season", b =>
                {
                    b.HasOne("FormuleCirkelEntity.Models.Championship", "Championship")
                        .WithMany("Seasons")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.SeasonDriver", b =>
                {
                    b.HasOne("FormuleCirkelEntity.Models.Driver", "Driver")
                        .WithMany("SeasonDrivers")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FormuleCirkelEntity.Models.Season", "Season")
                        .WithMany("Drivers")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FormuleCirkelEntity.Models.SeasonTeam", "SeasonTeam")
                        .WithMany("SeasonDrivers")
                        .HasForeignKey("SeasonTeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.SeasonTeam", b =>
                {
                    b.HasOne("FormuleCirkelEntity.Models.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FormuleCirkelEntity.Models.Season", "Season")
                        .WithMany("Teams")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FormuleCirkelEntity.Models.Team", "Team")
                        .WithMany("SeasonTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("FormuleCirkelEntity.Models.Track", b =>
                {
                    b.HasOne("FormuleCirkelEntity.Models.Driver", "MostRecentWinner")
                        .WithMany()
                        .HasForeignKey("MostRecentWinnerDriverId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}