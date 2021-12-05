using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using StreetLighting.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace StreetLighting.Logics
{
    public class SiteLightings
    {
        public static string CheckSite(SiteLighting site, Context db)
        {
            if (!db.Luminares.Any(x => x.Id == site.LuminareId))
            {
                return "Не найден светильник с ID " + site.LuminareId;
            }
            if (!db.StreetParts.Any(x => x.Id == site.StreetPartId))
            {
                return "Не найден участок с ID " + site.StreetPartId;
            }
            if ((site.LuminareCount <= 0) || (site.LuminareCount >= 1000))
            {
                return "Неверное количество светильников";
            }
            return null;
        }

        public static IEnumerable<SiteLightingViewModel> SelectVM(Context context, string lumType)
        {
            return SelectVM(context).Where(x => StringHandler.CompareStr(x.LuminareType, lumType));
        }

        public static IEnumerable<SiteLightingViewModel> SelectVM(Context context)
        {
            return context.SiteLightings.ToList().Select(x => new SiteLightingViewModel()
            {
                Id = x.Id,
                LastDate = x.LastDate,
                LuminareCount = x.LuminareCount,
                LuminareType = context.Luminares.First(l => l.Id == x.LuminareId).Type,
                StreetPartId = x.StreetPartId
            });
        }
    }
}
