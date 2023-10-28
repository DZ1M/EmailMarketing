using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Admin.Auth.Register
{
    public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand, Unit>
    {
        private readonly IUnitOfWork _repository;

        public RegistrarUsuarioCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.Usuarios.Query()
                .AnyAsync(x => x.Email == request.Email
                    )
                )
            {
                ValidationException.ThrowException("Registro", "E-mail já cadastrado.");
            }

            var userRoles = await _repository.Permissoes.Query()
                .Where(where => where.Default == true)
                .ToListAsync();

            var empresa = new Empresa(request.NomeEmpresa);

            var user = new Domain.Entities.Usuario(
                nome: request.Nome,
                email: request.Email,
                senha: request.Senha.Sha256(),
                descricao: "",
                telefone: "",
                url: "");

            user.AddEmpresa(new UsuarioEmpresa(user.Id, empresa.Id));

            foreach (var role in userRoles)
            {
                user.AddRole(new UsuarioPermissao(user.Id, role.Id));
            }


            _repository.Empresas.Create(empresa);
            _repository.Usuarios.Create(user);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Registro", "Houve um erro ao persistir os dados.");
            }

            return Unit.Value;
        }
    }
}
