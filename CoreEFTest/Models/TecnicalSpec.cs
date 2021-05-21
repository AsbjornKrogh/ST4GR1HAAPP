using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEFTest.Models
{
    public class TecnicalSpec
    {
        [Required]
        [Key]
        [MaxLength(10)]
        public int HATechinalSpecID { get; set; }

        [Required]
        public Ear EarSide { get; set; }
        
        [Required]
        public DateTime CreateDate { get; set; } 

        [Required]
        public bool Printed { get; set; }

        [Required]
        [ForeignKey("StaffLogin")]
        public int StaffID { get; set; }
        //public StaffLogin StaffLogin { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public string CPR { get; set; }
        
        public Patient Patient { get; set; }

        [Required]
        [ForeignKey("GeneralSpec")]
        public int HAGenerelSpecID { get; set; }
        
        public GeneralSpec GeneralSpec { get; set; }

        //[ForeignKey("RawEarScan")]
       // public int ScanID { get; set; }
        
        public RawEarScan RawEarScan { get; set; }

        //public List<RawEarPrint> EarPrints { get; set; }
    }
}