using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.SenderMail.API.Configuration
{
    public static class DbMigrationHelpers
    {
        /// <summary>
        /// Generate migrations before running this method, you can use command bellow:
        /// Nuget package manager: Add-Migration DbInit -context CustomerContext
        /// Dotnet CLI: dotnet ef migrations add DbInit -c CustomerContext
        /// </summary>
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var ssoContext = scope.ServiceProvider.GetRequiredService<EmailMarketing.SenderMail.Infra.Context.EmailMarketingContext>();
            await EmailMarketing.Architecture.WebApi.Core.Configuration.DbHealthChecker.TestConnection(ssoContext);

            await ssoContext.Database.MigrateAsync();

            await ssoContext.Database.EnsureCreatedAsync();

        }

    }
}
