using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SchoolMaster.Models
{
    [Bind(Exclude = "CourseId")]
    public partial class Course
    {
        [ScaffoldColumn(false)]
        public int CourseId { get; set; }

        [DisplayName("Enrollment")]
        public int EnrollmentId { get; set; }

        [Required(ErrorMessage = "A Course Name is required")]
        [StringLength(160)]
        public string Name { get; set; }

        [Required(ErrorMessage = "A Year for Studying this Course  is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "A Number of Course' Credits is required")]
        public int credits { get; set; }

        [Required(ErrorMessage = "A Course' Category is required")]
        public string Category { get; set; }

        public virtual Teacher Teacher { get; set; }
      
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}