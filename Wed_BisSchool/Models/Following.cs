using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wed_BisSchool.Models
{
    public class Following
    {
        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }

        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followees { get; set; }
    }
}