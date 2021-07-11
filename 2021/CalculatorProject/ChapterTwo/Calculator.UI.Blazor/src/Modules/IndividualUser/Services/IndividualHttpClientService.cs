using Calculator.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace Calculator.UI.Blazor.Modules.IndividualUser.Services
{
    public class IndividualHttpClientService
    {
        private HttpClient _httpClient;
        public IndividualHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Calculator.Models.Individual> GetIndividualAsync()
        {
            var response = await _httpClient.GetAsync("individual");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Individual>();
        }
    }
}
