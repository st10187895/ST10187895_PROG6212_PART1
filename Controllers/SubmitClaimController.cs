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
        public SubmitClaimModel _submitClaim = new SubmitClaimModel();

        [HttpPost]

        
        public async Task<IActionResult> SubmitClaim(SubmitClaimModel submitClaim, IFormFile document)
        {
            SubmitClaimModel _submitClaim = submitClaim;

            if (ModelState.IsValid)
            {
                if (document == null || document.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                // Allowed file extensions
                string[] permittedExtensions = { ".pdf", ".txt", ".docx", ".xlsx" };
                var fileExtension = Path.GetExtension(document.FileName).ToLower();

                if (!permittedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("document", "Invalid file type. Only .pdf, .txt, .docx, and .xlsx files are allowed.");
                    return BadRequest(ModelState);
                }

               

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ClaimsDocuments");

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var filePath = Path.Combine(uploadPath, document.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await document.CopyToAsync(stream);
                }

                _submitClaim.documentPath = "/ClaimsDocuments/" + document.FileName;
            }
            else
            {
                return BadRequest(ModelState);
            }
            var result = _submitClaim.SubmitClaim(submitClaim);

            return RedirectToAction("Index", "Home");

        }
    }


}

