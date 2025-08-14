using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UnluOnlineAkademi.UI.DTOs.AboutUsDto;

namespace UnluOnlineAkademi.UI.ViewComponents.AboutUsViewComponents
{
	public class _AboutUsSectionComponentPartial:ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsSectionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("https://localhost:7287/api/AboutUs");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<AboutUsByIdDto>>(json);
            return View(list);
        }
	}
}