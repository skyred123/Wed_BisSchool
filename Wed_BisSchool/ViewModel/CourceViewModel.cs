using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wed_BisSchool.Models;

namespace Wed_BisSchool.ViewModel
{
    public class CourceViewModel
    {
        [Required]
        public string Place { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public byte CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set;}
        public DateTime GetDateTime() { return DateTime.Parse(string.Format("{0} {1}", Date, Time)); }
    }
}