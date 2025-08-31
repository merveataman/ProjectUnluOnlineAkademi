using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UnluOnlineAkademi.UI.DTOs.CourseCategoryDto;
using UnluOnlineAkademi.UI.DTOs.SSSDto;
using UnluOnlineAkademi.UI.DTOs.StudentTestimonialDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SSSController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public SSSController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddSSS()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSSS(CreateSSSDto dto)
        {
            var client = httpClientFactory.CreateClient();
            dto.Status = true;
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7287/api/SSS", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SSS", new { area = "Admin" });
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> EditSSS(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/SSS/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateSSSDto>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSSS(UpdateSSSDto dto)
        {
            dto.Status = true;

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7287/api/SSS/{dto.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SSS", new { area = "Admin" });
            }

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSSS(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7287/api/SSS/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SSS", new { area = "Admin" });
            }

            return View();
        }
    }
}