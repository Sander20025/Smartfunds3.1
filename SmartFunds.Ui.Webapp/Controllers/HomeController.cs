using Microsoft.AspNetCore.Mvc;
using SmartFunds.Ui.Webapp.Sdk;

namespace SmartFunds.Ui.Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrganizationSdk _organizationSdk;


        public HomeController(OrganizationSdk organizationSdk)
        {
            _organizationSdk = organizationSdk;
        }
        public async Task<IActionResult> Index()
        {
            var organizations = await _organizationSdk.Find();
            return View(organizations);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}