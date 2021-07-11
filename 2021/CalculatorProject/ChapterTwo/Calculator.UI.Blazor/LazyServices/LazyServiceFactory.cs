using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;
using IndividualUserModule.Services;

namespace LazyServices
{
    public partial class LazyServiceFactory
    {
        private readonly IServiceProvider services;

        public LazyServiceFactory(IServiceProvider services)
        {
            this.services = services;
        }

        public IndividualHttpClientService GetIndividualHttpClientService()
        {
            /* HttpClient http = this.services.GetRequiredService<HttpClient>();             */
            return new IndividualHttpClientService();
        }
    }
}