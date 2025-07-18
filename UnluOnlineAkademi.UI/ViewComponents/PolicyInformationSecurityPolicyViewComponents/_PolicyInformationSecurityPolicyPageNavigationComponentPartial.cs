using Microsoft.AspNetCore.Mvc;

namespace UnluOnlineAkademi.UI.ViewComponents.PolicyInformationSecurityPolicyViewComponents
{
    public class _PolicyInformationSecurityPolicyPageNavigationComponentPartial: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View();
        }
    }
}
