using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.ViewComponents.AboutUsViewComponents
{
    public class _AboutUsListComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View();
        }
    }
}
