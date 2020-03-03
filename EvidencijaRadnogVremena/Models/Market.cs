using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class Market
    {
        [Key]
        [DisplayName("Šifra Marketa")]
        public string SifraMarketa { get; set; }

        public string Adresa { get; set; }

        public string Naziv { get; set; }

        public string Napomena { get; set; }
    }
}