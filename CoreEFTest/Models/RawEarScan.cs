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

        //[Required]
        //public STL Scan { get; set; }

        [Required]
        public DateTime ScanDate { get; set; } = DateTime.Now.Date;

        [Required]
        [ForeignKey("StaffLogin")]
        public int StaffID { get; set; }
        public StaffLogin StaffLogin { get; set; }

        //[Required]
        //[ForeignKey("HATechnicalSpecID")]
        //public int HATechnicalSpecID { get; set; }
    }
}
