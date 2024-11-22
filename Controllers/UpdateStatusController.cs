using Microsoft.AspNetCore.Mvc;
using ST10187895_PROG6212_PART1.Models;
using System.Data.Entity;


namespace ST10187895_PROG6212_PART1.Controllers
{
    public class UpdateStatusController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public UpdateStatusController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public ManageClaimsModel _update = new ManageClaimsModel();

        [HttpPost]
        
        //public async Task<IActionResult> UpdateClaim(ManageClaimsModel update)
        //{
        //    ManageClaimsModel _update = update;

        //    var result = _update.UpdateClaim(update);

        //    return RedirectToAction("ReviewClaims", "Home");
        //}

        [HttpPost]
        public IActionResult UpdateClaimStatus([FromBody] UpdateClaimRequest request)
        {
            try
            {
                // Create an instance of the model and update the claim status
                var model = new ManageClaimsModel();

                bool success = model.UpdateClaim(request.ClaimID, request.action);

                if (success)
                    return Ok(new { message = "Claim status updated successfully." });
                else
                    return NotFound(new { message = "Failed to update claim status. Claim may not exist." });
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                return StatusCode(500, new { message = "An error occurred.", error = ex.Message });
            }
        }

        public class UpdateClaimRequest
        {
            public int ClaimID { get; set; }
            public string action { get; set; }
        }
    }
}
