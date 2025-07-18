using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.ContactViewComponents
{
	public class _ContactContactAreaComponentPartial: ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			return View();
		}
	}
}
