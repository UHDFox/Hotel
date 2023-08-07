﻿// <auto-generated />
using System;
using Hotel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230725093325_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hotel.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LeavingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoomId");

                    b.HasIndex("VisitorId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Hotel.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("HaveConditioner")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HaveKitchen")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOccupated")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Number")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotel.Models.Visitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("Hotel.Models.Order", b =>
                {
                    b.HasOne("Hotel.Models.Room", "BookedRoom")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("Hotel.Models.Visitor", "Visitor")
                        .WithMany()
                        .HasForeignKey("VisitorId");

                    b.Navigation("BookedRoom");

                    b.Navigation("Visitor");
                });
#pragma warning restore 612, 618
        }
    }
}