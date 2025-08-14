using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluOnlineAkademi.UI.DTOs.HomeContactDto;
using UnluOnlineAkademi.UI.DTOs.WhyUsDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.ViewComponents.DashboardViewComponents
{
    public class _DashboardMailListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardMailListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("https://localhost:7287/api/MailList");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<CreateHomeContactDto>>(json);
            return View(list);
        }
    }
}
