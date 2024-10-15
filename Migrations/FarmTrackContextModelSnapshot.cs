﻿// <auto-generated />
using System;
using FarmTrack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmTrack.Migrations
{
    [DbContext(typeof(FarmTrackContext))]
    partial class FarmTrackContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("FarmTrack.Models.Crop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("FarmTrack.Models.RealCrop", b =>
                {
                    b.Property<int>("RealCropId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CropId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ExpectedHarvestDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("HarvestDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PlantingDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("QuantityHarvested")
                        .HasColumnType("INTEGER");

                    b.HasKey("RealCropId");

                    b.HasIndex("CropId");

                    b.ToTable("RealCrops");
                });

            modelBuilder.Entity("FarmTrack.Models.RealCrop", b =>
                {
                    b.HasOne("FarmTrack.Models.Crop", "Crop")
                        .WithMany()
                        .HasForeignKey("CropId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crop");
                });
#pragma warning restore 612, 618
        }
    }
}
