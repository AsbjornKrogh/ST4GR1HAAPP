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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlServer("Data Source=ST-I4DAB.uni.au.dk;Initial Catalog=F21ST4GRP1;User ID=F21ST4GRP1;Password=F21ST4GRP1;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

   }
}
