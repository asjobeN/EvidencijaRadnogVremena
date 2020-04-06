using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class Market
    {
        [Key]
        public int MarketId { get; set; }

        [DisplayName("Šifra marketa")]
        public string SifraMarketa { get; set; }

        public string Adresa { get; set; }

        public string Naziv { get; set; }

        public virtual List<Worker> Radnici { get; set; }


        public DateTime PonedeljakPocetakRadnogVremena { get; set; }

        public DateTime PonedeljakKrajRadnogVremena { get; set; }

        public DateTime UtorakPocetakRadnogVremena { get; set; }

        public DateTime UtorakKrajRadnogVremena { get; set; }

        public DateTime SredaPocetakRadnogVremena { get; set; }

        public DateTime SredaKrajRadnogVremena { get; set; }

        public DateTime CetvrtakPocetakRadnogVremena { get; set; }

        public DateTime CetvrtakKrajRadnogVremena { get; set; }

        public DateTime PetakPocetakRadnogVremena { get; set; }

        public DateTime PetakKrajRadnogVremena { get; set; }

        public DateTime SubotaPocetakRadnogVremena { get; set; }

        public DateTime SubotaKrajRadnogVremena { get; set; }

        public DateTime NedeljaPocetakRadnogVremena { get; set; }

        public DateTime NedeljaKrajRadnogVremena { get; set; }
    }
}