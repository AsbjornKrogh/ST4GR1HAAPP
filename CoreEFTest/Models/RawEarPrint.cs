using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreEFTest.Models
{
    public class RawEarPrint
    {
        [Required]
        [Key]
        public int EarPrintID { get; set; }

        [Required]
        public DateTime PrintDate { get; set; } = DateTime.Now.Date;

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
