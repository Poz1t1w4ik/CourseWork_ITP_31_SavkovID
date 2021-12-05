using Microsoft.AspNetCore.Mvc;
using StreetLighting.Models.Db;
using StreetLighting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StreetLighting.Logics.Streets;

namespace StreetLighting.Controllers
{
    public class LuminareInfoController : Controller
    {
        private readonly Context db;
        private static IEnumerable<LuminareViewModel> ress;

        public LuminareInfoController(Context context)
        {
            db = context;
        }

        public IActionResult SearchResult(IEnumerable<LuminareViewModel> luminares)
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
