﻿// <auto-generated />
using System;
using CoreEFTest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreEFTest.Migrations
{
    [DbContext(typeof(ClinicDBContext))]
    partial class ClinicDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Ear")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("PatientCPR")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.HasKey("EarCastID");

                    b.HasIndex("PatientCPR");

                    b.ToTable("EarCast");
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

                    b.Property<string>("StaffStatus")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("StaffID");

                    b.ToTable("StaffLogin");
                });

            modelBuilder.Entity("CoreEFTest.Models.EarCast", b =>
                {
                    b.HasOne("CoreEFTest.Models.Patient", null)
                        .WithMany("EarCasts")
                        .HasForeignKey("PatientCPR")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoreEFTest.Models.Patient", b =>
                {
                    b.Navigation("EarCasts");
                });
#pragma warning restore 612, 618
        }
    }
}
