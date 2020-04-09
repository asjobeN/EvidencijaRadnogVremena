using EvidencijaRadnogVremena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using EvidencijaRadnogVremena.BusinessLogic;

namespace EvidencijaRadnogVremena.BusinessLogic
{
    public class DashboardManager
    {
        public List<RadnikView> RadniciView { get; set; }
        public Radnik StoreManager { get; set; }

        public DashboardManager(System.Security.Principal.IPrincipal user)
        {
            RadniciView = new List<RadnikView>();
            using (var context = new ApplicationDbContext())
            {
                StoreManager = context.Radniks.Include(x => x.Market)
                    .FirstOrDefault(x => x.Username == user.Identity.Name);
                if (StoreManager != null)
                {
                    SetMarketWorkers(StoreManager.Market);
                }
            }
        }
        public void SetMarketWorkers(Market market)
        {
            using (var context = new ApplicationDbContext())
            {
                IEnumerable<Radnik> radnici = context.Radniks;//.Where(x => x.MarketId == market.MarketId);

                
                foreach (var item in radnici)
                {
                    Enums.TipRadaEnum tipRada = Enums.TipRadaEnum.Neradi;
                    var lastAction = context.BusinessActions.AsEnumerable().LastOrDefault<BusinessAction>(x => x.Date.ToShortDateString() == DateTime.Now.ToShortDateString()
                                                                     && x.RadnikId == item.RadnikId);
                    if (lastAction != null)
                    {
                        tipRada = lastAction.TipRada;
                    }
                    RadniciView.Add(new RadnikView() { Radnik = item, TipRada = tipRada });
                }

            }
            //RadniciView.Add(new RadnikView() { Radnik = new Radnik() { RadnikId = 1, ImePrezime = "Petar Petrovic", Uloga = Enums.UlogaEnum.Radnik, SifraRadnika = "100" }, TipRada = Enums.TipRadaEnum.Neradi });
            //RadniciView.Add(new RadnikView() { Radnik = new Radnik() { RadnikId = 2, ImePrezime = "Marko Markovic", Uloga = Enums.UlogaEnum.Radnik, SifraRadnika = "102" }, TipRada = Enums.TipRadaEnum.Neradi });
            //RadniciView.Add(new RadnikView() { Radnik = new Radnik() { RadnikId = 3, ImePrezime = "Ivan Ivanovic", Uloga = Enums.UlogaEnum.Radnik, SifraRadnika = "103" }, TipRada = Enums.TipRadaEnum.Neradi });
            //RadniciView.Add(new RadnikView() { Radnik = new Radnik() { RadnikId = 4, ImePrezime = "Ana Ivanovic", Uloga = Enums.UlogaEnum.Radnik, SifraRadnika = "104" }, TipRada = Enums.TipRadaEnum.Neradi });
        }

        public class RadnikView
        {
            public Radnik Radnik { get; set; }
            public Enums.TipRadaEnum TipRada { get; set; }
        }


    }
}