using SmartFunds.Model;

namespace SmartFunds.Ui.Webapp.Sdk
{
    public class OrganizationSdk
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrganizationSdk(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Organization?> Get(int id)
        {
            var client = _httpClientFactory.CreateClient("SmartFundsApi");
            var route = $"api/organizations/{id}";
            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Organization>();
        }

        public async Task<IList<Organization>> Find()
        {
            var client = _httpClientFactory.CreateClient("SmartFundsApi");
            var route = "api/organizations";
            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var organizations = await response.Content.ReadFromJsonAsync<IList<Organization>>();
            if (organizations is null)
            {
                return new List<Organization>();
            }

            return organizations;
        }

        public async Task<Organization?> Create(Organization organization)
        {
            var client = _httpClientFactory.CreateClient("SmartFundsApi");
            var route = "api/organizations";
            var response = await client.PostAsJsonAsync(route, organization);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Organization>();
        }

        public async Task<Organization?> Update(int id, Organization organization)
        {
            var client = _httpClientFactory.CreateClient("SmartFundsApi");
            var route = $"api/organizations/{id}";
            var response = await client.PutAsJsonAsync(route, organization);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Organization>();
        }

        public async Task Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("SmartFundsApi");
            var route = $"api/organizations/{id}";
            var response = await client.DeleteAsync(route);

            response.EnsureSuccessStatusCode();
        }
    }
}
