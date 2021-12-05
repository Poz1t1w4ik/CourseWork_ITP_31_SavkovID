using Microsoft.AspNetCore.Mvc;
using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using System;
using System.Linq;
using static StreetLighting.Logics.SiteLightings;

namespace StreetLighting.Controllers
{
    public class SiteLightingController : Controller
    {
        private readonly Context db;

        public SiteLightingController(Context context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = db.SiteLightings.First(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(SiteLighting item)
        {
            string check = CheckSite(item, db);
            if (ModelState.IsValid && (check == null))
            {
                try
                {
                    db.SiteLightings.Update(item);
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
        public IActionResult Delete(SiteLighting item)
        {
            if (ModelState.IsValid)
            {
                db.SiteLightings.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mark = db.SiteLightings.First(org => org.Id == id);
            return View(mark);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search == null)
            {
                return View(SelectVM(db));
            }
            var list = SelectVM(db, search);
            return View(list);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(SelectVM(db));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SiteLighting item)
        {
            var error = CheckSite(item, db);
            if (ModelState.IsValid && (error == null))
            {
                try
                {
                    var lum = db.Luminares.First(x => x.Id == item.LuminareId);

                    item.LastDate = DateTime.Now.AddYears(db.Lamps.First(x => x.Id == lum.LampId).Duration);
                    db.SiteLightings.Add(item);
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
