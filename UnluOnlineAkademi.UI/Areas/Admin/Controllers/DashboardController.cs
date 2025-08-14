using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AnswerMail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMailList(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7287/api/MailList/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            return View();
        }
    }
}
