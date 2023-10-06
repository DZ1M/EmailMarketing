using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailMarketing.Architecture.Core.Utils
{
    public static class CoreDependencyInjection
    {
        public static IConfiguration SingletonConfigure<I, C>(this IServiceCollection services, IConfiguration config)
            where I : class
            where C : class, I
        {
            var instance = Activator.CreateInstance(typeof(C)) as I;
            return AddSingleton<I>(instance, services, config);
        }

        private static IConfiguration AddSingleton<T>(T instance, IServiceCollection services, IConfiguration config)
            where T : class
        {
            if (instance != null)
            {
                config.Bind(instance.GetType().Name, instance);
                services.AddSingleton<T>(instance);
            }

            return config;
        }
    }
}
