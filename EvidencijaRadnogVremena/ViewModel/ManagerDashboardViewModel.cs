using EvidencijaRadnogVremena.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EvidencijaRadnogVremena.BusinessLogic.DashboardManager;

namespace EvidencijaRadnogVremena.ViewModel
{
    public class ManagerDashboardViewModel
    {
        public EvidencijaRadnogVremena.BusinessLogic.DashboardManager DashboardManager { get; set; }
        public ManagerDashboardViewModel(System.Security.Principal.IPrincipal user)
        {
            DashboardManager = new BusinessLogic.DashboardManager(user);
        }

        public string Availability(RadnikView radnik, string akcija)
        {
            return radnik.Availability(akcija);
        }
    }
}