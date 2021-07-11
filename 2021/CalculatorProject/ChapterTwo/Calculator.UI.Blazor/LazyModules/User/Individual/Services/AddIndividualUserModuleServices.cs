using Microsoft.Extensions.DependencyInjection;
using IndividualUserModule.Services;
using System;
using Microsoft.AspNetCore;
using System.Net.Http;

namespace IndividualUserModule.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddIndividualUserModuleServices(this IServiceCollection services)
        {
            services.AddScoped<IndividualHttpClientService>();
            return services;
        }
    }
}