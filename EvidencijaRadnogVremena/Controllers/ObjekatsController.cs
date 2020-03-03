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
    public class ObjekatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Objekats
        public ActionResult Index()
        {
            return View(db.Objekats.ToList());
        }

        // GET: Objekats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objekat objekat = db.Objekats.Find(id);
            if (objekat == null)
            {
                return HttpNotFound();
            }
            return View(objekat);
        }

        // GET: Objekats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objekats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SifraObjekta,Adresa,Naziv")] Objekat objekat)
        {
            if (ModelState.IsValid)
            {
                db.Objekats.Add(objekat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objekat);
        }

        // GET: Objekats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objekat objekat = db.Objekats.Find(id);
            if (objekat == null)
            {
                return HttpNotFound();
            }
            return View(objekat);
        }

        // POST: Objekats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SifraObjekta,Adresa,Naziv")] Objekat objekat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objekat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objekat);
        }

        // GET: Objekats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objekat objekat = db.Objekats.Find(id);
            if (objekat == null)
            {
                return HttpNotFound();
            }
            return View(objekat);
        }

        // POST: Objekats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Objekat objekat = db.Objekats.Find(id);
            db.Objekats.Remove(objekat);
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
