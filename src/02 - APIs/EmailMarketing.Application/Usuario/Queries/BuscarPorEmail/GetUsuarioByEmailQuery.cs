using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMarketing.Application.Usuario.Queries.BuscarPorEmail
{
    public class GetUsuarioByEmailQuery : Command, IRequest<EmailMarketing.Domain.Entities.Usuario>
    {
        /// <summary>Email</summary>
        /// <example>teste@teste.com</example>
        public string? Email { get; set; }
    }

    public class GetUsuarioByEmailQueryHandler : IRequestHandler<GetUsuarioByEmailQuery, EmailMarketing.Domain.Entities.Usuario>
    {
        private readonly IUnitOfWork _repository;

        public GetUsuarioByEmailQueryHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<EmailMarketing.Domain.Entities.Usuario> Handle(GetUsuarioByEmailQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.Usuario.Query()
                .Include(x => x.Empresas)
                .Include(x => x.Permissoes)
                    .ThenInclude(c => c.Permissao)
                .FirstOrDefaultAsync(x =>
                        EF.Functions.ILike(EF.Functions.Unaccent(x.Email), $"%{request.Email.Replace(" ", "%")}%")
                    );

            if (usuario is null)
            {
                ValidationException.ThrowException("Login", "O E-mail não existe.");
            }

            if (!usuario.Ativo)
            {
                ValidationException.ThrowException("Login", "Usuário desativado!.");
            }

            return usuario;
        }
    }
}
