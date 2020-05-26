using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Enums
{
    public enum UlogaEnum
    {
        [Description("Radnik")]
        Radnik = 0,

        [Description("Menadžer marketa")]
        MenadzerMarketa = 1,

        [Description("Administrator")]
        Administrator = 2
    }

    public enum TipRadaEnum : byte
    {
        [Description("Not working")]
        NeRadi = 0,

        [Description("Working")]
        Radi = 1,

        [Description("Break")]
        Pauza = 2,
        
        [Description("Holiday")]
        Odmor = 3,

        [Description("Sick leave")]
        Bolovanje = 4,

        [Description("Other")]
        Ostalo = 99
    }
}