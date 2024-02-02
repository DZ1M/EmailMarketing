using EmailMarketing.Application.Admin.Auth.Register;
using EmailMarketing.Application.Usuario.Queries.Authenticar;
using EmailMarketing.Application.Usuario.Queries.GerarJwt;
using EmailMarketing.Architecture.WebApi.Core.Auth;
using EmailMarketing.Architecture.WebApi.Core.Controllers;
using EmailMarketing.Architecture.WebApi.Core.Logs.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.API.Controllers.Public
{
    [Route("api/[controller]")]
    public class AuthController : BaseMainController
    {
        private readonly ISender _mediator;
        private readonly IAppLogger _appLogger;
        public AuthController(ISender mediator, IAppLogger appLogger)
        {
            _mediator = mediator;
            _appLogger = appLogger;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar([FromBody]RegistrarUsuarioCommand usuarioRegistro)
        {
            await _mediator.Send(usuarioRegistro);

            var token = await _mediator.Send(new GerarTokenCommand
            {
                Email = usuarioRegistro.Email,
            });

            return CustomResponse(token);
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login([FromBody]AuthenticarSeUsuarioExisteQuery usuarioLogin)
        {
            var empresas = await _mediator.Send(usuarioLogin);
            if (usuarioLogin.IdEmpresa == Guid.Empty && empresas.Count > 1)
            {
                return CustomResponse(empresas);
            }

            var token = await _mediator.Send(new GerarTokenCommand
            {
                Email = usuarioLogin.Email,
                IdEmpresa = usuarioLogin.IdEmpresa
            });

            return CustomResponse(token);
        }
    }
}
