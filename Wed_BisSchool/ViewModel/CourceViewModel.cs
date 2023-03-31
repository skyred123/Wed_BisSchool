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
        public int Id { get; set; }
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
        public string Heading { get; set; }
        public string Action
        {
            get { return (Id != 0) ? "Update" : "Create"; }
        }
    }
    public class CourcesViewModel
    {
        public IEnumerable<Cource> upcomingCource { get; set;}
        public bool ShowAction { get; set; }
    }
}