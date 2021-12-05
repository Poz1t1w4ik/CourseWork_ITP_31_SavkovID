using System;
using System.ComponentModel;

namespace StreetLighting.Models.ViewModels
{
    public class SiteLightingViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Тип светильника")]
        public string LuminareType { get; set; }
        [DisplayName("Количество светильников")]
        public int LuminareCount { get; set; }
        [DisplayName("Дата выхода из строя")]
        public DateTime LastDate { get; set; }
        [DisplayName("ID участка")]
        public int StreetPartId { get; set; }
    }
}
