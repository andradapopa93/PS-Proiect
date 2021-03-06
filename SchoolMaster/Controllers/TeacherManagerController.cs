﻿using System;
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
    public class TeacherManagerController : Controller
    {
        private SchoolMasterEntities db = new SchoolMasterEntities();

        //
        // GET: /TeacherManager/

        public ViewResult Index()
        {
            return View(db.Teachers.ToList());
        }

        //
        // GET: /TeacherManager/Details/5

        public ViewResult Details(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            return View(teacher);
        }

        //
        // GET: /TeacherManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TeacherManager/Create

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(teacher);
        }
        
        //
        // GET: /TeacherManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            return View(teacher);
        }

        //
        // POST: /TeacherManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        //
        // GET: /TeacherManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            return View(teacher);
        }

        //
        // POST: /TeacherManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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