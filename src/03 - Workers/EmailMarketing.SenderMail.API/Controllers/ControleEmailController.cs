using EmailMarketing.SenderMail.Application.ControleEmail.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.SenderMail.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleEmailController : ControllerBase
    {
        private readonly ILogger<ControleEmailController> _logger;
        private readonly IMediator _mediator;

        public ControleEmailController(ILogger<ControleEmailController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CriarControleEmailCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}