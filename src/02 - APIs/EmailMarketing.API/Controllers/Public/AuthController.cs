using EmailMarketing.Architecture.WebApi.Core.Auth;
using EmailMarketing.Architecture.WebApi.Core.Controllers;
using EmailMarketing.Architecture.WebApi.Core.Usuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.API.Controllers.Public
{
    [Route("api/[controller]")]
    public class AuthController : BaseMainController
    {
        private readonly ISender _mediator;
        private readonly IAspNetUser _user;
        public AuthController(ISender mediator, IAspNetUser user)
        {
            _mediator = mediator;
            _user = user;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUsuarioCommand usuarioRegistro)
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

        [HttpGet("recuperar-senha")]
        public async Task<ActionResult> RecuperarSenha([FromQuery] string email)
        {
            await _mediator.Send(new RecuperarSenhaUsuarioCommand { Email = email });

            return CustomResponse();
        }

        [HttpPost("redefinir-senha")]
        public async Task<ActionResult> RedefinirSenha([FromBody] RedefinirSenhaUsuarioCommand request)
        {
            await _mediator.Send(request);

            var token = await _mediator.Send(new GerarTokenCommand
            {
                Email = request.Email,
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
