using DAL.EntityFramework.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace DAL.EntityFramework.Tests.Integration.Tests
{
    public partial class TestBase
    {
        private readonly TestServer server;

        protected readonly IServiceProvider Services;
        protected readonly IEFDatabaseContext DataContext;

        public TestBase()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            this.Services = this.server.Host.Services;
            this.DataContext = this.Services.GetService<IEFDatabaseContext>();
        }

        [OneTimeSetUp]
        public void TestInitialise()
        {
            this.DataContext.Database.EnsureCreated();
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            this.DataContext.Database.EnsureDeleted();
        }
    }
}
