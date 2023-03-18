﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestCase_RIT_CrudAPI.Data.Context;

#nullable disable

namespace TestCase_RIT_CrudAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.DrillBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DrillBlocks");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.DrillBlockPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("integer");

                    b.Property<string>("Sequence")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Y")
                        .HasColumnType("double precision");

                    b.Property<double>("Z")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("DrillBlockPoints");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.Hole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Depth")
                        .HasColumnType("double precision");

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("Holes");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.HolePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HoleId")
                        .HasColumnType("integer");

                    b.Property<double>("X")
                        .HasColumnType("double precision");

                    b.Property<double>("Y")
                        .HasColumnType("double precision");

                    b.Property<double>("Z")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("HoleId");

                    b.ToTable("HolePoints");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.DrillBlockPoint", b =>
                {
                    b.HasOne("TestCase_RIT_CrudAPI.Model.DrillBlock", "DrillBlock")
                        .WithMany("DrillBlockPoints")
                        .HasForeignKey("DrillBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrillBlock");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.Hole", b =>
                {
                    b.HasOne("TestCase_RIT_CrudAPI.Model.DrillBlock", "DrillBlock")
                        .WithMany("Holes")
                        .HasForeignKey("DrillBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrillBlock");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.HolePoint", b =>
                {
                    b.HasOne("TestCase_RIT_CrudAPI.Model.Hole", "Hole")
                        .WithMany("HolePoints")
                        .HasForeignKey("HoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hole");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.DrillBlock", b =>
                {
                    b.Navigation("DrillBlockPoints");

                    b.Navigation("Holes");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.Hole", b =>
                {
                    b.Navigation("HolePoints");
                });
#pragma warning restore 612, 618
        }
    }
}
