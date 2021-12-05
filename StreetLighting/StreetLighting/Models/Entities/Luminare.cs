using System.ComponentModel;

namespace StreetLighting.Models.Entities
{
    public class Luminare
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Тип")]
        public string Type { get; set; }
        [DisplayName("ID лампы")]
        public int LampId { get; set; }
    }
}
