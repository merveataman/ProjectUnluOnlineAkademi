using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.CoursesHighSchoolViewComponent
{
    public class _CoursesHighSchoolPageNavigationComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View();
        }
    }
}
