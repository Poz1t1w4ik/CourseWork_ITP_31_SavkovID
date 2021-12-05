using System.ComponentModel;

namespace StreetLighting.Models.ViewModels
{
    public class StreetPartViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Название улицы")]
        public string StreetName { get; set; }
        [DisplayName("Начальное здание")]
        public int StartBuilding { get; set; }
        [DisplayName("Конечное здание")]
        public int EndBuilding { get; set; }
    }
}
