using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NHPhuc_QuanLyBanHang.Models;

namespace NHPhuc_QuanLyBanHang.Controllers
{
    public class QTVsController : Controller
    {
        private QuanLyBanHangEntities db = new QuanLyBanHangEntities();

        // GET: QTVs
        public ActionResult Index()
        {
            return View(db.QTV.ToList());
        }

        // GET: QTVs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QTV qTV = db.QTV.Find(id);
            if (qTV == null)
            {
                return HttpNotFound();
            }
            return View(qTV);
        }

        // GET: QTVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QTVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,password")] QTV qTV)
        {
            if (ModelState.IsValid)
            {
                db.QTV.Add(qTV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qTV);
        }

        // GET: QTVs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QTV qTV = db.QTV.Find(id);
            if (qTV == null)
            {
                return HttpNotFound();
            }
            return View(qTV);
        }

        // POST: QTVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,password")] QTV qTV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qTV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qTV);
        }

        // GET: QTVs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QTV qTV = db.QTV.Find(id);
            if (qTV == null)
            {
                return HttpNotFound();
            }
            return View(qTV);
        }

        // POST: QTVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QTV qTV = db.QTV.Find(id);
            db.QTV.Remove(qTV);
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
