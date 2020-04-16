using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class RadniDan
    {
        [Key]
        public int RadniDanId { get; set; }
        public int? MarketId { get; set; }
        public Market Market { get; set; }
        public DayOfWeek Dan { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
    }
}