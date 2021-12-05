using Microsoft.AspNetCore.Mvc;
using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using System;
using System.Linq;
using static StreetLighting.Logics.Streets;

namespace StreetLighting.Controllers
{
    public class StreetController : Controller
    {
        private readonly Context db;

        public StreetController(Context context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = db.Streets.First(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Street item)
        {
            string check = CheckStreet(item, db);
            if (ModelState.IsValid && (check == null))
            {
                try
                {
                    db.Streets.Update(item);
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
        public IActionResult Delete(Street item)
        {
            if (ModelState.IsValid)
            {
                var parts = db.StreetParts.ToList().Where(x => x.StreetId == item.Id);
                db.SiteLightings.ToList().Where(x => parts.Any(p => p.Id == x.StreetPartId))
                    .ToList().ForEach(x => db.SiteLightings.Remove(x));
                parts.ToList().ForEach(x => db.StreetParts.Remove(x));
                db.Streets.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mark = db.Streets.First(org => org.Id == id);
            return View(mark);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search == null)
            {
                return View(db.Streets.ToList());
            }
            var list = SearchByName(search, db);
            return View(list);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.Streets.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Street item)
        {
            var error = CheckStreet(item, db);
            if (ModelState.IsValid && (error == null))
            {
                try
                {
                    db.Streets.Add(item);
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
