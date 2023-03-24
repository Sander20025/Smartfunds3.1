using SmartFunds.Model;

namespace SmartFunds.Ui.Webapp.Sdk
{
    public class TransactionSdk
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TransactionSdk(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Transaction?> Get(int id)
        {
            var client = _httpClientFactory.CreateClient("SmartFundsApi");
            var route = $"api/transactions/{id}";
            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Transaction>();
        }

        public async Task<IList<Transaction>> Find(int? organizationId)
        {
            var client = _httpClientFactory.CreateClient("SmartFundsApi");
            var route = "api/transactions";
            if (organizationId.HasValue)
            {
                route = $"api/transactions/{organizationId}";
            }

            var response = await client.GetAsync(route);

            response.EnsureSuccessStatusCode();

            var transactions = await response.Content.ReadFromJsonAsync<IList<Transaction>>();
            if (transactions is null)
            {
                return new List<Transaction>();
            }

            return transactions;
        }

        public async Task<Transaction?> Create(Transaction transaction)
        {
            var client = _httpClientFactory.CreateClient("SmartFundsApi");
            var route = "api/transactions";
            var response = await client.PostAsJsonAsync(route, transaction);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Transaction>();
        }

        public async Task Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("SmartFundsApi");
            var route = $"api/transactions/{id}";
            var response = await client.DeleteAsync(route);

            response.EnsureSuccessStatusCode();
        }
    }
}
