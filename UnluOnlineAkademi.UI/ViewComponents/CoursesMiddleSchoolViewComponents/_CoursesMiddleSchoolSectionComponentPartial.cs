using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.CoursesMiddleSchoolViewComponents
{
	public class _CoursesMiddleSchoolSectionComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			return View();
		}
	}
}
