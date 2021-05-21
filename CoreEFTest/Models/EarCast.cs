using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreEFTest.Models
{
   public class EarCast
   { 
      [Key]
      public int EarCastID { get; set; }

      [Required]
      public Ear EarSide { get; set; }

      [Required]
      public DateTime CastDate { get; set; } = DateTime.Now.Date;

      [Required]
      public string PatientCPR { get; set; }
   }
}
