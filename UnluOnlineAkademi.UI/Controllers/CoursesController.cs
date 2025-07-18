using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MiddleSchoolCourses()
        {
            return View();
        }
        public IActionResult HighSchoolCourses()
        {
            return View();
        }
    }
}
