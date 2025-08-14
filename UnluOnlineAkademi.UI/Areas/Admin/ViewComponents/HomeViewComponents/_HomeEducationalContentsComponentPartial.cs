using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluOnlineAkademi.UI.DTOs.EducationalContentDto;
using UnluOnlineAkademi.UI.DTOs.WhyUsDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.ViewComponents.HomeViewComponents
{
    public class _HomeEducationalContentsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HomeEducationalContentsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("https://localhost:7287/api/EducationalContent");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<EducationalContentListDto>>(json);
            return View(list);
        }
    }
}