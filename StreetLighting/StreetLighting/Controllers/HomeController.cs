using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StreetLighting.Models;
using System.Diagnostics;

namespace StreetLighting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static ErrorViewModel ErrorItem { get; set; } = new() { RequestId = string.Empty };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LuminareInfo()
        {
            return RedirectToAction("Index", "LuminareInfo");
        }

        public IActionResult LampInfo()
        {
            return RedirectToAction("Index", "LampInfo");
        }
        public IActionResult DurationInfo()
        {
            return RedirectToAction("Index", "DurationInfo");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ErrorIndex()
        {
            return View(ErrorItem);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
