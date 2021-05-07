using MediatR;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PI.Interview.Repository;
using PI.Interview.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace P1.Interview.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:45952") });

            builder.Services.AddScoped<IPortfolioService, PortfolioService>();
            builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();

            builder.Services.AddMediatR(typeof(Program));

            await builder.Build().RunAsync();
        }
    }
}
