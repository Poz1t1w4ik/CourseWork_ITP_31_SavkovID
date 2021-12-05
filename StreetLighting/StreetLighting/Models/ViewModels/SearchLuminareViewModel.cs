using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StreetLighting.Models.ViewModels
{
    public class SearchLuminareViewModel
    {
        [DisplayName("Название улицы")]
        public string StreetName { get; set; }
        [DisplayName("Начало")]
        public DateTime Start { get; set; }
        [DisplayName("Конец")]
        public DateTime End { get; set; }
    }
}
