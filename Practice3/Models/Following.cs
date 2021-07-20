using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Practice3.Models
{
    public partial class Following
    {
        [Key, Column(Order = 1), ForeignKey("Follower")]
        public string FollowerId { get; set; }
        [Key, Column(Order = 2), ForeignKey("Followee")]
        public string FolloweeId { get; set; }
        public virtual ApplicationUser Follower { get; set; }
        public virtual ApplicationUser Followee { get; set; }
    }
}