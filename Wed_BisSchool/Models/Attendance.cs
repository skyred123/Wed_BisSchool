using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wed_BisSchool.Models
{
    public class Attendance
    {
        [Key]
        public Cource Cource { get; set; }
        public int CourceId { get; set; }
        public ApplicationUser User { get; set; }
        [Key]
        public string UserId { get; set; }
    }
}