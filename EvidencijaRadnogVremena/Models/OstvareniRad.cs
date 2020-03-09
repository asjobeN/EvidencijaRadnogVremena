using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class OstvareniRad
    {
        public int OstvareniRadId { get; set; }

        //public int DnevniPlanId { get; set; }
        public DateTime Datum { get; set; }

        public int RadnikId { get; set; }

        public DateTime OstvarenPocetakRada { get; set; }

        public DateTime OstvarenKrajRada { get; set; }

        [NotMapped]
        public string PeriodOstvareniRad { get; set; }

        //public TipRadaEnum TipRada { get; set; }

        public DateTime OstvarenPocetakPauze { get; set; }

        public DateTime OstvarenKrajPauze { get; set; }

        [NotMapped]
        public string PeriodOstvarenaPauza { get; set; }

        public virtual DnevniPlan DnevniPlan { get; set; }
    }
}