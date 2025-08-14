using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluOnlineAkademi.UI.DTOs.WhyUsDto;

namespace UnluOnlineAkademi.UI.ViewComponents.AboutUsViewComponents
{
	public class _AboutUsWhyUsComponentPartial:ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsWhyUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("https://localhost:7287/api/WhyUs/last-six");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<WhyUsListDto>>(json);
            return View(list);
        }
	}
}
