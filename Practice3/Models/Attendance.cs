using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Practice3.Models
{
    [Table("Attendance")]
    public partial class Attendance
    {
        [Key, Column(Order = 1)]
        public int CourseId { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("ApplicationUser")]
        public string Attendee { get; set; }
        public virtual Course Course { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}