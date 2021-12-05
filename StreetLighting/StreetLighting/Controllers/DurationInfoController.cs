using Microsoft.AspNetCore.Mvc;
using StreetLighting.Models.Db;
using StreetLighting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StreetLighting.Logics.Lamps;

namespace StreetLighting.Controllers
{
    public class DurationInfoController : Controller
    {
        private readonly Context db;
        private static IEnumerable<DurationInfoViewModel> ress;

        public DurationInfoController(Context context)
        {
            db = context;
        }

        public IActionResult SearchResult(IEnumerable<DurationInfoViewModel> lamps)
        {
            return View(ress);
        }

        public IActionResult Search(SearchLuminareViewModel res)
        {
            ress = FindByDuration(res.Start, res.End, db, res.StreetName);
            return RedirectToAction("SearchResult", new { luminares = ress.AsEnumerable() });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
