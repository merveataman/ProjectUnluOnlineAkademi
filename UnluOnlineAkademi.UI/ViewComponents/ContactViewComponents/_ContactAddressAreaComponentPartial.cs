using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.ContactViewComponents
{
	public class _ContactAddressAreaComponentPartial:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			return View();
		}
	}
}
