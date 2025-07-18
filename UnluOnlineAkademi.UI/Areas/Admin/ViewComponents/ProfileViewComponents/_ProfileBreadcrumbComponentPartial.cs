using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.Areas.Admin.ViewComponents.ProfileViewComponents
{
    public class _ProfileBreadcrumbComponentPartial: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
