using DAL.Base.Infrastructure;
using DAL.EntityFramework.Infrastructure;
using DAL.EntityFramework.Tests.Integration.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.EntityFramework.Tests.Integration
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestDataContext>(
                options => options.UseSqlServer(this.config.GetConnectionString("TestConnectionString")),
                ServiceLifetime.Singleton);

            services.AddScoped<IEFDatabaseContext>(provider => provider.GetService<TestDataContext>());
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
