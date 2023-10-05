using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Infra.Context
{
    public class EmailMarketingContext : DbContext
    {
        public EmailMarketingContext(DbContextOptions<EmailMarketingContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("unaccent");
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmailMarketingContext).Assembly);
        }

        [DbFunction("unaccent")]
        public string Unaccent()
        {
            throw new NotSupportedException();
        }
    }
}
