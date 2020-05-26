using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace EvidencijaRadnogVremena.Models
{
    public class UpdateWorkerViewModel
    {
        [Key]
        public int RadnikId { get; set; }

        [DisplayName("Šifra radnika")]
        public string SifraRadnika { get; set; }

        [DisplayName("Ime i prezime")]
        public string ImePrezime { get; set; }

        public string Username { get; set; }

        [DisplayName("Šifra marketa")]
        public int? MarketId { get; set; }

        public virtual Market Market { get; set; }

        public int Argb
        {
            get { return Boja.ToArgb(); }
            set { Boja = Color.FromArgb(value); }
        }

        [NotMapped]
        public Color Boja { get; set; }

        public Enums.UlogaEnum Uloga { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool Pasivan { get; set; }
    }
}