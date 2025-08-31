using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UnluOnlineAkademi.UI.DTOs.AboutUsDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AboutUsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> EditAboutUs(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/AboutUs/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateAboutUsDto>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAboutUs(UpdateAboutUsDto dto, IFormFile? imageFile)
        {
            dto.Status = true;

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/aboutus");

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                dto.Image = "/uploads/aboutus/" + fileName;
            }
            else
            {
                var clientGet = httpClientFactory.CreateClient();
                var existingResponse = await clientGet.GetAsync($"https://localhost:7287/api/AboutUs/{dto.ID}");
                if (existingResponse.IsSuccessStatusCode)
                {
                    var existingJson = await existingResponse.Content.ReadAsStringAsync();
                    var existingDto = JsonConvert.DeserializeObject<UpdateAboutUsDto>(existingJson);

                    dto.Image = existingDto?.Image; 
                }
            }
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7287/api/AboutUs/{dto.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AboutUs", new { area = "Admin" });
            }
            return View(dto);
        }
    }
}