using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SchoolMaster.Models;

namespace SchoolMaster.Controllers
{
    public class TeacherController : Controller
    {

        SchoolMasterEntities schoolDB = new SchoolMasterEntities();


        //
        // GET: /Teacher/

        public ActionResult Index()
        {
            var teachers = schoolDB.Teachers.ToList();
            return View(teachers);
        }


        //
        // GET: /Teacher/Browse?name=Dinsoreanu

        public ActionResult Browse(string name)
        {
            var teacherModel = schoolDB.Teachers.Where(p => p.LastName == name).ToList();

            return View(teacherModel);
        }


        //
        // GET: /Teacher/Details/5
        public ActionResult Details(int id)
        {
            var teacher = schoolDB.Teachers.Find(id);

            return View(teacher);
        }

    }
}
