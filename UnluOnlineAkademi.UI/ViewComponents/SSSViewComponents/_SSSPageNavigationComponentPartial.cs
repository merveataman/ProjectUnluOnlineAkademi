using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.SSSViewComponents
{
    public class _SSSPageNavigationComponentPartial: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View();
        }
    }
}
