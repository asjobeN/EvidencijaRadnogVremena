﻿using System;
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
    public class MarketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Markets
        public ActionResult Index()
        {
            return View(db.Marketi.ToList());
        }

        // GET: Markets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Marketi.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }

        // GET: Markets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Markets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarketId,SifraMarketa,Adresa,Naziv,PonedeljakPocetakRadnogVremena,PonedeljakKrajRadnogVremena,UtorakPocetakRadnogVremena,UtorakKrajRadnogVremena,SredaPocetakRadnogVremena,SredaKrajRadnogVremena,CetvrtakPocetakRadnogVremena,CetvrtakKrajRadnogVremena,PetakPocetakRadnogVremena,PetakKrajRadnogVremena,SubotaPocetakRadnogVremena,SubotaKrajRadnogVremena,NedeljaPocetakRadnogVremena,NedeljaKrajRadnogVremena")] Market market)
        {
            if (ModelState.IsValid)
            {
                db.Marketi.Add(market);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(market);
        }

        // GET: Markets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Marketi.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }

        // POST: Markets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarketId,SifraMarketa,Adresa,Naziv,PonedeljakPocetakRadnogVremena,PonedeljakKrajRadnogVremena,UtorakPocetakRadnogVremena,UtorakKrajRadnogVremena,SredaPocetakRadnogVremena,SredaKrajRadnogVremena,CetvrtakPocetakRadnogVremena,CetvrtakKrajRadnogVremena,PetakPocetakRadnogVremena,PetakKrajRadnogVremena,SubotaPocetakRadnogVremena,SubotaKrajRadnogVremena,NedeljaPocetakRadnogVremena,NedeljaKrajRadnogVremena")] Market market)
        {
            if (ModelState.IsValid)
            {
                db.Entry(market).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(market);
        }

        // GET: Markets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Marketi.Find(id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }

        // POST: Markets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Market market = db.Marketi.Find(id);
            db.Marketi.Remove(market);
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
