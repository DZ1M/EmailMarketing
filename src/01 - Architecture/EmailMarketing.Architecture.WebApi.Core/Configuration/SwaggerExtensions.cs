using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EmailMarketing.Architecture.WebApi.Core.Configuration
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerXml(SwaggerGenOptions c)
        {
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
            foreach (var xmlFile in xmlFiles)
            {
                c.IncludeXmlComments(xmlFile);
            }
        }
    }
}
