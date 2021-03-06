using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyExchangerApp.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using MoneyExchangerApp.Services.Interfaces;
using MoneyExchangerApp.Services.Services;
using MoneyExchangerApp.Repositories.Interfaces;
using MoneyExchangerApp.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace MoneyExchangerApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Exchange Api"
                });
            });
            services.AddDbContext<CurrencyExchangerDbContext>(options =>
                                      options.UseSqlServer(
                                          Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://127.0.0.1:5500");
                                  });
            });

            services.AddScoped<IExchangeService, ExchangeService>();
            services.AddScoped<IExchangeRepository, ExchangeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exchange Api V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                                .RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
