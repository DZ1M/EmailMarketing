using EmailMarketing.API;
using EmailMarketing.IntegrationTests.Fixture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace EmailMarketing.IntegrationTests.Factories
{
    [Collection("Database")]
    public class IntegrationFactory : WebApplicationFactory<Startup>
    {
        private readonly DbFixture _dbFixture;

        public IntegrationFactory(DbFixture dbFixture)
        {
            _dbFixture = dbFixture;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");

            builder.ConfigureServices(services =>
            {

            });

            builder.ConfigureAppConfiguration((context, configuration) =>
            {
                configuration.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>("ConnectionStrings::EmailMarketingDb", _dbFixture.ConnectionString),
                });
            });
        }
    }
}
