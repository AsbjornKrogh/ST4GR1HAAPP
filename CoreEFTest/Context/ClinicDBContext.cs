using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEFTest.Context
{
   public class ClinicDBContext : DbContext
   {
      public DbSet<Patient> Patient { get; set; }
      public DbSet<EarCast> EarCast { get; set; }
      public DbSet<StaffLogin> StaffLogin { get; set; }
      public DbSet<RawEarPrint> RawEarPrints { get; set; }
      public DbSet<RawEarScan> RawEarScans { get; set; }
      public DbSet<TecnicalSpec> TecnicalSpecs { get; set; }
      public DbSet<GeneralSpec> GeneralSpecs { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlServer("Data Source=ST-I4DAB.uni.au.dk;Initial Catalog=ST4GRP1;User ID=ST4GRP1;Password=ST4GRP1;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");















      #region CascadeConverter2Restrict

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
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
            b.HasOne("CoreEFTest.Models.Patient", null)
                .WithMany("GeneralSpecs")
                .HasForeignKey("PatientCPR");
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
                .WithOne("RawEarScan")
                .HasForeignKey("CoreEFTest.Models.RawEarScan", "HATechnicalSpecID")
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
            b.HasOne("CoreEFTest.Models.Patient", "Patient")
                .WithMany()
                .HasForeignKey("CPR")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            b.HasOne("CoreEFTest.Models.GeneralSpec", "GeneralSpec")
                .WithMany()
                .HasForeignKey("HAGenerelSpecID")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            b.HasOne("CoreEFTest.Models.Patient", null)
                .WithMany("TecnicalSpecs")
                .HasForeignKey("PatientCPR");

            b.HasOne("CoreEFTest.Models.StaffLogin", "StaffLogin")
                .WithMany()
                .HasForeignKey("StaffID")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            b.Navigation("GeneralSpec");

            b.Navigation("Patient");

            b.Navigation("StaffLogin");
         });
      }

      #endregion


   }
}
