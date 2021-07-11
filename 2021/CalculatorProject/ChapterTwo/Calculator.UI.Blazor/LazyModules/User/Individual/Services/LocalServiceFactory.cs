using Calculator.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IndividualUserModule.Services
{
    public class LocalServiceFactory
    {
        private HttpClient _httpClient;
        public LocalServiceFactory()
        {
            this._httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5016/api/") };
        }
        public async Task<Calculator.Models.Individual> GetIndividualAsync()
        {
            var response = await _httpClient.GetAsync("/individual");
            response.EnsureSuccessStatusCode();
            _httpClient.Dispose();

            return await response.Content.ReadFromJsonAsync<Individual>();
        }
    }
}
