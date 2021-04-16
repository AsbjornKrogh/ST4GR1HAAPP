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

      [MaxLength(100)]
      [Column(TypeName = "varchar(100)")]
      public string Adress { get; set; }

      [MaxLength(30)]
      [Column(TypeName = "varchar(10)")]
      public string City { get; set; }

      [MaxLength(4)]
      public int zipcode { get; set; }
   }
}
