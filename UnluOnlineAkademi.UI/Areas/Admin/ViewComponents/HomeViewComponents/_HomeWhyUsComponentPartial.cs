using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.ViewComponents.HomeViewComponents
{
    public class _HomeWhyUsComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View();
        }
    }
}
