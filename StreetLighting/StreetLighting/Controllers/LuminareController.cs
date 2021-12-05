using Microsoft.AspNetCore.Mvc;
using StreetLighting.Models.Db;
using StreetLighting.Models.Entities;
using System;
using System.Linq;
using static StreetLighting.Logics.Luminaries;

namespace StreetLighting.Controllers
{
    public class LuminareController : Controller
    {
        private readonly Context db;

        public LuminareController(Context context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = db.Luminares.First(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Luminare item)
        {
            string check = CheckLuminare(item, db);
            if (ModelState.IsValid && (check == null))
            {
                try
                {
                    db.Luminares.Update(item);
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
        public IActionResult Delete(Luminare item)
        {
            if (ModelState.IsValid)
            {
                db.SiteLightings.ToList().Where(x => x.LuminareId == item.Id)
                    .ToList().ForEach(x => db.SiteLightings.Remove(x));
                db.Luminares.ToList().ForEach(x => db.Luminares.Remove(x));
                db.Luminares.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mark = db.Luminares.First(org => org.Id == id);
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
        public IActionResult Create(Luminare item)
        {
            var error = CheckLuminare(item, db);
            if (ModelState.IsValid && (error == null))
            {
                try
                {
                    db.Luminares.Add(item);
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
