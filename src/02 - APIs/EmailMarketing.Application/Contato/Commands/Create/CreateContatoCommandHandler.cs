using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.Contato.Commands.Create
{
    public class CreateContatoCommandHandler : IRequestHandler<CreateContatoCommand, ContatoDto>
    {
        private readonly IUnitOfWork _repository;
        public CreateContatoCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<ContatoDto> Handle(CreateContatoCommand request, CancellationToken cancellationToken)
        {
            var obj = new Entity.Contato(request.Nome, request.Email, request.Telefone, request.IdEmpresa, request.IdUsuario);

            obj.AddPasta(request.IdPasta);

            _repository.Contatos.Create(obj);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Contato", "Houve um erro ao persistir os dados.");
            }

            return ContatoDto.New(obj);
        }
    }
}