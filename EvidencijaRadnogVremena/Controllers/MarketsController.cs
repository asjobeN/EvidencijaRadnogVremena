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
            return View(db.Markets.ToList());
        }

        // GET: Markets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Markets.Include(m=>m.Radnici).SingleOrDefault(m=>m.MarketId == id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View(market);
        }

        // GET: Markets/Create
        public ActionResult Create()
        {
            return View("MarketForm", new Market());
        }

        // POST: Markets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "MarketId,SifraMarketa,Adresa,Naziv,PonedeljakPocetakRadnogVremena,PonedeljakKrajRadnogVremena,UtorakPocetakRadnogVremena,UtorakKrajRadnogVremena,SredaPocetakRadnogVremena,SredaKrajRadnogVremena,CetvrtakPocetakRadnogVremena,CetvrtakKrajRadnogVremena,PetakPocetakRadnogVremena,PetakKrajRadnogVremena,SubotaPocetakRadnogVremena,SubotaKrajRadnogVremena,NedeljaPocetakRadnogVremena,NedeljaKrajRadnogVremena")] Market market)
        {
            if (!ModelState.IsValid)
            {
                foreach (var prop in ModelState.Where(prop => prop.Value.Errors.Any()))
                {
                    Console.WriteLine(prop.Key, prop.Value.Errors);
                }

                return View("MarketForm", market);
            }
            if (market.MarketId == 0)
            {
                db.Markets.Add(market);
            }
            else
            {
                db.Entry(market).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Markets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Markets.SingleOrDefault(mar => mar.MarketId == id);
            if (market == null)
            {
                return HttpNotFound();
            }
            return View("MarketForm", market);
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
            return View("MarketForm", market);
        }

        // GET: Markets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Market market = db.Markets.Find(id);
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
            Market market = db.Markets.Find(id);
            db.Markets.Remove(market);
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
