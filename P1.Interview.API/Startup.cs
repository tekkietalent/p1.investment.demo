using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PI.Interview.Services;
using PI.Interview.Repository;
using P1.Interview.Infrastructure;
using System;
using P1.Interview.Infrastructure.Services;

namespace P1.Interview.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "P1.Interview.API", Version = "v1" });
            });

            services.AddCors();

            services.AddSingleton<IPortfolioService, PortfolioService>();
            services.AddSingleton<IPortfolioRepository, PortfolioRepository>();

            var secclAuthOptions = Configuration.GetSection("SecclAuth").Get<AuthRequest>();

            services.AddSingleton<ISecclTokenProvider>(new SecclTokenProvider(secclAuthOptions));

            services.AddHttpClient<ISecclHttpClient, SecclHttpClient>(h =>
            {
                h.BaseAddress = new Uri("https://pfolio-api-staging.seccl.tech/");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "P1.Interview.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
