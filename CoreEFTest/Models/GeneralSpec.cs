using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEFTest.Models
{
    public class GeneralSpec
    {
        [Required]
        [Key]
        [MaxLength(10)]
        public int HAGeneralSpecID { get; set; }

        [Required]
        public Material Type { get; set; }

        [Required]
        public PlugColor Color { get; set;}

        [Required]
        public Ear EarSide { get; set; }

        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now.Date;

        [Required]
        [ForeignKey("Patient")]
        public string CPR { get; set; }

        //public Patient Patient { get; set; }

        [Required]
        [ForeignKey("StaffLogin")]
        public int StaffID { get; set; }

        //public StaffLogin StaffLogin { get; set; }

    }
}