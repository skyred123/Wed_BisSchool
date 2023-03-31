using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wed_BisSchool.Models
{
    public class Cource
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        [Required]
        public string LecturerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public byte CategoryId { get; set; }
        public ApplicationUser Lecturer { get; set; }
        public Category Category { get; set; }
    }
}