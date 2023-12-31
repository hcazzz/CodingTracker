﻿// <auto-generated />
using CodingTracker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingTracker.Migrations
{
    [DbContext(typeof(CodingTrackerContext))]
    [Migration("20230801123236_initial-migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4");

            modelBuilder.Entity("CodingTracker.CodingTracker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("codingHours")
                        .HasColumnType("REAL");

                    b.Property<double>("codingMinutes")
                        .HasColumnType("REAL");

                    b.Property<double>("codingSeconds")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("CodingTrackers");
                });
#pragma warning restore 612, 618
        }
    }
}
