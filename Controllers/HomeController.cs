using Microsoft.AspNetCore.Mvc;
using ST10187895_PROG6212_PART1.Models;
using System.Diagnostics;

namespace ST10187895_PROG6212_PART1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ClaimHours()
        {
            return View();
        }

        public IActionResult ReviewClaims()
        {
            return View();
        }

        public IActionResult PendingClaims()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
