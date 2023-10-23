using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Architecture.WebApi.Core.Logs.Contracts;
using EmailMarketing.SenderMail.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace EmailMarketing.SenderMail.Application.EnviarEmail
{
    public class EnviarMensagemCommandHandler : BaseMensagemCommand, IRequestHandler<EnviarMensagemCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IAppLogger _logger;
        public EnviarMensagemCommandHandler(IUnitOfWork unitOfWork, IAppLogger logger, IConfiguration configuration) : base(configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> Handle(EnviarMensagemCommand request, CancellationToken cancellationToken)
        {
            var imagemRastreio = GerarImagemDeRastreio(request.Codigo);

            var controle = await _unitOfWork.ControleEmails.Query()
                .OrderBy(c => c.Data)
                .ThenBy(x => x.EnviadosHoje)
                .FirstOrDefaultAsync(where => where.IdEmpresa == request.IdEmpresa && (where.LimiteDiario > where.EnviadosHoje || where.Id != Guid.Empty));
            
            if(controle is null)
            {
                _logger.LogError($"Não existem emails aptos nesta conta para o envio da mensagem -> {request.IdEmpresa}, mensagem: {JsonHelper.Serialize(request)}");
                return false;
            }

            using var client = new SmtpClient();
            client.Host = controle.Smtp;
            client.EnableSsl = true;
            client.Port = controle.Porta;
            client.Credentials = new NetworkCredential(EncryptHelper.DecryptString(_configuration["ENCRYPT_EMAIL"], controle.Usuario), EncryptHelper.DecryptString(_configuration["ENCRYPT_EMAIL"], controle.Senha));

            var message = new MailMessage();

            message.Sender = new MailAddress(controle.Email, controle.Nome);
            message.From = new MailAddress(controle.Email, controle.Nome);

            message.To.Add(new MailAddress(request.Email, request.Nome));
            message.Subject = request.Nome;
            message.Body = $"{request.Texto}{imagemRastreio}";
            message.IsBodyHtml = true;
            message.Priority = MailPriority.High;

            try
            {
                client.Send(message);

                ///TODO: Dispara um request/grpc para o endpoint de mensagem dizendo que foi 'enviada'

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Ocorreu um erro ao enviar o email na conta de email: {controle.Id} empresa: {request.IdEmpresa}, mensagem: {JsonHelper.Serialize(request)}");
                return false;
            }

            controle.AumentarEnviadosHoje();

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
