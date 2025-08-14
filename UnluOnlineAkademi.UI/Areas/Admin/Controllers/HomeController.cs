using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UnluOnlineAkademi.UI.DTOs.AchievementsDto;
using UnluOnlineAkademi.UI.DTOs.HomeHeaderDto;
using UnluOnlineAkademi.UI.DTOs.StudentTestimonialDto;
using UnluOnlineAkademi.UI.DTOs.WhyUsDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditHeader(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/Header/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateHomeHeaderDto>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHeader(UpdateHomeHeaderDto dto, IFormFile? imageFile)
        {
            dto.Status = true;
            dto.Date = DateTime.Now;

            // Yeni görsel seçilmişse
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/headers");

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Yeni görselin yolunu ata
                dto.CoverImage = "/uploads/headers/" + fileName;
            }
            else
            {
                // Eski görsel yolunu çekmek için API'den veri getir
                var clientGet = httpClientFactory.CreateClient();
                var existingResponse = await clientGet.GetAsync($"https://localhost:7287/api/Header/{dto.ID}");
                if (existingResponse.IsSuccessStatusCode)
                {
                    var existingJson = await existingResponse.Content.ReadAsStringAsync();
                    var existingDto = JsonConvert.DeserializeObject<UpdateHomeHeaderDto>(existingJson);

                    dto.CoverImage = existingDto?.CoverImage; // Eski değer korunur
                }
            }

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7287/api/Header/{dto.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Header başarıyla güncellendi.";
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            TempData["Error"] = "Güncelleme sırasında bir hata oluştu.";
            return View(dto);
        }


        [HttpGet]
        public async Task<IActionResult> EditWhyUs(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/WhyUs/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateWhyUsDto>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWhyUs(UpdateWhyUsDto dto)
        {
            dto.Status = true;
            dto.Date = DateTime.Now;

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7287/api/WhyUs/{dto.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Neden Ünlü Online Akademi bilgisi başarıyla güncellendi.";
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            TempData["Error"] = "Güncelleme sırasında bir hata oluştu.";
            return View(dto);
        }


        public IActionResult EditEducationalContents()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddStudentTestimonials()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentTestimonials(CreateStudentTestimonialDto dto)
        {
            var client = httpClientFactory.CreateClient();
            dto.Status = true;
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7287/api/StudentTestimonial", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(dto);
        }

      
        [HttpGet]
        public async Task<IActionResult> EditStudentTestimonials(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/StudentTestimonial/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateStudentTestimonial>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStudentTestimonials(UpdateStudentTestimonial dto)
        {
            dto.Status = true;

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7287/api/StudentTestimonial/{dto.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            TempData["Error"] = "Güncelleme sırasında bir hata oluştu.";
            return View(dto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudentTestimonials(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7287/api/StudentTestimonial/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View();
        }
       
        [HttpGet]
        public async Task<IActionResult> EditAchievements(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/Achievements/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateAchievementsDto>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAchievements(UpdateAchievementsDto dto)
        {
            dto.Status = true;

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7287/api/Achievements/{dto.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            TempData["Error"] = "Güncelleme sırasında bir hata oluştu.";
            return View(dto);
        }
    }
}