using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreEFTest.Models
{
   public class RawEarScan
   {
      [Required]
      [Key]
      public int ScanID { get; set; }

      [Required]
      public byte[] Scan { get; set; }

      [Required]
      public Ear EarSide { get; set; }

      [Required]
      public DateTime ScanDate { get; set; } = DateTime.Now.Date;

      [Required]
      [ForeignKey("StaffLogin")]
      public int StaffID { get; set; }
      public StaffLogin StaffLogin { get; set; }

      [Required]
      [ForeignKey("TecnicalSpec")]
      public int HATechnicalSpecID { get; set; }

      public TecnicalSpec TecnicalSpec { get; set; }
   }
}
