using Bogus.DataSets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailMarketing.Architecture.MessageBus
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectMessageBus(this IServiceCollection services, IConfiguration configuration, string connection = "MessageBus")
        {
            if (string.IsNullOrEmpty(configuration?.GetSection("MessageQueueConnection")?[connection])) throw new ArgumentNullException();

            services.AddSingleton<IMessageBus>(new MessageBus(configuration?.GetSection("MessageQueueConnection")?[connection]));

            return services;
        }
    }
}
