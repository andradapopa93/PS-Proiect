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
    public class EnrollmentManagerController : Controller
    {
        private SchoolMasterEntities db = new SchoolMasterEntities();

        //
        // GET: /EnrollmentManager/

        public ViewResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Course).Include(e => e.Student);
            return View(enrollments.ToList());
        }

        //
        // GET: /EnrollmentManager/Details/5

        public ViewResult Details(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            return View(enrollment);
        }

        //
        // GET: /EnrollmentManager/Create

        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName");
            return View();
        } 

        //
        // POST: /EnrollmentManager/Create

        [HttpPost]
        public ActionResult Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", enrollment.StudentId);
            return View(enrollment);
        }
        
        //
        // GET: /EnrollmentManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", enrollment.StudentId);
            return View(enrollment);
        }

        //
        // POST: /EnrollmentManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName", enrollment.StudentId);
            return View(enrollment);
        }

        //
        // GET: /EnrollmentManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            return View(enrollment);
        }

        //
        // POST: /EnrollmentManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
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