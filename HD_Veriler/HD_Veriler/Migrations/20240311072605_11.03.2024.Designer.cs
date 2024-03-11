﻿// <auto-generated />
using System;
using HD_Veriler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HD_Veriler.Migrations
{
    [DbContext(typeof(HDVerilerContext))]
    [Migration("20240311072605_11.03.2024")]
    partial class _11032024
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HD_Veriler.Models.ChangeEquipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"));

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EquipmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Property")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId");

                    b.ToTable("ChangeEquipments");
                });

            modelBuilder.Entity("HD_Veriler.Models.ComputerDetail", b =>
                {
                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComputerId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Cpu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FormatDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MotherBoard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Os")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OsSerialName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ram")
                        .HasColumnType("int");

                    b.Property<string>("StorageHDD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageSDD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ComputerId");

                    b.ToTable("ComputerDetails");
                });

            modelBuilder.Entity("HD_Veriler.Models.Departman", b =>
                {
                    b.Property<int>("DepartmanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmanID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("DepartmanName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmanID");

                    b.ToTable("Departmans");
                });

            modelBuilder.Entity("HD_Veriler.Models.Entrusted", b =>
                {
                    b.Property<int>("EntrustedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntrustedId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int?>("OtherInventoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("EntrustedId");

                    b.ToTable("Entrusteds");
                });

            modelBuilder.Entity("HD_Veriler.Models.InventoryLaptop", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Os")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Programs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ram")
                        .HasColumnType("int");

                    b.Property<string>("StorageHDD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageSDD")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InventoryId");

                    b.ToTable("InventoryLaptops");
                });

            modelBuilder.Entity("HD_Veriler.Models.MonitorDetail", b =>
                {
                    b.Property<int>("MonitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonitorId"));

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Input")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Screen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Serino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("MonitorId");

                    b.ToTable("MonitorDetails");
                });

            modelBuilder.Entity("HD_Veriler.Models.OtherInventory", b =>
                {
                    b.Property<int>("OtherInventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OtherInventoryId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmanID")
                        .HasColumnType("int");

                    b.Property<string>("Feature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("OtherInventoryId");

                    b.ToTable("OtherInventorys");
                });

            modelBuilder.Entity("HD_Veriler.Models.Score", b =>
                {
                    b.Property<int>("ScoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreID"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ScoreID");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("HD_Veriler.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("DepartmanID")
                        .HasColumnType("int");

                    b.Property<bool>("DepartmanLeader")
                        .HasColumnType("bit");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPV4Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LeadingDepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("DepartmanID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HD_Veriler.Models.User", b =>
                {
                    b.HasOne("HD_Veriler.Models.Departman", null)
                        .WithMany("Users")
                        .HasForeignKey("DepartmanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HD_Veriler.Models.Departman", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
