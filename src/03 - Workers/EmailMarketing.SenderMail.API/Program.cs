using EmailMarketing.SenderMail.API.Configuration;
using EmailMarketing.SenderMail.Infra;
using EmailMarketing.SenderMail.Application;
using EmailMarketing.Architecture.WebApi.Core.Configuration;
using EmailMarketing.Architecture.WebApi.Core.Filter;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using EmailMarketing.Architecture.Core.Exceptions;
using FluentValidation.AspNetCore;
using EmailMarketing.Architecture.WebApi.Core.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllersWithViews(options => options.Filters.Add<ApiExceptionFilterAttribute>())
    .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Sender Email Marketing",
        Description = "Api responsavel pelo gerenciamento da parte de credenciais de email."
    });

    string[] methodsOrder = new string[5] { "post", "get", "put", "patch", "delete" };
    c.OrderActionsBy(apiDesc => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{Array.IndexOf(methodsOrder, apiDesc.HttpMethod.ToLower())}");
    c.OperationFilter<JsonIgnoreQueryOperationFilter>();
    c.OperationFilter<JsonIgnorePathOperationFilter>();
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    SwaggerExtensions.AddSwaggerXml(c);

});

builder.Services.AddFluentValidationRulesToSwagger();

builder.Services.InjectApplication();
builder.Services.InjectInfra(builder.Configuration);

builder.AddSerilog(builder.Configuration, "API Observability");

var app = builder.Build();

DbMigrationHelpers.EnsureSeedData(app).Wait();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSerilog();
app.MapControllers();

app.Run();
