using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ST10187895_PROG6212_PART1.Models;
using System.Diagnostics;

namespace ST10187895_PROG6212_PART1.Controllers
{
    public class ContractorLoginController : Controller
    {
        private readonly ContractorLoginModel Login;

        public ContractorLoginController()
        {
            Login = new ContractorLoginModel();
        }

        [HttpPost]
        public ActionResult ValidateUser(string personID, string password)
        {
            var loginModel = new ContractorLoginModel();
            string userID = loginModel.findUser(personID, password);
            if (userID != "-1")
            {
                // Store userID in session
                HttpContext.Session.SetString("UserID", userID);

                //HttpContext.Session.SetInt32("UserID", userID);


                return RedirectToAction("ReviewClaims", "Home");
            }
            else
            {
                // User not found, handle accordingly (e.g., show error message)
                return View("LoginFailed");
            }
        }
    }
}
