using EmailMarketing.Architecture.MessageBus;
using EmailMarketing.SenderMail.Application;
using EmailMarketing.SenderMail.Infra;
using EmailMarketing.SenderMail.WorkerService;
using EmailMarketing.Architecture.WebApi.Core.IoC;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InjectMessageBus(builder.Configuration);
builder.Services.InjectApplication();
builder.Services.InjectInfra(builder.Configuration);
builder.Services.AddHostedService<Worker>();
builder.AddSerilog(builder.Configuration,"");

var app = builder.Build();

app.UseSerilog();

app.Run();

