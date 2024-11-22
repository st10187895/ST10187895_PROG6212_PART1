using Microsoft.AspNetCore.Mvc;
using ST10187895_PROG6212_PART1.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ST10187895_PROG6212_PART1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
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
            List<ReviewClaimsModel> history = ReviewClaimsModel.Previous_Claims();
            ViewData["ReviewClaims"] = history;
            return View(); ;
        }

        public IActionResult PendingClaims()
        {
            List<ReviewClaimsModel> pending = ReviewClaimsModel.Pending_Claims();
            ViewData["PendingClaims"] = pending;
            return View();
        }

        public IActionResult ManagerView()
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
