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
    public class StudentManagerController : Controller
    {
        private SchoolMasterEntities db = new SchoolMasterEntities();

        //
        // GET: /StudentManager/

        public ViewResult Index()
        {
            return View(db.Students.ToList());
        }

        //
        // GET: /StudentManager/Details/5

        public ViewResult Details(int id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        //
        // GET: /StudentManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /StudentManager/Create

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(student);
        }
        
        //
        // GET: /StudentManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        //
        // POST: /StudentManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /StudentManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Student student = db.Students.Find(id);
            return View(student);
        }

        //
        // POST: /StudentManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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