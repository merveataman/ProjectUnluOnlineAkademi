using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UnluOnlineAkademi.UI.DTOs.HomeContactDto;

namespace UnluOnlineAkademi.UI.Controllers
{
	public class HomeController : Controller
	{
        private readonly IHttpClientFactory httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Index(CreateHomeContactDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7287/api/MailList", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
