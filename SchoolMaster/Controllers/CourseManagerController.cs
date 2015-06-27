using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolMaster.Models;

namespace SchoolMaster.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CourseManagerController : Controller
    {
        private SchoolMasterEntities db = new SchoolMasterEntities();

        //
        // GET: /CourseManager/

        public ViewResult Index()
        {
            return View(db.Courses.ToList());
        }

        //
        // GET: /CourseManager/Details/5

        public ViewResult Details(int id)
        {
            Course course = db.Courses.Find(id);
            return View(course);
        }

        //
        // GET: /CourseManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CourseManager/Create

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(course);
        }
        
        //
        // GET: /CourseManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Course course = db.Courses.Find(id);
            return View(course);
        }

        //
        // POST: /CourseManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        //
        // GET: /CourseManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Course course = db.Courses.Find(id);
            return View(course);
        }

        //
        // POST: /CourseManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}