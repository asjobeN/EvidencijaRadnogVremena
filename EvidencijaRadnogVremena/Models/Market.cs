using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        [NotMapped]
        [Display(Name = "Ponedeljak")]
        public string PonedeljakRadnoVreme { get { return $"{PonedeljakPocetakRadnogVremena.ToString(@"hh\:mm")} - {PonedeljakKrajRadnogVremena.ToString(@"hh\:mm")}"; } }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan UtorakPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan UtorakKrajRadnogVremena { get; set; }

        [NotMapped]
        [Display(Name = "Utorak")]
        public string UtorakRadnoVreme { get { return $"{UtorakPocetakRadnogVremena.ToString(@"hh\:mm")} - {UtorakKrajRadnogVremena.ToString(@"hh\:mm")}"; } }

        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan SredaPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan SredaKrajRadnogVremena { get; set; }

        [NotMapped]
        [Display(Name = "Sreda")]
        public string SredaRadnoVreme { get { return $"{SredaPocetakRadnogVremena.ToString(@"hh\:mm")} - {SredaKrajRadnogVremena.ToString(@"hh\:mm")}"; } }

        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan CetvrtakPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan CetvrtakKrajRadnogVremena { get; set; }

        [NotMapped]
        [Display(Name = "Četvrtak")]
        public string CetvrtakRadnoVreme { get { return $"{CetvrtakPocetakRadnogVremena.ToString(@"hh\:mm")} - {CetvrtakKrajRadnogVremena.ToString(@"hh\:mm")}"; } }

        [Required(ErrorMessage = "Nedostaje pоčetak radnog vremena")]
        public TimeSpan PetakPocetakRadnogVremena { get; set; }

        [Required(ErrorMessage = "Nedostaje kraj radnog vremena")]
        public TimeSpan PetakKrajRadnogVremena { get; set; }

        [NotMapped]
        [Display(Name = "Petak")]
        public string PetakRadnoVreme { get { return $"{PetakPocetakRadnogVremena.ToString(@"hh\:mm")} - {PetakKrajRadnogVremena.ToString(@"hh\:mm")}"; } }

        public TimeSpan? SubotaPocetakRadnogVremena { get; set; }

        public TimeSpan? SubotaKrajRadnogVremena { get; set; }

        [NotMapped]
        [Display(Name = "Subota")]
        public string SubotaRadnoVreme
        {
            get
            {
                return $"{(SubotaPocetakRadnogVremena.HasValue ? SubotaPocetakRadnogVremena.Value.ToString(@"hh\:mm") : string.Empty)} - " +
                        $"{(SubotaKrajRadnogVremena.HasValue ? SubotaKrajRadnogVremena.Value.ToString(@"hh\:mm") : string.Empty)}";
            }
        }

        public TimeSpan? NedeljaPocetakRadnogVremena { get; set; }

        public TimeSpan? NedeljaKrajRadnogVremena { get; set; }

        [NotMapped]
        [Display(Name = "Nedelja")]
        public string NedeljaRadnoVreme
        {
            get
            {
                return $"{(NedeljaPocetakRadnogVremena.HasValue ? NedeljaPocetakRadnogVremena.Value.ToString(@"hh\:mm") : string.Empty)} - " +
                        $"{(NedeljaKrajRadnogVremena.HasValue ? NedeljaKrajRadnogVremena.Value.ToString(@"hh\:mm") : string.Empty)}";
            }
        }

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