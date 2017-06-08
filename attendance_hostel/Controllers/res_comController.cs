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
    public class res_comController : Controller
    {
        private attendance_ho db = new attendance_ho();

        // GET: res_com
        public ActionResult Index()
        {
            if (Session["Roal"].ToString() != "admin")
            {
                return RedirectToAction("~/Home/Home");
            }
            return View(db.Reasons.ToList());
        }

        // GET: res_com/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            res_com res_com = db.Reasons.Find(id);
            if (res_com == null)
            {
                return HttpNotFound();
            }
            return View(res_com);
        }

        // GET: res_com/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: res_com/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,reasons,comment")] res_com res_com)
        {
            if (ModelState.IsValid)
            {
                db.Reasons.Add(res_com);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(res_com);
        }

        // GET: res_com/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            res_com res_com = db.Reasons.Find(id);
            if (res_com == null)
            {
                return HttpNotFound();
            }
            return View(res_com);
        }

        // POST: res_com/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,reasons,comment")] res_com res_com)
        {
            if (ModelState.IsValid)
            {
                db.Entry(res_com).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(res_com);
        }

        // GET: res_com/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            res_com res_com = db.Reasons.Find(id);
            if (res_com == null)
            {
                return HttpNotFound();
            }
            return View(res_com);
        }

        // POST: res_com/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            res_com res_com = db.Reasons.Find(id);
            db.Reasons.Remove(res_com);
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
