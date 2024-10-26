namespace CLA_Administration_Web.Services.API
{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://nthdimensionwebservicev8uat.corporatevoice.co.za/NTH_V8_API_UAT_CLADataAccess_Admin/")
            };

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<string> HttpGetAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(endpoint);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
    }
}
