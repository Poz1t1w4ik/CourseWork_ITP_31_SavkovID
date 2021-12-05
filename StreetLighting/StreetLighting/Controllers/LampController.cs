using Microsoft.AspNetCore.Mvc;
using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using System;
using System.Linq;
using static StreetLighting.Logics.Lamps;

namespace StreetLighting.Controllers
{
    public class LampController : Controller
    {
        private readonly Context db;

        public LampController(Context context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = db.Lamps.First(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Lamp item)
        {
            string check = CheckLamp(item);
            if (ModelState.IsValid && (check == null))
            {
                try
                {
                    db.Lamps.Update(item);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Index");
            }

            HomeController.ErrorItem.RequestId = check;
            return RedirectToAction("ErrorIndex", "Home");
        }

        [HttpPost]
        public IActionResult Delete(Lamp item)
        {
            if (ModelState.IsValid)
            {
                var lums = db.Luminares.ToList().Where(x => x.LampId == item.Id);
                db.SiteLightings.ToList().Where(x => lums.Any(l => l.Id == x.LuminareId))
                    .ToList().ForEach(x => db.SiteLightings.Remove(x));
                lums.ToList().ForEach(x => db.Luminares.Remove(x));
                db.Lamps.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mark = db.Lamps.First(org => org.Id == id);
            return View(mark);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search == null)
            {
                return View(db.Lamps.ToList());
            }
            var list = GetLampByType(search, db);
            return View(list);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.Lamps.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lamp item)
        {
            var error = CheckLamp(item);
            if (ModelState.IsValid && (error == null))
            {
                try
                {
                    db.Lamps.Add(item);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Index");
            }

            HomeController.ErrorItem.RequestId = error;
            return RedirectToAction("ErrorIndex", "Home");
        }
    }
}
