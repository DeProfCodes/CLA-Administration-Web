using CLA_Administration_Web.Models;
using CLACommonFunctionsLibrary_NET.Models.WebApi;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace CLA_Administration_Web.Services.API
{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;

        public ApiService()
        {
            var UAT_LINK = "https://nthdimensionwebservicev8uat.corporatevoice.co.za/NTH_V8_API_UAT_CLADataAccess_Admin/";
            var LIVE_LINK = "https://nthdimensionwebservicev8.corporatevoice.co.za/CLADataAccessWebAPI/";

            httpClient = new HttpClient
            {
                BaseAddress = new Uri(LIVE_LINK)
            };

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<bool> AuthorizeLoggedInUser()
        {
            try
            {
                string endpoint = "UserAuthentication/api/auth/LoginToAPI";

                var parameters = new Dictionary<string, object>
                {
                    { "Username", "nprof" }
                };

                var apiModel = new ApiModel
                {
                    Parameters = parameters,
                    ConnectToLive = false
                };

                string result = await HttpPostAsync(endpoint, apiModel);

                var data = JsonConvert.DeserializeObject<GenericResult>(result);

                if (data.Success)
                {
                    string token = data.Message;

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception if needed
            }

            return false;
        }

        private async Task<string> HttpGet(string endpoint)
        {
            HttpResponseMessage response = await httpClient.GetAsync(endpoint);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("401 Unauthorized: Access is denied due to invalid credentials.");
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> HttpGetAsync(string endpoint)
        {
            try
            {
                return await HttpGet(endpoint);
            }
            catch (UnauthorizedAccessException ex)
            {
                var reAuth = await AuthorizeLoggedInUser();
                if (reAuth)
                {
                    return await HttpGet(endpoint);
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> HttpPostAsync(string apiEndPoint, object payloadObject)
        {
            try
            {
                var jsonPayload = JsonConvert.SerializeObject(payloadObject);
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                Task<HttpResponseMessage> responseTask = null;

                HttpResponseMessage response = await httpClient.PostAsync(apiEndPoint, httpContent);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (UnauthorizedAccessException ex)
            {
                throw;
            }
            catch
            {
                // Handle other exceptions as necessary
            }
            return null;
        }
    }
}
