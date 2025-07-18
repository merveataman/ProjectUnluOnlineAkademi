using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.HomeViewComponents
{
    public class _HomeWhyUsSectionComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View();
        }
    }
}
