using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

using Calculator.UI.Blazor.Infrastructure;
using Calculator.UI.Blazor.Services;
using Calculator.UI.Blazor.Shared;

/*using LazyServices;

*/

namespace Calculator.UI.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

            //builder.Services.AddScoped<Calculator2CharacterValidator>();

            builder.Services.AddScoped<CalculatorStateService>();

            builder.Services.AddHttpClient<WeatherForecastHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5016");
            }).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<ActiveUserDataHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5016");
            }).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<ActiveBusinessDataHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5016");
            });

            builder.Services.AddHttpClient<Calculator.UI.Blazor.Modules.IndividualUser.Services.IndividualHttpClientService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5016/api/");
            });

            builder.Services.AddHttpClient<Calculator.UI.Blazor.Modules.CalculatorModule.Services.CalculatorHttpClientService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5016/api/");
            });


            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                options.ProviderOptions.Authority = "https://localhost:5001";
                options.ProviderOptions.ClientId = "Calculator.UI.Blazor-client";
                options.ProviderOptions.ResponseType = "code";

                //options.ProviderOptions.DefaultScopes.Add("weather.read");

                options.UserOptions.RoleClaim = "role";
            }).AddAccountClaimsPrincipalFactory<AccountClaimsPrincipalFactoryEx>();

            builder.Services.AddAuthorizationCore(config =>
            {
                config.AddPolicy("edit-access",
                    new AuthorizationPolicyBuilder().
                        RequireAuthenticatedUser().
                        RequireClaim("role", "Editor").
                        Build()
                    );

                config.AddPolicy("delete-access",
                    new AuthorizationPolicyBuilder().
                        RequireAuthenticatedUser().
                        RequireRole("Admin").
                        Build()
                    );

                config.AddPolicy("participant",
                    new AuthorizationPolicyBuilder().
                        RequireAuthenticatedUser().
                        RequireClaim("role", "Participant").
                        Build()
                    );
            });

            // add in our lazy mod bootstrapper
            // builder.Services.AddLazyHttpClientServices();
            // builder.Services.AddScoped<LazyServiceFactory>();
            //builder.Services.LazyHttpClientServices();
            // builder.Services.AddLazyHttpClientServices();
            // builder.Services.AddScoped<LazyServiceFactory>();

            // add in some telerik blazor
            builder.Services.AddTelerikBlazor();

            // smash in all the resx files
            builder.Services.AddLocalization();

            // setup our logging provider
            builder.Logging.ClearProviders();
            builder.Logging.AddConfiguration(
                builder.Configuration.GetSection("Logging")
            );

            // wire in our localization strategy
            List<CultureInfo> supportedLanguages = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("fr-FR"),
                new CultureInfo("ja"),
                new CultureInfo("ta")
            };
            var jsInterop = builder.Build().Services.GetRequiredService<IJSRuntime>();
            var appLanguage = await jsInterop.InvokeAsync<string>("appCulture.get");
            if (appLanguage != null)
            {
                if (supportedLanguages.Count(rs => rs.Name == appLanguage) > 0)
                {
                    CultureInfo cultureInfo = new CultureInfo(appLanguage);
                    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
                }
            }

            builder.Services.AddAutoMapper(typeof(Calculator.Models.Mappings.DomainToViewModelMappingProfileGen));

            await builder.Build().RunAsync();
        }
    }
}
