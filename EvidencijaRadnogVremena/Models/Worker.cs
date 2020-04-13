using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace EvidencijaRadnogVremena.Models
{
    public class Worker
    {
        [Key]
        public int RadnikId { get; set; }

        [DisplayName("Šifra radnika")]
        public string SifraRadnika { get; set; }

        [DisplayName("Ime i prezime")]
        public string ImePrezime { get; set; }

        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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