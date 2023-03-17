﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.DrillBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DrillBlocks");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.DrillBlockPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("int");

                    b.Property<string>("Sequence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.Property<double>("Z")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("DrillBlockPoints");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.Hole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Depth")
                        .HasColumnType("float");

                    b.Property<int>("DrillBlockId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrillBlockId");

                    b.ToTable("Holes");
                });

            modelBuilder.Entity("TestCase_RIT_CrudAPI.Model.HolePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HoleId")
                        .HasColumnType("int");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.Property<double>("Z")
                        .HasColumnType("float");

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