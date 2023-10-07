using EmailMarketing.Application.Admin.Auth.Register;
using EmailMarketing.Application.Usuario.Queries.Authenticar;
using EmailMarketing.Application.Usuario.Queries.GerarJwt;
using EmailMarketing.Architecture.WebApi.Core.Auth;
using EmailMarketing.Architecture.WebApi.Core.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.API.Controllers.Public
{
    [Route("api/[controller]")]
    public class AuthController : BaseMainController
    {
        private readonly ISender _mediator;
        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegistrarUsuarioCommand usuarioRegistro)
        {
            await _mediator.Send(usuarioRegistro);

            var token = await _mediator.Send(new GerarTokenCommand
            {
                Email = usuarioRegistro.Email,
            });

            return CustomResponse(token);
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(AuthenticarSeUsuarioExisteQuery usuarioLogin)
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

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                AddErrorToStack("Invalid Refresh Token");
                return CustomResponse();
            }

            if (!JwtOptions.Expired(refreshToken))
            {
                AddErrorToStack("Not Expired Refresh Token");
                return CustomResponse();
            }

            var email = JwtOptions.GetEmail(refreshToken);
            var idEmpresa = JwtOptions.GetIdEmpresa(refreshToken);
            if (string.IsNullOrEmpty(email) || idEmpresa == Guid.Empty)
            {
                AddErrorToStack("Expired Refresh Token");
                return CustomResponse();
            }

            var token = await _mediator.Send(new GerarTokenCommand
            {
                Email = email,
                IdEmpresa = idEmpresa
            });

            return CustomResponse(token);
        }


    }
}
