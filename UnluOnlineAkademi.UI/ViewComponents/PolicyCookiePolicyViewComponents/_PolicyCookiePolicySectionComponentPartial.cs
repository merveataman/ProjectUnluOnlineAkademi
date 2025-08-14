using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnluOnlineAkademi.UI.DTOs.PoliciesDto;

namespace UnluOnlineAkademi.UI.ViewComponents.PolicyCookiePolicyViewComponents
{
    public class _PolicyCookiePolicySectionComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PolicyCookiePolicySectionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync($"https://localhost:7287/api/Policies/{id}");
            if (!response.IsSuccessStatusCode)
                return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<PoliciesByIdDto>(json);
            return View(dto);
        }
    }
}
