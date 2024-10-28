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
    public class DonhangchitietsController : Controller
    {
        private QuanLyBanHangEntities db = new QuanLyBanHangEntities();

        // GET: Donhangchitiets
        public ActionResult Index()
        {
            var donhangchitiet = db.Donhangchitiet.Include(d => d.Donhang).Include(d => d.Hanghoa);
            return View(donhangchitiet.ToList());
        }

        // GET: Donhangchitiets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donhangchitiet donhangchitiet = db.Donhangchitiet.Find(id);
            if (donhangchitiet == null)
            {
                return HttpNotFound();
            }
            return View(donhangchitiet);
        }

        // GET: Donhangchitiets/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.Donhang, "MaDH", "MaDH");
            ViewBag.Mahang = new SelectList(db.Hanghoa, "Mahang", "Tenhang");
            return View();
        }

        // POST: Donhangchitiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,Mahang,Dongia,Soluong,Thanhtien")] Donhangchitiet donhangchitiet)
        {
            if (ModelState.IsValid)
            {
                db.Donhangchitiet.Add(donhangchitiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.Donhang, "MaDH", "MaDH", donhangchitiet.MaDH);
            ViewBag.Mahang = new SelectList(db.Hanghoa, "Mahang", "Tenhang", donhangchitiet.Mahang);
            return View(donhangchitiet);
        }

        // GET: Donhangchitiets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donhangchitiet donhangchitiet = db.Donhangchitiet.Find(id);
            if (donhangchitiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.Donhang, "MaDH", "MaDH", donhangchitiet.MaDH);
            ViewBag.Mahang = new SelectList(db.Hanghoa, "Mahang", "Tenhang", donhangchitiet.Mahang);
            return View(donhangchitiet);
        }

        // POST: Donhangchitiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,Mahang,Dongia,Soluong,Thanhtien")] Donhangchitiet donhangchitiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhangchitiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.Donhang, "MaDH", "MaDH", donhangchitiet.MaDH);
            ViewBag.Mahang = new SelectList(db.Hanghoa, "Mahang", "Tenhang", donhangchitiet.Mahang);
            return View(donhangchitiet);
        }

        // GET: Donhangchitiets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donhangchitiet donhangchitiet = db.Donhangchitiet.Find(id);
            if (donhangchitiet == null)
            {
                return HttpNotFound();
            }
            return View(donhangchitiet);
        }

        // POST: Donhangchitiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Donhangchitiet donhangchitiet = db.Donhangchitiet.Find(id);
            db.Donhangchitiet.Remove(donhangchitiet);
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
