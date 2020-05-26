using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvidencijaRadnogVremena.Models;
using EvidencijaRadnogVremena.ViewModel;

namespace EvidencijaRadnogVremena.Controllers
{
    public class NedeljniPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: NedeljniPlans
        public ActionResult Index()
        {
            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa");

            var nedeljniVM = new EvidencijaRadnogVremena.ViewModel.NedeljniPlanoviViewModel()
            {
                NedeljniPlanovi = db.NedeljniPlans.ToList(),
                Marketi = new SelectList(db.Markets, "MarketId", "SifraMarketa"),
            };

            return View(nedeljniVM);
        }

        [HttpPost]
        public ActionResult Index(int? MarketId)
        {
            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa");
            var nedeljniPlan = db.NedeljniPlans.Where(r => r.MarketId == MarketId).ToList();
            return View(nedeljniPlan);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NedeljniPlanoviViewModel nedeljniPlanViewModel)
        {
            var radnici = db.Workers.Where(rad => rad.MarketId == nedeljniPlanViewModel.MarketId).ToList();
            var nedeljniPlan = new NedeljniPlan();
            nedeljniPlan.MarketId = nedeljniPlanViewModel.MarketId;
            nedeljniPlan.Market = db.Markets.Single(mar => mar.MarketId == nedeljniPlan.MarketId);
            nedeljniPlan.DatumOd = GetPrviDanUNedelji(nedeljniPlanViewModel.Nedelja);
            nedeljniPlan.DatumDo = nedeljniPlan.DatumOd.AddDays(6);
            nedeljniPlan.DnevniPlanovi = new List<DnevniPlan>();
            for (DateTime datum = nedeljniPlan.DatumOd; datum < nedeljniPlan.DatumDo; datum = datum.AddDays(1))
                foreach (var radnik in nedeljniPlan.Market.Radnici)
                    nedeljniPlan.DnevniPlanovi.Add(new DnevniPlan() { RadnikId = radnik.RadnikId, Datum = datum, NedeljniPlan = nedeljniPlan, PlaniranPocetakRada = DateTime.Now, 
                        PlaniranKrajRada = DateTime.Now, PlaniranPocetakPauze = DateTime.Now, PlaniranKrajPauze = DateTime.Now
                    });
            nedeljniPlan.DnevniPlanovi.OrderBy(dp => dp.Datum).ThenBy(dp => dp.NedeljniPlan.MarketId).ThenBy(dp => dp.RadnikId);

            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa");
            ViewBag.ListaRadnika = new SelectList(db.Workers, "RadnikId", "SifraRadnika");
            return View("NedeljniPlanForm", nedeljniPlan);
        }


        //// POST: NedeljniPlans/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "NedeljniPlanId,DatumOd,DatumDo,MarketId")] NedeljniPlan nedeljniPlan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.NedeljniPlans.Add(nedeljniPlan);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa");
        //    return View(nedeljniPlan);
        //}

        // GET: NedeljniPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NedeljniPlan nedeljniPlan = db.NedeljniPlans.Include(np => np.DnevniPlanovi).Include(np => np.Market).Include(np => np.Market.Radnici).SingleOrDefault(x => x.NedeljniPlanId == id);

            if (nedeljniPlan == null)
            {
                return HttpNotFound();
            }
            nedeljniPlan.DnevniPlanovi.OrderBy(dp => dp.Datum).ThenBy(dp => dp.NedeljniPlan.MarketId).ThenBy(dp => dp.RadnikId);

            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa", nedeljniPlan.MarketId);
            return View("NedeljniPlanForm", nedeljniPlan);
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
            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa");
            return View("NedeljniPlanForm", nedeljniPlan);
        }

        public ActionResult AddWorker(int id)
        {
            var nedeljniPlan = db.NedeljniPlans.Single(np => np.NedeljniPlanId == id);
            if (ModelState.IsValid)
            {
                db.Entry(nedeljniPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa");
            return View("NedeljniPlanForm", nedeljniPlan);
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "NedeljniPlanId,DatumOd,DatumDo,MarketId,DnevniPlanovi")]NedeljniPlan nedeljniPlan)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "SifraMarketa", nedeljniPlan.MarketId);
                foreach (var prop in ModelState.Where(prop => prop.Value.Errors.Any()))
                {
                    Console.WriteLine(prop.Key, prop.Value.Errors);
                }
                return View("NedeljniPlanForm", nedeljniPlan);
            }

            if (nedeljniPlan.NedeljniPlanId == 0) //Novi nedeljni plan
            {
                db.NedeljniPlans.Add(nedeljniPlan);

            }
            else // Ažuriranje
            {
                foreach (var dp in nedeljniPlan.DnevniPlanovi)
                    db.Entry(dp).State = EntityState.Modified;
                    //if (!TryUpdateModel(dp))
                    //{ 
                    //}
                    //db.Set<NedeljniPlan>().AddOrUpdate(nedeljniPlan);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
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

        private static DateTime GetPrviDanUNedelji(string nedelja)
        {
            System.Text.RegularExpressions.Regex parseRegex = new System.Text.RegularExpressions.Regex(@"^(?<year>\d{4})-W?(?<week>\d{2})$");
            DateTime date = DateTime.Now;
            var match = parseRegex.Match(nedelja);
            if (match.Success)
            {
                var year = int.Parse(match.Groups["year"].Value);
                var week = int.Parse(match.Groups["week"].Value);
                date = FirstDateOfWeekISO8601(year, week);
            }

            return date;
        }

        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }
    }
}
