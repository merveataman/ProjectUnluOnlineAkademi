using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluOnlineAkademi.Domain.Entities;
using UnluOnlineAkademi.UI.DTOs.EducationalContentDto;

namespace UnluOnlineAkademi.UI.ViewComponents.HomeViewComponents
{
    public class _HomeEducationalContentSectionComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeEducationalContentSectionComponentPartial(IHttpClientFactory httpClientFactory)
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
