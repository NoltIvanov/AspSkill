﻿// <auto-generated />
using System;
using AspLearn.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspLearn.DataBase.Migrations
{
    [DbContext(typeof(EfTestDbContext))]
    [Migration("20190215090423_CreateCityTable")]
    partial class CreateCityTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspLearn.Data.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<Guid>("NetUid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NetUID")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("AspLearn.Data.Models.PointOfInterestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CityId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointOfInterestEntity");
                });

            modelBuilder.Entity("AspLearn.Data.Models.PointOfInterestEntity", b =>
                {
                    b.HasOne("AspLearn.Data.Models.City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}
