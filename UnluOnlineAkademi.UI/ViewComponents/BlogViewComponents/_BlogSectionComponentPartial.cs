using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.BlogViewComponents
{
	public class _BlogSectionComponentPartial: ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			return View();
		}
	}
}
