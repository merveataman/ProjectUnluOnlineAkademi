using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
