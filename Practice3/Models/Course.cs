using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Practice3.Models
{
    [Table("Course")]
    public partial class Course
    {
        public Course()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name;

        [Required]
        [StringLength(128)]
        [ForeignKey("ApplicationUser")]
        public string LecturerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Place { get; set; }

        public DateTime DateTime { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
