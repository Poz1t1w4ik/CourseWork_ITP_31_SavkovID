using System;
using System.ComponentModel;

namespace StreetLighting.Models.Entities
{
    public class SiteLighting
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID светильника")]
        public int LuminareId { get; set; }
        [DisplayName("Количество светильников")]
        public int LuminareCount { get; set; }
        [DisplayName("Дата выхода из строя")]
        public DateTime LastDate { get; set; }
        [DisplayName("ID участка")]
        public int StreetPartId { get; set; }
    }
}
