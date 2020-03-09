using System.ComponentModel;

namespace Enums
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
        Neradi,
        Radi,
        Odmor,
        Bolovanje,
        Zamena,
        Ostalo
    }
}