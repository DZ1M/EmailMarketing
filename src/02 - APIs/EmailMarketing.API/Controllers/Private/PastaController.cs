using EmailMarketing.Application.DTOs;
using EmailMarketing.Application.Pasta.Commands.Create;
using EmailMarketing.Application.Pasta.Commands.Delete;
using EmailMarketing.Application.Pasta.Commands.Update;
using EmailMarketing.Application.Pasta.Queries.ById;
using EmailMarketing.Application.Pasta.Queries.ListAll;
using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Architecture.WebApi.Core.Auth;
using EmailMarketing.Architecture.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.API.Controllers.Private
{
    [Authorize, Route("api/[controller]")]
    public class PastaController : MainController
    {
        /// <summary>
        /// Cria uma nova pasta
        /// </summary>
        /// <response code="200">Success: pasta criada</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Campanha", "Create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PastaDto))]
        public async Task<IActionResult> Create([FromBody] CreatePastaCommand command)
        {
            var mediator = await Mediator.Send(command);

            return CustomResponse(mediator);
        }

        /// <summary>
        /// Lista todos as pastas
        /// </summary>
        /// <param name="length"></param>
        /// <param name="start"></param>
        /// <param name="search"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortColumnDirection"></param>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Campanha", "Read")]
        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListaPaginada<PastaDto>))]
        public async Task<ListaPaginada<PastaDto>> List([FromQuery] int? length, [FromQuery] int? start, [FromQuery] string? search, [FromQuery] string? sortColumn, [FromQuery] string sortColumnDirection = "asc")
        {
            var command = AuthorizationRequestCreate<GetAllPastaQuery>();

            command.Length = length ?? 10;
            command.Start = start ?? 0;
            command.Search = search;
            command.SortColumn = sortColumn;
            command.SortColumnDirection = sortColumnDirection;

            return await Mediator.Send(command);
        }

        /// <summary>
        /// Busca uma pasta pelo id
        /// </summary>
        /// <response code="200">Success: Retorna uma pasta</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Campanha", "Read")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PastaDto))]
        public async Task<IActionResult> Get(Guid id)
        {
            var command = AuthorizationRequestCreate<GetPastaByIdQuery>();
            command.Id = id;
            var response = await Mediator.Send(command);
            return CustomResponse(response);
        }

        /// <summary>
        /// Edita uma pasta
        /// </summary>
        /// <response code="200">Success: Pasta alterada</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Campanha", "Edit")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PastaDto))]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] UpdatePastaCommand command)
        {
            command.Id = id;
            var mediator = await Mediator.Send(command);
            return CustomResponse(mediator);

        }

        /// <summary>
        /// Deleta uma pasta
        /// </summary>
        /// <response code="204">Success: Pasta excluida com sucesso</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Campanha", "Delete")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = AuthorizationRequestCreate<DeletePastaCommand>();
            command.Id = id;
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
