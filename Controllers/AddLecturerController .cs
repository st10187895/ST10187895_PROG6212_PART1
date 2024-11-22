using Microsoft.AspNetCore.Mvc;
using ST10187895_PROG6212_PART1.Models;

namespace ST10187895_PROG6212_PART1.Controllers
{
    public class AddLecturerController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public AddLecturerController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public AddLecturerModel _lecturer = new AddLecturerModel();

        [HttpPost]


        public IActionResult AddLecturer(AddLecturerModel newLecturer)
        {
            AddLecturerModel _lecturer = newLecturer;


            var result = _lecturer.AddNewLecturer(newLecturer);

            return RedirectToAction("Index", "Home");
            
        }
    }
}
