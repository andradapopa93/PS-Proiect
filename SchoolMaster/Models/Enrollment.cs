using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SchoolMaster.Models
{
    [Bind(Exclude = "EnrollmentId")]
    public class Enrollment
    {
        [ScaffoldColumn(false)]
        public int EnrollmentId { get; set; }

        [DisplayName("Course")]
        public int CourseId { get; set; }

        [DisplayName("Student")]
        public int StudentId { get; set; }

        public double Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }
}