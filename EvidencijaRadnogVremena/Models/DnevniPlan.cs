using EvidencijaRadnogVremena.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvidencijaRadnogVremena.Models
{
    public class DnevniPlan
    {
        public int DnevniPlanId { get; set; }

        public DateTime Datum { get; set; }

        [DisplayName("Nedelja")]
        public int NedeljniPlanId { get; set; }

        public virtual NedeljniPlan NedeljniPlan { get; set; }

        public int RadnikId { get; set; }

        public int IdZamenskogRadnika { get; set; }

        public DateTime? PlaniranPocetakRada { get; set; }

        public DateTime? PlaniranKrajRada { get; set; }

        [NotMapped]
        public string PeriodRada { get; set; }

        public DateTime? PlaniranPocetakPauze { get; set; }

        public DateTime? PlaniranKrajPauze { get; set; }

        [NotMapped]
        public string PeriodPauze { get; set; }

        [Display(Name = "07:30-08:00"), Index(Order = 1)]
        public TipRadaEnum RV_0730_0800 { get; set; }

        [Display(Name = "08:00-08:30"), Index(Order = 2)]
        public TipRadaEnum RV_0800_0830 { get; set; }

        [Display(Name = "08:30-09:00"), Index(Order = 3)]
        public TipRadaEnum RV_0830_0900 { get; set; }

        [Display(Name = "09:00-09:30"), Index(Order = 4)]
        public TipRadaEnum RV_0900_0930 { get; set; }

        [Display(Name = "09:30-10:00"), Index(Order = 5)]
        public TipRadaEnum RV_0930_1000 { get; set; }

        [Display(Name = "10:00-10:30"), Index(Order = 6)]
        public TipRadaEnum RV_1000_1030 { get; set; }

        [Display(Name = "10:30-11:00"), Index(Order = 7)]
        public TipRadaEnum RV_1030_1100 { get; set; }

        [Display(Name = "11:00-11:30"), Index(Order = 8)]
        public TipRadaEnum RV_1100_1130 { get; set; }

        [Display(Name = "11:30-12:00"), Index(Order = 9)]
        public TipRadaEnum RV_1130_1200 { get; set; }

        [Display(Name = "12:00-12:30"), Index(Order = 10)]
        public TipRadaEnum RV_1200_1230 { get; set; }

        [Display(Name = "12:30-13:00"), Index(Order = 11)]
        public TipRadaEnum RV_1230_1300 { get; set; }

        [Display(Name = "13:00-13:30"), Index(Order = 12)]
        public TipRadaEnum RV_1300_1330 { get; set; }

        [Display(Name = "13:30-14:00"), Index(Order = 13)]
        public TipRadaEnum RV_1330_1400 { get; set; }

        [Display(Name = "14:00-14:30"), Index(Order = 14)]
        public TipRadaEnum RV_1400_1430 { get; set; }

        [Display(Name = "14:30-15:00"), Index(Order = 15)]
        public TipRadaEnum RV_1430_1500 { get; set; }

        [Display(Name = "15:00-15:30"), Index(Order = 16)]
        public TipRadaEnum RV_1500_1530 { get; set; }

        [Display(Name = "15:30-16:00"), Index(Order = 17)]
        public TipRadaEnum RV_1530_1600 { get; set; }

        [Display(Name = "16:00-16:30"), Index(Order = 18)]
        public TipRadaEnum RV_1600_1630 { get; set; }

        [Display(Name = "16:30-17:00"), Index(Order = 19)]
        public TipRadaEnum RV_1630_1700 { get; set; }

        [Display(Name = "17:00-17:30"), Index(Order = 20)]
        public TipRadaEnum RV_1700_1730 { get; set; }

        [Display(Name = "17:30-18:00"), Index(Order = 21)]
        public TipRadaEnum RV_1730_1800 { get; set; }

        [Display(Name = "18:00-18:30"), Index(Order = 22)]
        public TipRadaEnum RV_1800_1830 { get; set; }

        [Display(Name = "18:30-19:00"), Index(Order = 23)]
        public TipRadaEnum RV_1830_1900 { get; set; }

        [Display(Name = "19:00-19:30"), Index(Order = 24)]
        public TipRadaEnum RV_1900_1930 { get; set; }

        [Display(Name = "19:30-20:00"), Index(Order = 25)]
        public TipRadaEnum RV_1930_2000 { get; set; }

        [Display(Name = "20:00-20:30"), Index(Order = 26)]
        public TipRadaEnum RV_2000_2030 { get; set; }

        [Display(Name = "20:30-21:00"), Index(Order = 27)]
        public TipRadaEnum RV_2030_2100 { get; set; }

        [Display(Name = "21:00-21:30"), Index(Order = 28)]
        public TipRadaEnum RV_2100_2130 { get; set; }

        //public virtual OstvareniRad OstvarniRad { get; set; }
        public TipRadaEnum this[string propertyName]
        {
            get
            {
                Type myType = typeof(DnevniPlan);
                System.Reflection.PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                var value = (TipRadaEnum)myPropInfo.GetValue(this, null);
                return value;
            }
            set
            {
                Type myType = typeof(DnevniPlan);
                System.Reflection.PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);
            }
        }

        [NotMapped]
        public float BrojSati
        {
            get
            {
                var properties = GetType().GetProperties().Where(prop => prop.PropertyType.Name.Equals("TipRadaEnum") && prop.Name.StartsWith("RV"));
                var values = properties.Select(x => x.GetValue(this, null));
                var count = values.Count(val => val.Equals(TipRadaEnum.Radi));
                return 0.5f * count;
            }
        }
    }
}