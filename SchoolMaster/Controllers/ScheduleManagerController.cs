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
    //[Authorize(Roles = "Administrator")]
    public class ScheduleManagerController : Controller
    {
        private SchoolMasterEntities db = new SchoolMasterEntities();

        //
        // GET: /ScheduleManager/

        public ViewResult Index()
        {
            var schedules = db.Schedules.Include(s => s.Course);
            return View(schedules.ToList());
        }

        //
        // GET: /ScheduleManager/Details/5

        public ViewResult Details(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            return View(schedule);
        }

        //
        // GET: /ScheduleManager/Create

        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            return View();
        } 

        //
        // POST: /ScheduleManager/Create

        [HttpPost]
        public ActionResult Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", schedule.CourseId);
            return View(schedule);
        }
        
        //
        // GET: /ScheduleManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", schedule.CourseId);
            return View(schedule);
        }

        //
        // POST: /ScheduleManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", schedule.CourseId);
            return View(schedule);
        }

        //
        // GET: /ScheduleManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            return View(schedule);
        }

        //
        // POST: /ScheduleManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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