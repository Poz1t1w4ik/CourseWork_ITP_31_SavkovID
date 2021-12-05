using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using StreetLighting.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace StreetLighting.Logics
{
    public static class StreetParts
    {
        public static IEnumerable<StreetPartViewModel> SelectVM(Context db)
        {
            return db.StreetParts.ToList().Select(x =>
            {
                return new StreetPartViewModel
                {
                    Id = x.Id,
                    StreetName = db.Streets.First(st => st.Id == x.StreetId).Name,
                    EndBuilding = x.EndBuilding,
                    StartBuilding = x.StartBuilding
                };
            }).ToList();
        }

        public static IEnumerable<StreetPartViewModel> SearchByStreetName(Context db, string search)
        {
            return SelectVM(db).Where(x => StringHandler.CompareStr(x.StreetName, search)).ToList();
        }

        public static string CheckStreetPart(StreetPart part, Context db)
        {
            if ((part.StartBuilding < 1) || (part.EndBuilding < 1))
            {
                return "В номерах домов доспутимы только положительные значения";
            }
            if (!db.Streets.Any(x => x.Id == part.StreetId))
            {
                return $"Не найдена улица с ID {part.StreetId}";
            }

            var streetInfo = db.Streets.First(x => x.Id == part.StreetId);
            if ((part.StartBuilding > streetInfo.BuildingCount) || (part.EndBuilding > streetInfo.BuildingCount))
            {
                return $"Номер дома превышает допустимый для данной улицы номер";
            }

            if (part.StartBuilding > part.EndBuilding)
            {
                return "Начальный номер не может быть больше конечного номера дома";
            }

            return null;
        }
    }
}
