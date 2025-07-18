using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.AboutUsViewComponents
{
	public class _AboutUsWhyUsComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			return View();
		}
	}
}
