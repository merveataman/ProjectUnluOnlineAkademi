using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UnluOnlineAkademi.UI.DTOs.ContactDto;
using UnluOnlineAkademi.UI.DTOs.SSSDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
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
        [HttpGet]
        public IActionResult AddContactType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContactType(CreateContactOptionDto dto)
        {
            var client = httpClientFactory.CreateClient();
            dto.Status = true;
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7287/api/ContactOptions", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Contact", new { area = "Admin" });
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> EditContactType(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/ContactOptions/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateContactOptionDto>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditContactType(UpdateContactOptionDto dto)
        {
            dto.Status = true;

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7287/api/ContactOptions/{dto.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Contact", new { area = "Admin" });
            }

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContactType(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7287/api/ContactOptions/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Contact", new { area = "Admin" });
            }

            return View();
        }
    }
}