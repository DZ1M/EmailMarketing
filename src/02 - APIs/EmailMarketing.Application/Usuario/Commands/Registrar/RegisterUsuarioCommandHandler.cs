using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Admin.Auth.Register
{
    public class RegisterUsuarioCommandHandler : IRequestHandler<RegisterUsuarioCommand, Unit>
    {
        private readonly IUnitOfWork _repository;

        public RegisterUsuarioCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.Usuario.Query()
                .AnyAsync(x =>
                    EF.Functions.ILike(EF.Functions.Unaccent(x.Email), $"%{request.Email.Replace(" ", "%")}%")
                    )
                )
            {
                ValidationException.ThrowException("Registro", "E-mail já cadastrado.");
            }

            var userRoles = await _repository.Permissoes.Query()
                .Where(where => where.Default == true)
                .ToListAsync();

            var empresa = new Empresa(request.NomeEmpresa);

            var user = new EmailMarketing.Domain.Entities.Usuario(
                nome: request.Nome,
                email: request.Email,
                senha: request.Senha.Sha256(),
                descricao: "",
                telefone: "",
                url: "");

            user.Empresas.Add(new UsuarioEmpresa(user.Id, empresa.Id));

            foreach (var role in userRoles)
            {
                user.Permissoes.Add(new UsuarioPermissao(user.Id, role.Id));
            }


            _repository.Empresa.Create(empresa);
            _repository.Usuario.Create(user);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Registro", "Houve um erro ao persistir os dados.");
            }

            return Unit.Value;
        }
    }
}
