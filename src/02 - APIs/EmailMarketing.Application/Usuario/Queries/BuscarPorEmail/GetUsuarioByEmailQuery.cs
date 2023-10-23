using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Usuario.Queries.BuscarPorEmail
{
    public class GetUsuarioByEmailQuery : Command, IRequest<UsuarioDto>
    {
        /// <summary>Email</summary>
        /// <example>teste@teste.com</example>
        public string? Email { get; set; }
    }

    public class GetUsuarioByEmailQueryHandler : IRequestHandler<GetUsuarioByEmailQuery, UsuarioDto>
    {
        private readonly IUnitOfWork _repository;

        public GetUsuarioByEmailQueryHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<UsuarioDto> Handle(GetUsuarioByEmailQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.Usuarios.Query()
                .Include(x => x.Empresas)
                    .ThenInclude(x => x.Empresa)
                .Include(x => x.Permissoes)
                    .ThenInclude(c => c.Permissao)
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                         EF.Functions.ILike(EF.Functions.Unaccent(x.Email), EF.Functions.Unaccent(request.Email))
                    );

            if (usuario is null)
            {
                ValidationException.ThrowException("Login", "O E-mail não existe.");
            }

            if (!usuario.Ativo)
            {
                ValidationException.ThrowException("Login", "Usuário desativado!.");
            }

            var usuarioToReturn = UsuarioDto.New(usuario);

            return usuarioToReturn;
        }
    }
}
