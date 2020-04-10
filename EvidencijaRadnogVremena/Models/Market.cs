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
        [Required(ErrorMessage = "Nedostaje šifra marketa")]
        public string SifraMarketa { get; set; }

        [Required(ErrorMessage = "Nedostaje adresa marketa")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Nedostaje naziv marketa")]
        public string Naziv { get; set; }

        public virtual List<Worker> Radnici { get; set; }

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

        public TimeSpan? SubotaPocetakRadnogVremena { get; set; }

        public TimeSpan? SubotaKrajRadnogVremena { get; set; }

        public TimeSpan? NedeljaPocetakRadnogVremena { get; set; }

        public TimeSpan? NedeljaKrajRadnogVremena { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<Tuple<DayOfWeek, TimeSpan?, TimeSpan?>> RadnaVremena
        {
            get
            {
                return new List<Tuple<DayOfWeek, TimeSpan?, TimeSpan?>>
                {
                    new Tuple<DayOfWeek, TimeSpan?, TimeSpan?>(DayOfWeek.Monday, PonedeljakPocetakRadnogVremena, PonedeljakKrajRadnogVremena),
                    new Tuple<DayOfWeek, TimeSpan?, TimeSpan?>(DayOfWeek.Tuesday, UtorakPocetakRadnogVremena, UtorakKrajRadnogVremena),
                    new Tuple<DayOfWeek, TimeSpan?, TimeSpan?>(DayOfWeek.Wednesday, SredaPocetakRadnogVremena, SredaKrajRadnogVremena),
                    new Tuple<DayOfWeek, TimeSpan?, TimeSpan?>(DayOfWeek.Thursday, CetvrtakPocetakRadnogVremena, CetvrtakKrajRadnogVremena),
                    new Tuple<DayOfWeek, TimeSpan?, TimeSpan?>(DayOfWeek.Friday, PetakPocetakRadnogVremena, PetakKrajRadnogVremena),
                    new Tuple<DayOfWeek, TimeSpan?, TimeSpan?>(DayOfWeek.Saturday, SubotaPocetakRadnogVremena, SubotaKrajRadnogVremena),
                    new Tuple<DayOfWeek, TimeSpan?, TimeSpan?>(DayOfWeek.Sunday, NedeljaPocetakRadnogVremena, NedeljaKrajRadnogVremena)
                };
            }
        }
    }
}