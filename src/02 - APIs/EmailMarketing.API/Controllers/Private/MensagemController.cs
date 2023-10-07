using EmailMarketing.Application.Mensagem;
using EmailMarketing.Architecture.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.API.Controllers.Private
{
    [Authorize, Route("api/[controller]")]
    public class MensagemController : MainController
    {
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var mediator = await Mediator.Send(new MensagemCommand { });

            return CustomResponse(mediator);
        }
    }
}
