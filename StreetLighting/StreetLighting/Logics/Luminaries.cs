using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using StreetLighting.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace StreetLighting.Logics
{
    public static class Luminaries
    {
        public static string CheckLuminare(Luminare item, Context db)
        {
            if (item.Type == null)
            {
                return "Тип не может быть пустым";
            }
            if (!db.Lamps.Any(x => x.Id == item.LampId))
            {
                return $"Не найдена лампа с ID {item.LampId}";
            }

            return null;
        }

        public static IEnumerable<LuminareViewModel> SelectVM(Context db, string lampType)
        {
            return SelectVM(db).Where(x => StringHandler.CompareStr(x.LampType, lampType));
        }

        public static IEnumerable<LuminareViewModel> SelectVM(Context db)
        {
            return db.Luminares.ToList().Select(x => new LuminareViewModel()
            {
                Id = x.Id,
                LampType = db.Lamps.First(l => l.Id == x.LampId).Type,
                Type = x.Type
            });
        }
    }
}
