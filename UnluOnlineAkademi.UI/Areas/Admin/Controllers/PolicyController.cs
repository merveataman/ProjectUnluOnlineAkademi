using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPolicy()
        {
            return View();
        }
        public IActionResult EditPolicy()
        {
            return View();
        }
    }
}
