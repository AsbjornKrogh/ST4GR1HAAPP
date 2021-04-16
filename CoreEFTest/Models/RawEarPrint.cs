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
        //[ForeignKey]
        public int StaffID { get; set; }

        [Required]
        //[ForeignKey]
        public int HATechnicalSpecID { get; set; }

    }
}
