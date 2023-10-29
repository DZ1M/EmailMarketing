using EmailMarketing.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmailMarketing.IntegrationTests.Fixture
{
    public class DbFixture : IDisposable
    {
        private readonly EmailMarketingContext _context;
        public readonly string DatabaseName = $"Context-{Guid.NewGuid()}";
        public readonly string ConnectionString;
        private bool _disposed;

        public DbFixture()
        {          
            var builderConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builderConfig.Build();

            ConnectionString = configuration.GetConnectionString("TestDatabaseConnection")
                .Replace("test_emailmarketing_db", DatabaseName);
           
            var builder = new DbContextOptionsBuilder<EmailMarketingContext>();
            builder.UseNpgsql(ConnectionString);

            _context = new EmailMarketingContext(builder.Options);

            _context.Database.Migrate();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if(disposing){
                    _context.Database.EnsureDeleted();
                }
                _disposed = true;
            }
        }
    }
}
