using System.ComponentModel;

namespace StreetLighting.Models.Entities
{
    public class StreetPart
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("ID улицы")]
        public int StreetId { get; set; }
        [DisplayName("Начальное здание")]
        public int StartBuilding { get; set; }
        [DisplayName("Конечное здание")]
        public int EndBuilding { get; set; }
    }
}
