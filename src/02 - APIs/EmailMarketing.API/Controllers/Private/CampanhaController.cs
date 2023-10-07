using EmailMarketing.Architecture.WebApi.Core.Auth;
using EmailMarketing.Architecture.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.API.Controllers.Private
{
    [Authorize, Route("api/[controller]")]
    public class CampanhaController : MainController
    {
        /// <summary>
        /// Cria uma nova campanha
        /// </summary>
        /// <response code="200">Success: Campanha criada</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Campanha", "Create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        public async Task<IActionResult> Create([FromBody] dynamic command)
        {
            var mediator = await Mediator.Send(command);

            return CustomResponse(mediator);
        }
        /// <summary>
        /// Busca uma campanha pelo id
        /// </summary>
        /// <response code="200">Success: Retorna uma campanha</response>
        /// <response code="400">Failure: Invalid request</response>
        [ClaimsAuthorize("Campanha", "Read")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return CustomResponse();
        }

        /// <summary>
        /// Edita uma campanha
        /// </summary>
        /// <response code="200">Success: Campanha alterada</response>
        /// <response code="400">Failure: Invalid request</response>
        [ClaimsAuthorize("Campanha", "Edit")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] dynamic command)
        {
            command.Id = id;
            var mediator = await Mediator.Send(command);
            return CustomResponse(mediator);

        }

        /// <summary>
        /// Deleta uma campanha
        /// </summary>
        /// <response code="204">Success: Campaanha excluida com sucesso</response>
        /// <response code="400">Failure: Invalid request</response>
        [ClaimsAuthorize("Campanha", "Delete")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return NoContent();
        }
    }
}
