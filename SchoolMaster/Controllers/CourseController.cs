using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SchoolMaster.Models;

namespace SchoolMaster.Controllers
{
    public class CourseController : Controller
    {

        SchoolMasterEntities schoolDB = new SchoolMasterEntities();

        //
        // GET: /Course/
        public ActionResult Index()
        {
            var courses = schoolDB.Courses.ToList();
            return View(courses);
        }


        //
        // GET: /Course/Browse?category = Hardware
        public ActionResult Browse(string category)
        {
            var courseModel = schoolDB.Courses.Where(p => p.Category == category).ToList();

            return View(courseModel);
        }



        //
        // GET: /Course/Details/5
        public ActionResult Details(int id)
        {
            var course = schoolDB.Courses.Find(id);

            return View(course);
        }

    }
}
