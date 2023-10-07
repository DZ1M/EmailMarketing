using EmailMarketing.API.Configuration;
using EmailMarketing.Application;
using EmailMarketing.Architecture.WebApi.Core.Auth;
using EmailMarketing.Infra;
using Serilog;
using EmailMarketing.Architecture.MessageBus;

namespace EmailMarketing.API
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfiguration(Configuration);

            services.AddJwtConfiguration(Configuration);

            services.RegisterServices();

            services.InjectApplication();

            services.InjectInfra(Configuration);

            services.InjectMessageBus(Configuration);

            services.AddSwaggerConfiguration();

            services.AppConfigureExceptionFilter();
        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();

            app.UseSwaggerConfiguration(environment);

            app.UseApiConfiguration();
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder WebAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), WebAppBuilder.Configuration) as IStartup;

            if (startup == null) throw new ArgumentException("Class Startup.cs invalid!");

            WebAppBuilder.Logging.AddSerilog(new LoggerConfiguration()
                .ReadFrom.Configuration(WebAppBuilder.Configuration)
                .CreateLogger());

            startup.ConfigureServices(WebAppBuilder.Services);

            var app = WebAppBuilder.Build();
            startup.Configure(app, app.Environment);
            app.Run();

            return WebAppBuilder;
        }
    }
}

