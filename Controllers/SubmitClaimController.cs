using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ST10187895_PROG6212_PART1.Models;
using System.Data.Entity;
using System.Diagnostics;
using System.Security.Claims;

namespace ST10187895_PROG6212_PART1.Controllers
{
    public class SubmitClaimController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public SubmitClaimController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public SubmitClaimModel submitClaim = new SubmitClaimModel();

        [HttpPost]

        //public ActionResult SubmitClaim(SubmitClaimModel claim)
        //{
        //    string userID = HttpContext.Session.GetString("userID");

        //    var result = submitClaim.SubmitClaim(claim);

        //    return RedirectToAction("Index", "Home");
             
        //}
        public async Task<IActionResult> SubmitClaim(SubmitClaimModel submitClaim, IFormFile document)
        {
            if (ModelState.IsValid)
            {

                // Check if a file is uploaded
                if (document != null && document.Length > 0)
                {
                    // Allowed file extensions
                    string[] permittedExtensions = { ".pdf", ".txt", ".docx", ".xlsx" };
                    var fileExtension = Path.GetExtension(document.FileName).ToLower();

                    if (permittedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError($"document", "Invalid file type. Only .pdf, .txt, .docx, and .xlsx files are allowed.");
                    }
                    return BadRequest("No file uploaded.");
                }

                //// Check the file size (10 MB limit)
                //long maxSize = 10 * 1024 * 1024; // 10 MB in bytes
                //if (document.Length > maxSize)
                //{
                //    return BadRequest("File size exceeds the 10 MB limit.");
                //}

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ClaimsDocuments");
                // Ensure the folder exists
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }


                //Save the file
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await document.CopyToAsync(stream);
                }

                //return RedirectToAction("Index", "Home");
            }
            submitClaim.documentPath = "/ClaimDocuments/" + document.FileName;

            var result = submitClaim.SubmitClaim(submitClaim);

            return RedirectToAction("Index", "Home");

        }
    }


}

