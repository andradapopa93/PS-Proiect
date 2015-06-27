using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SchoolMaster.Models
{
    [Bind(Exclude = "StudentId")]
    public partial class Student
    {
        [ScaffoldColumn(false)]
        public int StudentId { get; set; }

        [DisplayName("Enrollment")]
        public int EnrollmentId { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A FirstName is required")]
        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        [Required(ErrorMessage = "The group is required")]
        public int Group { get; set; }

        public string Email { get; set; }
        public double FinalMark { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}