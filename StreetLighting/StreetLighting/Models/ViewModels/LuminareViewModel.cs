using System.ComponentModel;

namespace StreetLighting.Models.ViewModels
{
    public class LuminareViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Тип")]
        public string Type { get; set; }
        [DisplayName("Тип лампы")]
        public string LampType { get; set; }
    }
}
