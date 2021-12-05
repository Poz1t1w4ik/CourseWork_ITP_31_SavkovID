using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using StreetLighting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StreetLighting.Logics
{
    public static class Lamps
    {
        private static bool CheckDate(DateTime start, DateTime end, DateTime target)
        {
            return (target >= start) && (target <= end);
        }

        public static IEnumerable<DurationInfoViewModel> FindByDuration(DateTime start,
                                                                        DateTime end,
                                                                        Context db,
                                                                        string streetname)
        {
            List<Street> streets;
            if (streetname == null)
            {
                streets = db.Streets.ToList();
            }
            else
            {
                streets = db.Streets.ToList().Where(x => StringHandler.CompareStr(x.Name, streetname)).ToList();
            }

            var sites = db.SiteLightings.ToList().Where(x => CheckDate(start, end, x.LastDate)).ToList();

            return sites.Select(x =>
            {
                var lum = db.Luminares.ToList().First(l => l.Id == x.LuminareId);
                var lamp = db.Lamps.ToList().First(l => l.Id == lum.LampId);
                return new DurationInfoViewModel()
                {
                    LuminareId = x.LuminareId,
                    Duration = GetDuration(x.LastDate, lamp.Duration, db),
                    SetupDate = x.LastDate.AddYears(-lamp.Duration),
                    StreetPartId = x.StreetPartId
                };
            }).ToList();
        }

        private static string GetDuration(DateTime target, int duration, Context db)
        {
            var curDur = DateTime.Now.Year - target.Year;
            if (curDur >= 0)
            {
                return $"Просрочено на {curDur} лет";
            }
            else
            {
                return $"Осталось {curDur * -1} лет";
            }
        }

        public static IEnumerable<LampInfoViewModel> Find(string street, Context db)
        {
            List<Street> streets;
            if (street == null)
            {
                streets = db.Streets.ToList();
            }
            else
            {
                streets = db.Streets.ToList().Where(s => StringHandler.CompareStr(s.Name, street)).ToList();
            }
            
            var streetparts = db.StreetParts.ToList().Where(p => streets.Any(s => s.Id == p.StreetId)).ToList();

            var sites = db.SiteLightings.ToList().Where(x => streetparts.Any(s => s.Id == x.StreetPartId)).ToList()
                .Select(z =>
                {
                    var part = streetparts.First(x => x.Id == z.StreetPartId);
                    return new
                    {
                        part.StreetId,
                        z.LuminareId,
                    };
                }).ToList().Select(x =>
                {
                    return new
                    {
                        x.StreetId,
                        x.LuminareId,
                        db.Luminares.ToList().First(l => l.Id == x.LuminareId).LampId
                    };
                }).ToList().Select(x =>
                {
                    return new
                    {
                        StreetName = streets.First(s => s.Id == x.StreetId).Name,
                        x.LuminareId,
                        Lamp = db.Lamps.ToList().First(l => l.Id == x.LampId)
                    };
                }).ToList();
            return sites.ToList().Select(x => new LampInfoViewModel()
            {
                Id = x.Lamp.Id,
                Duration = x.Lamp.Duration,
                LuminareId = x.LuminareId,
                Power = x.Lamp.Power,
                StreetName = x.StreetName,
                Type = x.Lamp.Type
            }).ToList();
        }

        public static string CheckLamp(Lamp lamp)
        {
            if (lamp.Duration <= 0)
            {
                return "Срок службы должен быть положительным";
            }
            if (lamp.Duration > 100)
            {
                return "Слишком большой срок службы";
            }
            if (lamp.Power <= 0)
            {
                return "Мощность должна быть положительной";
            }
            if (lamp.Power >= 2000)
            {
                return "Слишком большая мощность";
            }
            if (lamp.Type == null)
            {
                return "Тип не может быть пустым";
            }

            return null;
        }

        public static IEnumerable<Lamp> GetLampByType(string type, Context db)
        {
            return db.Lamps.ToList().Where(x => StringHandler.CompareStr(x.Type, type)).ToList();
        }
    }
}
