﻿using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;
using EmailMarketing.Infra.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmailMarketing.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectInfra(this IServiceCollection services, IConfiguration configuration, string connectionString = "EmailMarketingDb")
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IPermissoesRepository, PermissoesRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<ICampanhaRepository, CampanhaRepository>();
            services.AddScoped<ICampanhaContatoRepository, CampanhaContatoRepository>();
            services.AddScoped<ICampanhaContatoAcaoRepository, CampanhaContatoAcaoRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IPastaRepository, PastaRepository>();
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
