﻿// <auto-generated />
using System;
using CoreEFTest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreEFTest.Migrations
{
    [DbContext(typeof(ClinicDBContext))]
    [Migration("20210419123800_EarSideEnumAdded")]
    partial class EarSideEnumAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreEFTest.Models.EarCast", b =>
                {
                    b.Property<int>("EarCastID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CastDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EarSide")
                        .HasColumnType("int");

                    b.Property<string>("PatientCPR")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.HasKey("EarCastID");

                    b.HasIndex("PatientCPR");

                    b.ToTable("EarCast");
                });

            modelBuilder.Entity("CoreEFTest.Models.GeneralSpec", b =>
                {
                    b.Property<int>("HAGeneralSpecID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EarSide")
                        .HasColumnType("int");

                    b.Property<int>("StaffID")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("HAGeneralSpecID");

                    b.HasIndex("StaffID");

                    b.ToTable("GeneralSpec");
                });

            modelBuilder.Entity("CoreEFTest.Models.Patient", b =>
                {
                    b.Property<string>("CPR")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Adress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Age")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("zipcode")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("CPR");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("CoreEFTest.Models.RawEarPrint", b =>
                {
                    b.Property<int>("EarPrintID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HATechnicalSpecID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PrintDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StaffID")
                        .HasColumnType("int");

                    b.HasKey("EarPrintID");

                    b.HasIndex("HATechnicalSpecID");

                    b.HasIndex("StaffID");

                    b.ToTable("RawEarPrints");
                });

            modelBuilder.Entity("CoreEFTest.Models.RawEarScan", b =>
                {
                    b.Property<int>("ScanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HATechnicalSpecID")
                        .HasColumnType("int");

                    b.Property<byte[]>("Scan")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("ScanDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StaffID")
                        .HasColumnType("int");

                    b.HasKey("ScanID");

                    b.HasIndex("HATechnicalSpecID");

                    b.HasIndex("StaffID");

                    b.ToTable("RawEarScans");
                });

            modelBuilder.Entity("CoreEFTest.Models.StaffLogin", b =>
                {
                    b.Property<int>("StaffID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<int>("StaffStatus")
                        .HasColumnType("int");

                    b.HasKey("StaffID");

                    b.ToTable("StaffLogin");
                });

            modelBuilder.Entity("CoreEFTest.Models.TecnicalSpec", b =>
                {
                    b.Property<int>("HATechinalSpecID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CPR")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EarSide")
                        .HasColumnType("int");

                    b.Property<int?>("GeneralSpecHAGeneralSpecID")
                        .HasColumnType("int");

                    b.Property<int>("HAinfo")
                        .HasColumnType("int");

                    b.Property<int>("ScanID")
                        .HasColumnType("int");

                    b.Property<int>("StaffID")
                        .HasColumnType("int");

                    b.Property<string>("patientCPR")
                        .HasColumnType("varchar(11)");

                    b.HasKey("HATechinalSpecID");

                    b.HasIndex("GeneralSpecHAGeneralSpecID");

                    b.HasIndex("ScanID");

                    b.HasIndex("StaffID");

                    b.HasIndex("patientCPR");

                    b.ToTable("TecnicalSpecs");
                });

            modelBuilder.Entity("CoreEFTest.Models.EarCast", b =>
                {
                    b.HasOne("CoreEFTest.Models.Patient", null)
                        .WithMany("EarCasts")
                        .HasForeignKey("PatientCPR")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CoreEFTest.Models.GeneralSpec", b =>
                {
                    b.HasOne("CoreEFTest.Models.StaffLogin", "StaffLogin")
                        .WithMany()
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StaffLogin");
                });

            modelBuilder.Entity("CoreEFTest.Models.RawEarPrint", b =>
                {
                    b.HasOne("CoreEFTest.Models.TecnicalSpec", "TecnicalSpec")
                        .WithMany("EarPrints")
                        .HasForeignKey("HATechnicalSpecID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CoreEFTest.Models.StaffLogin", "StaffLogin")
                        .WithMany()
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StaffLogin");

                    b.Navigation("TecnicalSpec");
                });

            modelBuilder.Entity("CoreEFTest.Models.RawEarScan", b =>
                {
                    b.HasOne("CoreEFTest.Models.TecnicalSpec", "TecnicalSpec")
                        .WithMany()
                        .HasForeignKey("HATechnicalSpecID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CoreEFTest.Models.StaffLogin", "StaffLogin")
                        .WithMany()
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StaffLogin");

                    b.Navigation("TecnicalSpec");
                });

            modelBuilder.Entity("CoreEFTest.Models.TecnicalSpec", b =>
                {
                    b.HasOne("CoreEFTest.Models.GeneralSpec", "GeneralSpec")
                        .WithMany()
                        .HasForeignKey("GeneralSpecHAGeneralSpecID");

                    b.HasOne("CoreEFTest.Models.RawEarScan", "RawEarScan")
                        .WithMany()
                        .HasForeignKey("ScanID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CoreEFTest.Models.StaffLogin", "StaffLogin")
                        .WithMany()
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CoreEFTest.Models.Patient", "patient")
                        .WithMany()
                        .HasForeignKey("patientCPR");

                    b.Navigation("GeneralSpec");

                    b.Navigation("patient");

                    b.Navigation("RawEarScan");

                    b.Navigation("StaffLogin");
                });

            modelBuilder.Entity("CoreEFTest.Models.Patient", b =>
                {
                    b.Navigation("EarCasts");
                });

            modelBuilder.Entity("CoreEFTest.Models.TecnicalSpec", b =>
                {
                    b.Navigation("EarPrints");
                });
#pragma warning restore 612, 618
        }
    }
}
