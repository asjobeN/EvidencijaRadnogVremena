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
    public class NedeljniPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NedeljniPlans
        public ActionResult Index()
        {
            return View(db.NedeljniPlans.ToList());
        }

        // GET: NedeljniPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NedeljniPlan nedeljniPlan = db.NedeljniPlans.Find(id);
            if (nedeljniPlan == null)
            {
                return HttpNotFound();
            }
            return View(nedeljniPlan);
        }

        // GET: NedeljniPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NedeljniPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NedeljniPlanId,DatumOd,DatumDo,MarketId")] NedeljniPlan nedeljniPlan)
        {
            if (ModelState.IsValid)
            {
                db.NedeljniPlans.Add(nedeljniPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nedeljniPlan);
        }

        // GET: NedeljniPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NedeljniPlan nedeljniPlan = db.NedeljniPlans.Find(id);
            if (nedeljniPlan == null)
            {
                return HttpNotFound();
            }
            return View(nedeljniPlan);
        }

        // POST: NedeljniPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NedeljniPlanId,DatumOd,DatumDo,MarketId")] NedeljniPlan nedeljniPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nedeljniPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nedeljniPlan);
        }

        // GET: NedeljniPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NedeljniPlan nedeljniPlan = db.NedeljniPlans.Find(id);
            if (nedeljniPlan == null)
            {
                return HttpNotFound();
            }
            return View(nedeljniPlan);
        }

        // POST: NedeljniPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NedeljniPlan nedeljniPlan = db.NedeljniPlans.Find(id);
            db.NedeljniPlans.Remove(nedeljniPlan);
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
