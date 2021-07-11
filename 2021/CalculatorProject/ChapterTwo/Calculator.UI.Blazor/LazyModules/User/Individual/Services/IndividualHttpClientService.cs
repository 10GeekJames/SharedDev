using Calculator.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace IndividualUserModule.Services
{
    public class IndividualHttpClientService
    {
        private HttpClient _httpClient;
        public IndividualHttpClientService()
        {
            
        }
        public async Task<Calculator.Models.Individual> GetIndividualAsync()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient { BaseAddress = HttpClientShared.BaseAddress };
            }
            var response = await _httpClient.GetAsync("individual");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Individual>();
        }
    }
}
