using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog.Filters;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using Serilog.Formatting.Elasticsearch;
using Elastic.CommonSchema.Serilog;
using EmailMarketing.Architecture.WebApi.Core.Logs.Contracts;
using EmailMarketing.Architecture.WebApi.Core.Registros;

namespace EmailMarketing.Architecture.WebApi.Core.IoC
{
    public static class ArchitectureInfrasctructureIoC
    {
        public static IConfiguration SingletonConfigure<T>(this IServiceCollection services, IConfiguration config)
            where T : class
        {
            var instance = Activator.CreateInstance(typeof(T)) as T;
            return AddSingleton<T>(instance, services, config);
        }

        public static IConfiguration SingletonConfigure<I, C>(this IServiceCollection services, IConfiguration config)
            where I : class
            where C : class, I
        {
            var instance = Activator.CreateInstance(typeof(C)) as I;
            return AddSingleton<I>(instance, services, config);
        }

        public static IConfiguration AddSingleton<T>(T instance, IServiceCollection services, IConfiguration config)
            where T : class
        {
            if (instance != null)
            {
                config.Bind(instance.GetType().Name, instance);
                services.AddSingleton<T>(instance);
            }

            return config;
        }
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, IConfiguration configuration, string applicationName)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", $"{applicationName} - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
                .Enrich.WithCorrelationId()
                .Enrich.WithExceptionDetails()
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
                .WriteTo.Async(writeTo => writeTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticsearchSettings:uri"]))
                {
                    TypeName = null,
                    AutoRegisterTemplate = true,
                    IndexFormat = configuration["ElasticsearchSettings:defaultIndex"],
                    BatchAction = ElasticOpType.Create,
                    CustomFormatter = new EcsTextFormatter(),
                    ModifyConnectionSettings = x => x.BasicAuthentication(configuration["ElasticsearchSettings:username"], configuration["ElasticsearchSettings:password"])
                }))
                .WriteTo.Async(writeTo => writeTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"))
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Host.UseSerilog(Log.Logger, true);
            builder.Services.AddSingleton<IAppLogger, AppLogger>();

            return builder;
        }

        public static WebApplication UseSerilog(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseSerilogRequestLogging(opts =>
            {
                opts.EnrichDiagnosticContext = LogEnricherExtensions.EnrichFromRequest;
            });

            return app;
        }
    }
}
