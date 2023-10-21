using EmailMarketing.Application.DTOs;
using EmailMarketing.Application.Modelo.Commands.Create;
using EmailMarketing.Application.Modelo.Commands.Delete;
using EmailMarketing.Application.Modelo.Commands.Update;
using EmailMarketing.Application.Modelo.Queries.ById;
using EmailMarketing.Application.Modelo.Queries.ListAll;
using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Architecture.WebApi.Core.Auth;
using EmailMarketing.Architecture.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmailMarketing.API.Controllers.Private
{
    [Authorize, Route("api/[controller]")]
    public class ModeloController : MainController
    {
        /// <summary>
        /// Cria um novo modelo
        /// </summary>
        /// <response code="200">Success: Campanha criada</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Modelo", "Create")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ModeloDto))]
        public async Task<IActionResult> Create([FromBody] CreateModeloCommand command)
        {
            var mediator = await Mediator.Send(command);

            return CustomResponse(mediator);
        }
        /// <summary>
        /// Lista todos os modelos
        /// </summary>
        /// <param name="length"></param>
        /// <param name="start"></param>
        /// <param name="search"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortColumnDirection"></param>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Modelo", "Read")]
        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListaPaginada<ModeloDto>))]
        public async Task<ListaPaginada<ModeloDto>> List([FromQuery] int? length, [FromQuery] int? start, [FromQuery] string? search, [FromQuery] string? sortColumn, [FromQuery] string sortColumnDirection = "asc")
        {
            var command = AuthorizationRequestCreate<GetAllModeloQuery>();

            command.Length = length ?? 10;
            command.Start = start ?? 0;
            command.Search = search;
            command.SortColumn = sortColumn;
            command.SortColumnDirection = sortColumnDirection;

            return await Mediator.Send(command);
        }

        /// <summary>
        /// Busca um modelo pelo id
        /// </summary>
        /// <response code="200">Success: Retorna um modelo</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Modelo", "Read")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ModeloDto))]
        public async Task<IActionResult> Get(Guid id)
        {
            var command = AuthorizationRequestCreate<GetModeloByIdQuery>();
            command.Id = id;
            var response = await Mediator.Send(command);
            return CustomResponse(response);
        }

        /// <summary>
        /// Edita um modelo
        /// </summary>
        /// <response code="200">Success: Modelo alterado</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Modelo", "Update")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ModeloDto))]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateModeloCommand command)
        {
            command.Id = id;
            var mediator = await Mediator.Send(command);
            return CustomResponse(mediator);

        }

        /// <summary>
        /// Deleta um modelo
        /// </summary>
        /// <response code="204">Success: Modelo excluido com sucesso</response>
        /// <response code="400">Failure: Requisição invalida</response>
        /// <response code="401">Failure: Sem autorização</response>
        [ClaimsAuthorize("Modelo", "Delete")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = AuthorizationRequestCreate<DeleteModeloCommand>();
            command.Id = id;
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
