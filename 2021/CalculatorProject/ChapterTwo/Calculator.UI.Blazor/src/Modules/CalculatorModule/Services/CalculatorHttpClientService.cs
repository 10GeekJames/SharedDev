using Calculator.Models;
using Calculator.Models.RequestResponse;
using Calculator.Models.Enums;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator.UI.Blazor.Modules.CalculatorModule.Services
{
    public class CalculatorHttpClientService
    {
        private HttpClient _httpClient;
        public CalculatorHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> DoAction(CalculatorDoActionBehaviorRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("calculator/doaction", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

