using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluOnlineAkademi.UI.DTOs.SSSDto;
using UnluOnlineAkademi.UI.DTOs.WhyUsDto;

namespace UnluOnlineAkademi.UI.ViewComponents.SSSViewComponents
{
	public class _SSSSectionComponentPartial: ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _SSSSectionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("https://localhost:7287/api/SSS");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<SSSListDto>>(json);
            return View(list);
        }
	}
}
