using EmailMarketing.SenderMail.Domain.Interfaces;
using EmailMarketing.SenderMail.Infra.Context;
using EmailMarketing.SenderMail.Infra.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmailMarketing.SenderMail.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectInfra(this IServiceCollection services, IConfiguration configuration, string connectionString = "EmailMarketingDb")
        {
            services.AddScoped<IControleEmailRepository, ControleEmailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<EmailMarketingContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(connectionString));
#if DEBUG
                options.LogTo(Console.WriteLine, LogLevel.Information);
#endif
            });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
