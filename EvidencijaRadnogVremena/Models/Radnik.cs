using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class Radnik
    {
        [Key]
        public int RadnikId { get; set; }

        [DisplayName("Šifra radnika")]
        public string SifraRadnika { get; set; }

        [DisplayName("Ime i prezime")]
        public string ImePrezime { get; set; }

        [DisplayName("Šifra marketa")]
        public int MarketId { get; set; }

        public virtual Market Market { get; set; }

        public System.Drawing.Color Boja { get; set; }

        public Enums.UlogaEnum Uloga { get; set; }
    }
}