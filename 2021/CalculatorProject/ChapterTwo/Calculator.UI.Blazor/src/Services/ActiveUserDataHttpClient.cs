using Calculator.Models;
using Calculator.Models.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
namespace Calculator.UI.Blazor.Services
{
    public class ActiveUserDataHttpClient
    {
        public HttpClient _httpClient;
        public ActiveUserDataHttpClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<ActiveUserDataVM> GetAsync()
        {
            var response = await _httpClient.GetAsync("/api/ActiveUserData");
            response.EnsureSuccessStatusCode();

            var rs = await response.Content.ReadFromJsonAsync<ActiveUserDataVM>();

            return rs;
        }
    }
}
