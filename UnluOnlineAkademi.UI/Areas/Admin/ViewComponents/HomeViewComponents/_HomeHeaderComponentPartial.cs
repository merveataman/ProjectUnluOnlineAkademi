using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UnluOnlineAkademi.UI.DTOs.HomeHeaderDto;

namespace UnluOnlineAkademi.UI.Areas.Admin.ViewComponents.HomeViewComponents
{
    public class _HomeHeaderComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HomeHeaderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("https://localhost:7287/api/Header");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<HomeHeaderDto>>(json);
            return View(list);
        }
    }
}