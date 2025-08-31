using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UnluOnlineAkademi.UI.DTOs.AboutUsDto;
using UnluOnlineAkademi.UI.DTOs.HomeContactDto;

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


        [HttpGet]
        public async Task<IActionResult> GetMailList(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/MailList/{id}");

            if (!response.IsSuccessStatusCode)
                return BadRequest("Veri alınamadı");

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<GetHomeContactDto>(jsonData);

            return Json(new
            {
                name = data.Name,
                surname = data.Surname,
                emailAddress = data.EmailAddress,
                topic = data.Topic,
                message = data.Message
            });
        }


        [HttpGet]
        public async Task<IActionResult> AnswerMail(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/MailList/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<GetHomeContactDto>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        //[HttpPost]
        //public async Task<IActionResult> AnswerMail(Guid id)
        //{
        //    return View();
        //}



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
