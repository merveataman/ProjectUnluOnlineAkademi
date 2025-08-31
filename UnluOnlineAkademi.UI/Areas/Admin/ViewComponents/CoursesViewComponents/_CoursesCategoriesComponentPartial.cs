using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluOnlineAkademi.UI.DTOs.CourseCategoryDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.ViewComponents.CoursesViewComponents
{
    public class _CoursesCategoriesComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CoursesCategoriesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("https://localhost:7287/api/CourseCategory");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<CourseCategoryDto>>(json);
            return View(list);
        }
    }
}
