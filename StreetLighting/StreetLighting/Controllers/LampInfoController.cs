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
    public class LampInfoController : Controller
    {
        private readonly Context db;
        private static IEnumerable<LampInfoViewModel> ress;

        public LampInfoController(Context context)
        {
            db = context;
        }

        public IActionResult SearchResult(IEnumerable<LampInfoViewModel> lamps)
        {
            return View(ress);
        }

        public IActionResult Search(SearchLuminareViewModel res)
        {
            ress = Find(res.StreetName, db);
            return RedirectToAction("SearchResult", new { luminares = ress.AsEnumerable() });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
