using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SSSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddSSS()
        {
            return View();
        }
        public IActionResult EditSSS()
        {
            return View();
        }
    }
}