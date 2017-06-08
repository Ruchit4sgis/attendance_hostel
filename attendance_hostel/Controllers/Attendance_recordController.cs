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
    public class Attendance_recordController : Controller
    {
        private attendance_ho db = new attendance_ho();

        // GET: Attendance_record
        public ActionResult Index()
        {
            return View(db.Attendance_record.ToList());
        }

        // GET: Attendance_record/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance_record attendance_record = db.Attendance_record.Find(id);
            if (attendance_record == null)
            {
                return HttpNotFound();
            }
            return View(attendance_record);
        }

        // GET: Attendance_record/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendance_record/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date,reason,Member_id,Name,floor,room,cup,block,standard,A_year,incharge")] Attendance_record attendance_record)
        {
            if (ModelState.IsValid)
            {
                db.Attendance_record.Add(attendance_record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendance_record);
        }

        // GET: Attendance_record/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance_record attendance_record = db.Attendance_record.Find(id);
            if (attendance_record == null)
            {
                return HttpNotFound();
            }
            return View(attendance_record);
        }

        // POST: Attendance_record/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,reason,Member_id,Name,floor,room,cup,block,standard,A_year,incharge")] Attendance_record attendance_record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance_record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendance_record);
        }

        // GET: Attendance_record/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance_record attendance_record = db.Attendance_record.Find(id);
            if (attendance_record == null)
            {
                return HttpNotFound();
            }
            return View(attendance_record);
        }

        // POST: Attendance_record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance_record attendance_record = db.Attendance_record.Find(id);
            db.Attendance_record.Remove(attendance_record);
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
