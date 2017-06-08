using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using attendance_hostel.Models;

namespace attendance_hostel.Controllers
{
    public class Student_detailController : Controller
    {
        private attendance_ho db = new attendance_ho();

        // GET: Student_detail
        public ActionResult Index()
        {
            return View(db.Student_detail.ToList());
        }

        // GET: Student_detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_detail student_detail = db.Student_detail.Find(id);
            if (student_detail == null)
            {
                return HttpNotFound();
            }
            return View(student_detail);
        }

        // GET: Student_detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student_detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Member_id,Name,floor,room,cup,block,standard,A_year")] Student_detail student_detail)
        {
            if (ModelState.IsValid)
            {
                db.Student_detail.Add(student_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_detail);
        }

        // GET: Student_detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_detail student_detail = db.Student_detail.Find(id);
            if (student_detail == null)
            {
                return HttpNotFound();
            }
            return View(student_detail);
        }

        // POST: Student_detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Member_id,Name,floor,room,cup,block,standard,A_year")] Student_detail student_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_detail);
        }

        // GET: Student_detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_detail student_detail = db.Student_detail.Find(id);
            if (student_detail == null)
            {
                return HttpNotFound();
            }
            return View(student_detail);
        }

        // POST: Student_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_detail student_detail = db.Student_detail.Find(id);
            db.Student_detail.Remove(student_detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
