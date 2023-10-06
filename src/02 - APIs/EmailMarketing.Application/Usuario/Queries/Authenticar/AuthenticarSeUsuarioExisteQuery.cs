using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Usuario.Queries.Authenticar
{
    public class AuthenticarSeUsuarioExisteQuery : IRequest<IList<EmpresaDto>>
    {
        /// <summary>Email</summary>
        /// <example>teste@teste.com</example>
        public string? Email { get; set; }
        /// <summary>Senha do Usuario</summary>
        /// <example>123456</example>
        public string? Senha { get; set; }
        /// <summary>Id da Empresa</summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public Guid IdEmpresa { get; set; }
    }

    public class AuthenticarSeUsuarioExisteQueryHandler : IRequestHandler<AuthenticarSeUsuarioExisteQuery, IList<EmpresaDto>>
    {
        private readonly IUnitOfWork _repository;

        public AuthenticarSeUsuarioExisteQueryHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<IList<EmpresaDto>> Handle(AuthenticarSeUsuarioExisteQuery request, CancellationToken cancellationToken)
        {
            var account = await _repository.Usuario.Query()
                .Include(c => c.Empresas)
                    .ThenInclude(x => x.Empresa)
                .Where(x => x.Senha == request.Senha.Sha256() &&
                    EF.Functions.ILike(EF.Functions.Unaccent(x.Email), $"%{request.Email.Replace(" ", "%")}%")
                    )
                .ToListAsync();

            if (!account.Any())
            {
                ValidationException.ThrowException("Authenticar", "Usuário ou Senha incorretos.");
            }

            var empresas = account.SelectMany(u => u.Empresas.Select(e => EmpresaDto.New(e.Empresa)))
                                .Distinct()
                                .ToList();
            return empresas;
        }
    }
}
