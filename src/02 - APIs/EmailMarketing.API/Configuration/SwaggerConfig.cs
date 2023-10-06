using EmailMarketing.Architecture.WebApi.Core.Filter;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace EmailMarketing.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api de Email Marketing",
                    Description = "Api responsavel pelo gerenciamento do sistema."
                });

                string[] methodsOrder = new string[5] { "post", "get", "put", "patch", "delete" };
                c.OrderActionsBy(apiDesc => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{Array.IndexOf(methodsOrder, apiDesc.HttpMethod.ToLower())}");
                c.OperationFilter<JsonIgnoreQueryOperationFilter>();
                c.OperationFilter<JsonIgnorePathOperationFilter>();
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               
                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
                foreach (var xmlFile in xmlFiles)
                {
                    c.IncludeXmlComments(xmlFile);
                }

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddFluentValidationRulesToSwagger();
            return services;
        }
        public static WebApplication UseSwaggerConfiguration(this WebApplication app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment() || environment.IsEnvironment("Docker"))
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DefaultModelsExpandDepth(-1);
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

                });
            }

            return app;
        }
    }
}
