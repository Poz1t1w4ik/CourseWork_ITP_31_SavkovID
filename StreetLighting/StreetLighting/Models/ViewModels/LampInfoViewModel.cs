using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StreetLighting.Models.ViewModels
{
    public class LampInfoViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Тип")]
        public string Type { get; set; }
        [DisplayName("Мощность")]
        public int Power { get; set; }
        [DisplayName("Срок службы (лет)")]
        public int Duration { get; set; }
        [DisplayName("ID светильника")]
        public int LuminareId { get; set; }
        [DisplayName("Название улицы")]
        public string StreetName { get; set; }
    }
}
