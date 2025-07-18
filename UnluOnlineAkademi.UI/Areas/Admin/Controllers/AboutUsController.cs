using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditAboutUs()
        {
            return View();
        }
    }
}