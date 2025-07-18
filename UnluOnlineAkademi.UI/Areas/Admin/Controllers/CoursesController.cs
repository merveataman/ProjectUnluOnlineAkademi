using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddCourseCategory()
        {
            return View();
        }
        public IActionResult EditCourseCategory()
        {
            return View();
        }
        public IActionResult AddLesson()
        {
            return View();
        }
        public IActionResult EditLesson()
        {
            return View();
        }
    }
}
