using EmailMarketing.Architecture.MessageBus;
using EmailMarketing.SenderMail.Application;
using EmailMarketing.SenderMail.Infra;
using EmailMarketing.SenderMail.WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.InjectMessageBus(hostContext.Configuration);
        services.InjectApplication();
        services.InjectInfra(hostContext.Configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
