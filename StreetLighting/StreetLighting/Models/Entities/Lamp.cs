using System.ComponentModel;

namespace StreetLighting.Models.Entities
{
    public class Lamp
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Тип")]
        public string Type { get; set; }
        [DisplayName("Мощность")]
        public int Power { get; set; }
        [DisplayName("Срок службы (лет)")]
        public int Duration { get; set; }
    }
}
