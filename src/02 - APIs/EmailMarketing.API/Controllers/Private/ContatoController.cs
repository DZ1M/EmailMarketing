using EmailMarketing.Application.Contato.Commands.Create;
using EmailMarketing.Application.Contato.Commands.Delete;
using EmailMarketing.Application.Contato.Commands.Update;
using EmailMarketing.Application.Contato.Queries.ById;
using EmailMarketing.Application.Contato.Queries.ListAll;
using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Architecture.WebApi.Core.Auth;
using EmailMarketing.Architecture.WebApi.Core.Controllers;
using EmailMarketing.Architecture.WebApi.Core.Logs.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.API.Controllers.Private
{
    [Authorize, Route("api/[controller]")]
    public class ContatoController : MainController
    {
        private readonly IAppLogger _appLogger;

        public ContatoController(IAppLogger appLogger)
        {
            _appLogger = appLogger;
        }

        /// <summary>
        /// Cria um novo modelo
        /// </summary>
        /// <response code="200">Success: Campanha criada</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Contato", "Create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContatoDto))]
        public async Task<IActionResult> Create([FromBody] CreateContatoCommand command)
        {
            var mediator = await Mediator.Send(command);

            return CustomResponse(mediator);
        }
        /// <summary>
        /// Lista todos os contatos
        /// </summary>
        /// <param name="length"></param>
        /// <param name="start"></param>
        /// <param name="search"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortColumnDirection"></param>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Contato", "Read")]
        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListaPaginada<ContatoDto>))]
        public async Task<ListaPaginada<ContatoDto>> List([FromQuery] int? length, [FromQuery] int? start, [FromQuery] string? search, [FromQuery] string? sortColumn, [FromQuery] string sortColumnDirection = "asc")
        {
            var command = AuthorizationRequestCreate<GetAllContatoQuery>();

            command.Length = length ?? 10;
            command.Start = start ?? 0;
            command.Search = search;
            command.SortColumn = sortColumn;
            command.SortColumnDirection = sortColumnDirection;

            return await Mediator.Send(command);
        }

        /// <summary>
        /// Busca um contato pelo id
        /// </summary>
        /// <response code="200">Success: Retorna um contato</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Contato", "Read")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContatoDto))]
        public async Task<IActionResult> Get(Guid id)
        {
            var command = AuthorizationRequestCreate<GetContatoByIdQuery>();
            command.Id = id;
            var response = await Mediator.Send(command);
            return CustomResponse(response);
        }

        /// <summary>
        /// Edita um contato
        /// </summary>
        /// <response code="200">Success: Contato alterado</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Contato", "Update")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContatoDto))]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateContatoCommand command)
        {
            command.Id = id;
            var mediator = await Mediator.Send(command);
            return CustomResponse(mediator);

        }

        /// <summary>
        /// Deleta um contato
        /// </summary>
        /// <response code="204">Success: Contato excluido com sucesso</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Contato", "Delete")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = AuthorizationRequestCreate<DeleteContatoCommand>();
            command.Id = id;
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
