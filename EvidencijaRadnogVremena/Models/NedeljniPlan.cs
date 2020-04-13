using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class NedeljniPlan
    {
        public int NedeljniPlanId { get; set; }

        [DisplayName("Datum od")]
        public DateTime DatumOd { get; set; }

        [DisplayName("Datum do")]
        public DateTime DatumDo { get; set; }

        [NotMapped]
        public string Period { get; set; }

        public int MarketId { get; set; }

        public List<DnevniPlan> DnevniPlanovi { get; set; }
    }
}