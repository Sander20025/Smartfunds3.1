
using Microsoft.AspNetCore.Mvc;
using SmartFunds.Model;
using SmartFunds.Services;

namespace SmartFunds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly OrganizationService _organizationService;

        public OrganizationsController(OrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        // /api/organizations/1
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var organization = _organizationService.Get(id);
            return Ok(organization);
        }

        // /api/organizations
        [HttpGet]
        public IActionResult Find()
        {
            var organizations = _organizationService.Find();
            return Ok(organizations);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Organization organization)
        {
            var createdOrganization = _organizationService.Create(organization);
            return Ok(createdOrganization);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int id, [FromBody] Organization organization)
        {
            var createdOrganization = _organizationService.Update(id, organization);
            return Ok(createdOrganization);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _organizationService.Delete(id);
            return Ok();
        }
    }
}
