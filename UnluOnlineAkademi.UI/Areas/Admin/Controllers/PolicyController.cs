using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UnluOnlineAkademi.UI.DTOs.ContactDto;
using UnluOnlineAkademi.UI.DTOs.PoliciesDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PolicyController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public PolicyController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPolicy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditPolicy(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/Policies/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdatePoliciesDto>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPolicy(UpdatePoliciesDto dto)
        {
            dto.Status = true;

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7287/api/Policies/{dto.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Policy", new { area = "Admin" });
            }

            return View(dto);
        }
    }
}
