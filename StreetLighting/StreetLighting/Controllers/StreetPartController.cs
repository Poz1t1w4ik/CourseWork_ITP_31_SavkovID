using Microsoft.AspNetCore.Mvc;
using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using System;
using System.Linq;
using static StreetLighting.Logics.StreetParts;

namespace StreetLighting.Controllers
{
    public class StreetPartController : Controller
    {
        private readonly Context db;

        public StreetPartController(Context context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = db.StreetParts.First(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(StreetPart item)
        {
            string check = CheckStreetPart(item, db);
            if (ModelState.IsValid && (check == null))
            {
                try
                {
                    db.StreetParts.Update(item);
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
        public IActionResult Delete(StreetPart item)
        {
            if (ModelState.IsValid)
            {
                db.SiteLightings.ToList().Where(x => x.StreetPartId == item.Id)
                    .ToList().ForEach(x => db.SiteLightings.Remove(x));
                db.StreetParts.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mark = db.StreetParts.First(org => org.Id == id);
            return View(mark);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search == null)
            {
                return View(SelectVM(db));
            }
            var list = SearchByStreetName(db, search);
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
        public IActionResult Create(StreetPart item)
        {
            var error = CheckStreetPart(item, db);
            if (ModelState.IsValid && (error == null))
            {
                try
                {
                    db.StreetParts.Add(item);
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
