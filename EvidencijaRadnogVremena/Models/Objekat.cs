using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class Objekat
    {
        [Key]
        [DisplayName("Šifra Objekta")]
        public string SifraObjekta { get; set; }

        public string Adresa { get; set; }

        public string Naziv { get; set; }
    }
}