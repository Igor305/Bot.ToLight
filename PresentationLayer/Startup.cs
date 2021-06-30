using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.EFRepositories.NetMonitoring;
using DataAccessLayer.Repositories.EFRepositories.Shops;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PresentationLayer
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
            services.AddLogging();
            services.AddDbContext<NetMonitoringContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:SQL08"]));
            services.AddDbContext<ShopsContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:SQL26"]));
            services.AddMemoryCache();
            services.AddScoped<IMonitoringRepository, MonitoringRepository>();
            services.AddScoped<IShopsRepository, ShopsRepository>();
            services.AddScoped<IShopWorkTimesRepository, ShopWorkTimesRepository>();
            services.AddScoped<IBotService, BotService>();
            services.AddHostedService<TimedHostedService>();
            services.AddHostedService<ConsumeScopedServiceHostedService>();
            services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
