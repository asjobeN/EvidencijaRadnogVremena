using EvidencijaRadnogVremena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidencijaRadnogVremena.ViewModel
{
    public class NedeljniPlanoviViewModel
    {
        public IEnumerable<NedeljniPlan> NedeljniPlanovi {get; set;}

        public string Nedelja { get; set; }

        public SelectList Marketi { get; set; }

        public int MarketId { get; set; }

    }
}


//namespace EvidencijaRadnogVremena.ViewModel
//{
//    public class NedeljniPlanViewModel
//    {
//        public IEnumerable<EvidencijaRadnogVremena.Models.NedeljniPlan> NedeljniPlanovi { get; set; }
//        public int MarketId { get; set; }


//        public Models.Market IzabraniMarket { get; set; }
//        private ApplicationDbContext context = new ApplicationDbContext();
//        public SelectList Marketi { get; set; }



//        public NedeljniPlanViewModel()
//        {

//            //using (var context = new ApplicationDbContext())
//            {
//                NedeljniPlanovi = context.NedeljniPlans;//.AsEnumerable().Where(x => x.MarketId == marketId);
//                Marketi = new SelectList(context.Markets, "MarketId", "SifraMarketa");
//            }
//        }

//    }
//}