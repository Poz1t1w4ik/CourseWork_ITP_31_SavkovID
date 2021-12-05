using System.ComponentModel;

namespace StreetLighting.Models.Entities
{
    public class Street
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Количество домов на улице")]
        public int BuildingCount { get; set; }
    }
}
