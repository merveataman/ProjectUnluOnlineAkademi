using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.HomeViewComponents
{
    public class _HomeCoursesSectionComponentPartial: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View();
        }
    }
}
