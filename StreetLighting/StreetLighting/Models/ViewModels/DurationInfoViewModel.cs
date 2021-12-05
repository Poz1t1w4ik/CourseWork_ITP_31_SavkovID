using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StreetLighting.Models.ViewModels
{
    public class DurationInfoViewModel
    {
        [DisplayName("ID светильника")]
        public int LuminareId { get; set; }
        [DisplayName("Номер участка")]
        public int StreetPartId { get; set; }
        [DisplayName("Остаток срока службы")]
        public string Duration { get; set; }
        [DisplayName("Дата установки")]
        public DateTime SetupDate { get; set; }
    }
}
