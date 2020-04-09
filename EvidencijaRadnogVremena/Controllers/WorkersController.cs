using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvidencijaRadnogVremena.Models;

namespace EvidencijaRadnogVremena.Controllers
{
    public class WorkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Radniks
        public ActionResult Index()
        {
            var radniks = db.Workers.Include(r => r.Market);
            return View(radniks.ToList());
        }

        // GET: Radniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker radnik = db.Workers.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        // GET: Radniks/Create
        public ActionResult Create()
        {
            ViewBag.MarketId = new SelectList(db.Marketi, "MarketId", "SifraMarketa");
            return View();
        }

        // POST: Radniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RadnikId,SifraRadnika,ImePrezime,MarketId,Uloga")] Worker radnik)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(radnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarketId = new SelectList(db.Marketi, "MarketId", "SifraMarketa", radnik.MarketId);
            return View(radnik);
        }

        // GET: Radniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker radnik = db.Workers.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarketId = new SelectList(db.Marketi, "MarketId", "SifraMarketa", radnik.MarketId);
            return View(radnik);
        }

        // POST: Radniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RadnikId,SifraRadnika,ImePrezime,MarketId,Uloga")] Worker radnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarketId = new SelectList(db.Marketi, "MarketId", "SifraMarketa", radnik.MarketId);
            return View(radnik);
        }

        // GET: Radniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker radnik = db.Workers.Find(id);
            if (radnik == null)
            {
                return HttpNotFound();
            }
            return View(radnik);
        }

        // POST: Radniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker radnik = db.Workers.Find(id);
            db.Workers.Remove(radnik);
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
