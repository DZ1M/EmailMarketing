using EmailMarketing.SenderMail.WorkerService;
using EmailMarketing.Architecture.MessageBus;
using MediatR;
using System.Reflection;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.InjectMessageBus(hostContext.Configuration);
        services.AddHostedService<Worker>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
    })
    .Build();

host.Run();
