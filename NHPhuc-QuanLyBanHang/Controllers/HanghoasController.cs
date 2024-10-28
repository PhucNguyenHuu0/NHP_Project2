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
    public class HanghoasController : Controller
    {
        private QuanLyBanHangEntities db = new QuanLyBanHangEntities();

        // GET: Hanghoas
        public ActionResult Index()
        {
            var hanghoa = db.Hanghoa.Include(h => h.Loaihang);
            return View(hanghoa.ToList());
        }

        // GET: Hanghoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanghoa hanghoa = db.Hanghoa.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            return View(hanghoa);
        }

        // GET: Hanghoas/Create
        public ActionResult Create()
        {
            ViewBag.Maloai = new SelectList(db.Loaihang, "Maloai", "Tenloai");
            return View();
        }

        // POST: Hanghoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahang,Tenhang,Dongia,Soluong,Donvitinh,Anh,Maloai")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                db.Hanghoa.Add(hanghoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Maloai = new SelectList(db.Loaihang, "Maloai", "Tenloai", hanghoa.Maloai);
            return View(hanghoa);
        }

        // GET: Hanghoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanghoa hanghoa = db.Hanghoa.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Maloai = new SelectList(db.Loaihang, "Maloai", "Tenloai", hanghoa.Maloai);
            return View(hanghoa);
        }

        // POST: Hanghoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahang,Tenhang,Dongia,Soluong,Donvitinh,Anh,Maloai")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hanghoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Maloai = new SelectList(db.Loaihang, "Maloai", "Tenloai", hanghoa.Maloai);
            return View(hanghoa);
        }

        // GET: Hanghoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanghoa hanghoa = db.Hanghoa.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            return View(hanghoa);
        }

        // POST: Hanghoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hanghoa hanghoa = db.Hanghoa.Find(id);
            db.Hanghoa.Remove(hanghoa);
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
