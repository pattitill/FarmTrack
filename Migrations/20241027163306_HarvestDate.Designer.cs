﻿// <auto-generated />
using System;
using FarmTrack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmTrack.Migrations
{
    [DbContext(typeof(FarmTrackContext))]
    [Migration("20241027163306_HarvestDate")]
    partial class HarvestDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("FarmTrack.Models.Crop", b =>
                {
                    b.Property<int>("CropId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CropName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("CropType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExpectedHarvestDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("GrowthDurationInDays")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("HarvestDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Harvested")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PlantingDate")
                        .HasColumnType("TEXT");

                    b.HasKey("CropId");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("FarmTrack.Models.EmailList", b =>
                {
                    b.Property<int>("EmailListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("EmailListId");

                    b.ToTable("EmailLists");
                });

            modelBuilder.Entity("FarmTrack.Models.Reminder", b =>
                {
                    b.Property<int>("ReminderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CropName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("NotificationSent")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReminderTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReminderType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ReminderId");

                    b.ToTable("Reminders");
                });
#pragma warning restore 612, 618
        }
    }
}
