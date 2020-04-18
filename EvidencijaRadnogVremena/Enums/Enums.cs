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

    public enum TipRadaEnum
    {
        [Description("Not working")]
        NeRadi,

        [Description("Working")]
        Radi,

        [Description("Holiday")]
        Odmor,

        [Description("Sick leave")]
        Bolovanje,

        [Description("Substitution")]
        Zamena,

        [Description("Break")]
        Pauza,

        [Description("Other")]
        Ostalo
    }
}