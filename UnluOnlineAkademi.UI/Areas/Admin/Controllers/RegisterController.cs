using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
