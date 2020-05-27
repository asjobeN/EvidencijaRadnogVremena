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
    [System.Web.Mvc.Authorize]
    public class WorkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Workers
        public ActionResult Index()
        {
            var radniks = db.Workers.Include(r => r.Market);
            return View(radniks.ToList());
        }

        // GET: Workers/Details/5
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

        // GET: Workers/Create
        public ActionResult Create()
        {
            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa");
            return View("WorkerForm", new Worker());
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "RadnikId,SifraRadnika,ImePrezime,MarketId,Uloga,Pasivan,Password,ConfirmPassword,Boja,Email,Market,Username")] Worker radnik)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa", radnik.MarketId);
                foreach (var prop in ModelState.Where(prop => prop.Value.Errors.Any()))
                {
                    Console.WriteLine(prop.Key, prop.Value.Errors);
                }
                return View("WorkerForm", radnik);
            }

            if (radnik.RadnikId == 0) //Novi radnik
            {
                db.Workers.Add(radnik);

            }
            else // Ažuriranje
            {
                db.Entry(radnik).State = EntityState.Modified;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Workers/Edit/5
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
            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa", radnik.MarketId);
            return View("Edit", new UpdateWorkerViewModel
            { Market = radnik.Market, Argb = radnik.Argb, Boja = radnik.Boja, Email = radnik.Email, ImePrezime = radnik.ImePrezime, MarketId = radnik.MarketId, Pasivan = radnik.Pasivan, 
                RadnikId = radnik.RadnikId, SifraRadnika = radnik.SifraRadnika, Uloga = radnik.Uloga, Username = radnik.Username }
            );
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Argb,RadnikId,SifraRadnika,ImePrezime,MarketId,Uloga,Boja,Email,Pasivan,Username")] UpdateWorkerViewModel radnik)
        {
            var current = db.Workers.FirstOrDefault(p => p.RadnikId == radnik.RadnikId);
            if (current == null)
                return HttpNotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa", radnik.MarketId);
                foreach (var prop in ModelState.Where(prop => prop.Value.Errors.Any()))
                {
                    Console.WriteLine(prop.Key, prop.Value.Errors);
                }
                return View("Edit", radnik);
            }
            //current.Argb = radnik.Argb;
            current.ConfirmPassword = current.Password;
            current.Email = radnik.Email;
            current.Pasivan = radnik.Pasivan;
            current.SifraRadnika = radnik.SifraRadnika;
            current.ImePrezime = radnik.ImePrezime;
            current.MarketId = radnik.MarketId;
            current.Boja = radnik.Boja;
            db.SaveChanges();
            return RedirectToAction("Index");
            //ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa", radnik.MarketId);
            //return View("Edit", radnik);
        }

        // GET: Workers/Delete/5
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

        // POST: Workers/Delete/5
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
