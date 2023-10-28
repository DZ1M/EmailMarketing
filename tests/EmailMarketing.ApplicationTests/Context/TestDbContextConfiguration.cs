using EmailMarketing.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMarketing.ApplicationTests.Context
{
    public class TestDbContextConfiguration
    {
        private readonly DbContextOptions<EmailMarketingContext> _options;

        public TestDbContextConfiguration()
        {
            // Configure o banco de dados em memória aqui
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            _options = new DbContextOptionsBuilder<EmailMarketingContext>()
                .UseNpgsql(configuration.GetConnectionString("TestDatabaseConnection"))
                .Options;

            Context = new TestDbContext(_options);
            Context.Database.EnsureCreated();
        }
        public EmailMarketingContext Context { get; }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
