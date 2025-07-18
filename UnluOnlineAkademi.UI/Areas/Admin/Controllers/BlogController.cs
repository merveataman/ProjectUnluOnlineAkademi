using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBlog()
        {
            return View();
        }
        public IActionResult EditBlog()
        {
            return View();
        }
    }
}
