using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEFTest.Context
{
   public class PatientContext : DbContext
   {
      public DbSet<Patient> Patient { get; set; }
      public DbSet<EarCast> EarCast { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder options)
         => options.UseSqlServer("Data Source=st-i4dab.uni.au.dk;User ID=F20ST2ITS2201908477;Password=F20ST2ITS2201908477;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

   }
}
