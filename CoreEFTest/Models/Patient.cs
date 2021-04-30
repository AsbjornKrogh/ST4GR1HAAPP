using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;
using Newtonsoft.Json;

namespace CoreEFTest.Models
{
   public class Patient
   {
      [Required]
      [Key]
      [MaxLength(11)]
      [Column(TypeName = "varchar(11)")]
      public string CPR { get; set; }

      [Required]
      [MaxLength(15)]
      [Column(TypeName = "varchar(15)")]
      public string Name { get; set; }

      [Required]
      [MaxLength(25)]
      [Column(TypeName = "varchar(25)")]
      public string Lastname { get; set; }

      [MaxLength(3)] 
      public int Age { get; set; }

      [Required]
      [MaxLength(50)]
      [Column(TypeName = "varchar(50)")]
      public string Email { get; set; }

      [Required]
      [MaxLength(12)]
      [Column(TypeName = "varchar(12)")]
      public string MobilNummer { get; set; }

      [MaxLength(100)]
      [Column(TypeName = "varchar(100)")]
      public string Adress { get; set; }

      [MaxLength(30)]
      [Column(TypeName = "varchar(10)")]
      public string City { get; set; }

      [MaxLength(4)] 
      public int zipcode { get; set; }

      public List<GeneralSpec> GeneralSpecs { get; set; }

      public List<TecnicalSpec> TecnicalSpecs { get; set; }

      public List<EarCast> EarCasts { get; set; }
   }
}
