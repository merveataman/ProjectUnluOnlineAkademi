using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UnluOnlineAkademi.UI.DTOs.ContactDto;

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
        public IActionResult EditContactType()
        {
            return View();
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