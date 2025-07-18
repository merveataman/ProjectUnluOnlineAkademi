using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KVKK()
        {
            return View();
        }
        public IActionResult CookiePolicy()
        {
            return View();
        }
        public IActionResult InformationSecurityPolicy()
        {
            return View();
        }
    }
}