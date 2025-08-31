using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsTop6List;

namespace UnluOnlineAkademi.UI.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}