﻿// <auto-generated />
using HorseRaceApiCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HorseRaceApiCore.Migrations
{
    [DbContext(typeof(HorseContext))]
    [Migration("20181216014512_myFirstMigration2")]
    partial class myFirstMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HorseRaceApiCore.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("HorseRaceApiCore.Models.Horse", b =>
                {
                    b.Property<int>("HorseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId");

                    b.Property<string>("Name");

                    b.HasKey("HorseId");

                    b.HasIndex("GameId");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("HorseRaceApiCore.Models.Horse", b =>
                {
                    b.HasOne("HorseRaceApiCore.Models.Game", "Game")
                        .WithMany("Horses")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}