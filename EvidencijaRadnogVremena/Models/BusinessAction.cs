using EvidencijaRadnogVremena.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class BusinessAction
    {
        [Key]
        public int BusinessActionId { get; set; }
        public DateTime Date { get; set; }
        public int RadnikId { get; set; }
        [ForeignKey("RadnikId")]
        public virtual Radnik Radnik { get; set; }
        public TipRadaEnum TipRada { get; set; }
        public string LocalMachine { get; set; }
    }
}