using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluOnlineAkademi.UI.DTOs.PoliciesDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.ViewComponents.PolicyViewComponents
{
    public class _PolicyListComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _PolicyListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("https://localhost:7287/api/Policies");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<PoliciesByIdDto>>(json);
            return View(list);
        }
    }
}