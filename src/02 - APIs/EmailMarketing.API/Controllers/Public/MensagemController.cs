using EmailMarketing.Application.CampanhaContato.Commands.AddNewStatus;
using EmailMarketing.Architecture.WebApi.Core.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.API.Controllers.Public
{
    [Route("api/[controller]")]
    public class MensagemController : BaseMainController
    {
        private readonly ISender _sender;

        public MensagemController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("lida/{code}")]
        public async Task<IActionResult> Lida([FromRoute] string code)
        {
            var command = new AddNewStatusCommand
            {
                Code = Path.GetFileNameWithoutExtension(code),
                Acao = Domain.Enums.AcaoMensagemEnum.Lida
            };
            await _sender.Send(command);
            return Ok();
        }
    }
}
