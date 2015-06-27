using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SchoolMaster.Models
{
    [Bind(Exclude = "TeacherId")]
    public class Teacher
    {
        [ScaffoldColumn(false)]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The FirstName is required")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "A Cabinet is required")]
        public string Cabinet { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        public string Email { get; set; }
    }
}