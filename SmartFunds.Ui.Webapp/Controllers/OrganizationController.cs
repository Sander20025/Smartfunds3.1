using Microsoft.AspNetCore.Mvc;
using SmartFunds.Model;
using SmartFunds.Ui.Webapp.Sdk;

namespace SmartFunds.Ui.Webapp.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly OrganizationSdk _organizationSdk;

        public OrganizationController(OrganizationSdk organizationSdk)
        {
            _organizationSdk = organizationSdk;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var organizations = await _organizationSdk.Find();

            return View(organizations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return View(organization);
            }

            await _organizationSdk.Create(organization);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var organization = await _organizationSdk.Get(id);

            if (organization is null)
            {
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return View(organization);
            }

            await _organizationSdk.Update(id, organization);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var organization = await _organizationSdk.Get(id);

            if (organization is null)
            {
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        [HttpPost("[controller]/Delete/{id:int?}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _organizationSdk.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
