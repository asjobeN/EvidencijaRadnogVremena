using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public virtual List<Radnik> Radnici { get; set; }
        //public virtual List<RadniDan> RadniDani { get; set; }

        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan PonedeljakPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan PonedeljakKrajRadnogVremena { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan UtorakPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan UtorakKrajRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan SredaPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan SredaKrajRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan CetvrtakPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan CetvrtakKrajRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan PetakPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan PetakKrajRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan? SubotaPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan? SubotaKrajRadnogVremena { get; set; }

        public TimeSpan? NedeljaPocetakRadnogVremena { get; set; }

        public TimeSpan? NedeljaKrajRadnogVremena { get; set; }

    }
}