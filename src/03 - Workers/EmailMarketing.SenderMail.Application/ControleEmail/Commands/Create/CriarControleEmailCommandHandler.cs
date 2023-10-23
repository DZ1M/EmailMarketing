using EmailMarketing.Architecture.Core.Messages.Integration;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.SenderMail.Domain.Entities;
using EmailMarketing.SenderMail.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMarketing.SenderMail.Application.ControleEmail.Commands.Create
{
    public class CriarControleEmailCommandHandler : IRequestHandler<CriarControleEmailCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public CriarControleEmailCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _config = configuration;
        }

        public async Task<Unit> Handle(CriarControleEmailCommand request, CancellationToken cancellationToken)
        {
            var usuarioEncrypt = EncryptHelper.EncryptString(_config["ENCRYPT_EMAIL"], request.Usuario);
            var senhaEncrypt = EncryptHelper.EncryptString(_config["ENCRYPT_EMAIL"], request.Senha);
            
            var objToCreate = new Domain.Entities.ControleEmail(
                    nome: request.Nome,
                    email: request.Email,
                    smtp: request.Smtp,
                    porta: request.Porta,
                    ssl: request.Ssl,
                    usuario: usuarioEncrypt,
                    senha: senhaEncrypt,
                    data: DateTime.Today.Date,
                    limiteDiario: request.LimiteDiario,
                    idEmpresa: request.IdEmpresa
                );
            
            _unitOfWork.ControleEmails.Create(objToCreate);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
