using Microsoft.AspNetCore.Mvc;
using ST10187895_PROG6212_PART1.Models;
using ST10187895_PROG6212_PART1.Services;
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
        private readonly InvoiceCreator _invoiceCreator;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _invoiceCreator = new InvoiceCreator();
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

        public IActionResult HumanResources()
        {
            return View();
        }
        public IActionResult UpdateDetails()
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

        public IActionResult ApprovedClaims()
        {
            List<ReviewClaimsModel> approved = ReviewClaimsModel.Approved_Claims();
            ViewData["ReviewClaims"] = approved;
            return View(); ;
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
        [HttpGet]
        public IActionResult DownloadInvoice(int claimID)
        {
            // Fetch the claim from the database
            var claim = ReviewClaimsModel.GetClaimByID(claimID); // Replace with your data-fetching logic

            if (claim == null)
            {
                return NotFound("Claim not found.");
            }

            // Generate the PDF
            var pdf = _invoiceCreator.GenerateInvoice(claim);

            // Return the PDF as a downloadable file
            return File(pdf, "application/pdf", $"Invoice_{claimID}.pdf");
        }

    }
}
