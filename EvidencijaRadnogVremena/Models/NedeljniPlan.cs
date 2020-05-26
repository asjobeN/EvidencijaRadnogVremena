using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class NedeljniPlan
    {
        public int NedeljniPlanId { get; set; }

        [DisplayName("Datum od")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumOd { get; set; }

        [DisplayName("Datum do")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumDo { get; set; }

        [NotMapped]
        public string Period { get { return $"{DatumOd.ToShortDateString()} - {DatumDo.ToShortDateString()}"; } }

        [DisplayName("Šifra marketa")]
        public int MarketId { get; set; }

        public virtual Market Market { get; set; }

        public virtual List<DnevniPlan> DnevniPlanovi { get; set; }
    }
}