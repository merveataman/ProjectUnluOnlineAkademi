using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddContact()
        {
            return View();
        }
        public IActionResult EditContact()
        {
            return View();
        }
        public IActionResult AddContactType()
        {
            return View();
        }
        public IActionResult EditContactType()
        {
            return View();
        }
    }
}
