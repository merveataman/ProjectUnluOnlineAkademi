using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditHeader()
        {
            return View();
        }
        public IActionResult EditWhyUs()
        {
            return View();
        }
        public IActionResult EditEducationalContents()
        {
            return View();
        }
        public IActionResult AddStudentTestimonials()
        {
            return View();
        }
        public IActionResult EditStudentTestimonials()
        {
            return View();
        }
        public IActionResult EditAchievements()
        {
            return View();
        }
    }   
}