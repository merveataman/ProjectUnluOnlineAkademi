using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UnluOnlineAkademi.UI.DTOs.AchievementsDto;
using UnluOnlineAkademi.UI.DTOs.CourseCategoryDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CoursesController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseCategory(CreateCourseCategoryDto dto)
        {
            var client = httpClientFactory.CreateClient();
            dto.Status = true;
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7287/api/CourseCategory", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Courses", new { area = "Admin" });
            }
            return View(dto);
        }


        [HttpGet]
        public async Task<IActionResult> EditCourseCategory(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7287/api/CourseCategory/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index"); // veya hata mesajı göster

            var jsonData = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UpdateCourseCategoryDto>(jsonData);
            return View(data); // tek bir kayıt döndürülmeli
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCourseCategory(UpdateCourseCategoryDto dto)
        {
            dto.Status = true;

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7287/api/CourseCategory/{dto.ID}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Courses", new { area = "Admin" });
            }

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCourseCategory(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7287/api/CourseCategory/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Courses", new { area = "Admin" });
            }

            return View();
        }
        public IActionResult AddLesson()
        {
            return View();
        }
        public IActionResult EditLesson()
        {
            return View();
        }
    }
}
