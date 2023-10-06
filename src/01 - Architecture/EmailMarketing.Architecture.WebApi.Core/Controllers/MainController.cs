using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Architecture.WebApi.Core.Common;
using EmailMarketing.Architecture.WebApi.Core.Usuario;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EmailMarketing.Architecture.WebApi.Core.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Key]
    public abstract class MainController : BaseMainController
    {
        private ISender _mediator = null!;
        private IAspNetUser _user = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        protected IAspNetUser UserLog => _user ??= HttpContext.RequestServices.GetRequiredService<IAspNetUser>();
        protected T AuthorizationRequestCreate<T>() where T : Command, new()
        {
            return new T
            {
                IdEmpresa = UserLog.ObterUserIdEmpresa(),
                IdUsuario = UserLog.ObterUserId()
            };

        }
        public override ForbidResult Forbid()
        {
            return new ForbidResult(JwtBearerDefaults.AuthenticationScheme);
        }
    }
}
