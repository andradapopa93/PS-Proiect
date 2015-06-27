using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SchoolMaster.Models
{
    [Bind(Exclude = "ScheduleId")]
    public class Schedule
    {
        [ScaffoldColumn(false)]
        public int ScheduleId { get; set; }

        [DisplayName("Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "An Hour is required")]
        public int Hour { get; set; }

        [Required(ErrorMessage = "A Day is required")]
        public string Day { get; set; }

        [Required(ErrorMessage = "A Room is required")]
        public string Room { get; set; }

        public virtual Course Course { get; set; }

    }
}