using Calculator.Models;
using Calculator.Models.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Calculator.UI.Blazor.Services
{
    public class ActiveBusinessDataHttpClient
    {
        public HttpClient _httpClient;
        public ActiveBusinessDataHttpClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<ActiveBusinessDataVM> GetAsync()
        {
            var response = await _httpClient.GetAsync("/api/ActiveBusinessData");
            response.EnsureSuccessStatusCode();

            var rs = await response.Content.ReadFromJsonAsync<ActiveBusinessDataVM>();
            return rs;
        }
    }
}
