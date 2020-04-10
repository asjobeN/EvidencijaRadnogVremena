using EvidencijaRadnogVremena.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class DnevniPlan
    {
        public int DnevniPlanId { get; set; }

        public DateTime Datum { get; set; }

        public int RadnikId { get; set; }

        public int IdZamenskogRadnika { get; set; }

        public DateTime PlaniranPocetakRada { get; set; }

        public DateTime PlaniranKrajRada { get; set; }

        [NotMapped]
        public string PeriodRada { get; set; }

        public TipRadaEnum TipRada { get; set; }

        public DateTime PlaniranPocetakPauze { get; set; }

        public DateTime PlaniranKrajPauze { get; set; }

        [NotMapped]
        public string PeriodPauze { get; set; }

        public virtual OstvareniRad OstvarniRad { get; set; }
    }
}