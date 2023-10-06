using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Architecture.WebApi.Core.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace EmailMarketing.Architecture.WebApi.Core.Common
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class KeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _accessor = context.HttpContext.RequestServices.GetRequiredService<IAspNetUser>();

            if (!_accessor.EstaAutenticado())
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "JWT is not valid"
                };
                return;
            }

            foreach (var command in context.ActionArguments)
            {
                if (command.Value != null)
                {

                    var authorization = command.Value as Command;
                    if (authorization != null)
                    {
                        authorization.IdUsuario = _accessor.ObterUserId();
                        authorization.IdEmpresa = _accessor.ObterUserIdEmpresa();
                        break;
                    }
                }
            }
            await next();
        }
    }
}
