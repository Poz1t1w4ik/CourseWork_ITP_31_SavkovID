using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using StreetLighting.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace StreetLighting.Logics
{
    public static class Streets
    {
        public static IEnumerable<LuminareViewModel> Find(string streetName, Context db)
        {
            List<Street> streets;
            if (streetName == null)
            {
                streets = db.Streets.ToList();
            }
            else
            {
                streets = db.Streets.ToList().Where(s => StringHandler.CompareStr(s.Name, streetName)).ToList();
            }
            
            var streetParts = db.StreetParts.ToList().Where(x => streets.Any(s => s.Id == x.StreetId));

            var sites = db.SiteLightings.ToList().Where(x => streetParts.Any(p => p.Id == x.StreetPartId));
            return Luminaries.SelectVM(db).ToList().Where(x => sites.Any(s => s.LuminareId == x.Id));
        }

        public static string CheckStreet(Street street, Context context)
        {
            if ((street.BuildingCount <= 0) || (street.BuildingCount >= 500))
            {
                return "Неверное количество зданий";
            }
            if (street.Name == null)
            {
                return "Неверное название улицы";
            }
            return null;
        }

        public static IEnumerable<Street> SearchByName(string name, Context context)
        {
            return context.Streets.ToList().Where(x => StringHandler.CompareStr(x.Name, name));
        }
    }
}
