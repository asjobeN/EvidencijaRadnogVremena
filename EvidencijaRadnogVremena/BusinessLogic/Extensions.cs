using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EvidencijaRadnogVremena.BusinessLogic.DashboardManager;

namespace EvidencijaRadnogVremena.BusinessLogic
{
    public static class Extensions
    {
        public static string Availability(this RadnikView radnik, string akcija)
        {
            if (akcija == "checkIn")
            {
                if (radnik.TipRada == Enums.TipRadaEnum.Radi || radnik.TipRada == Enums.TipRadaEnum.Pauza)
                {
                    return "disabled";
                }
            }
            if (akcija == "checkOut")
            {
                if (radnik.TipRada == Enums.TipRadaEnum.NeRadi)
                {
                    return "disabled";
                }
            }
            if (akcija == "goToBreak")
            {
                if (radnik.TipRada == Enums.TipRadaEnum.Pauza)
                {
                    return "disabled";
                }
                if (radnik.TipRada == Enums.TipRadaEnum.NeRadi)
                {
                    return "disabled";
                }
            }
            if (akcija == "backFromBreak")
            {
                if (radnik.TipRada == Enums.TipRadaEnum.Radi)
                {
                    return "disabled";
                }
                if (radnik.TipRada == Enums.TipRadaEnum.NeRadi)
                {
                    return "disabled";
                }
                if (radnik.TipRada == Enums.TipRadaEnum.Pauza)
                {
                    return "enabled";
                }
            }
            return "enabled";
        }
    }
}