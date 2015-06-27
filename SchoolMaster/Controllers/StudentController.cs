using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SchoolMaster.Models;

namespace SchoolMaster.Controllers
{
    public class StudentController : Controller
    {

        SchoolMasterEntities schoolDB = new SchoolMasterEntities();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            var students = schoolDB.Students.ToList();
            return View(students);
        }


        //
        // GET: /Student/Browse?name=Popa
 
        public ActionResult Browse(string name)
        {
            var studentModel = schoolDB.Students.Where(p => p.LastName == name).ToList();

            return View(studentModel);
        }


        //
        // GET: /Student/Details/5
        public ActionResult Details(int id)
        {
            var student = schoolDB.Students.Find(id);

            return View(student);
        }

    }
}
