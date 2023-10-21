# Parte 02 - Sender

### API Sender Mail
- Responsavel por criar o banco de dados e configurar internamento as credenciais dos emails de envio,
- Endpoint: POST -> controleEmail
	- Responsavel por fazer a configuração no banco do emails.
	- Utiliza dados como: Nome, Email, Smtp, Portal, Ssl, Usuario, Senha, Limite Diario de Envios neste email.
	
### Serviço Worker:
- Recebe a mensagem da fila "Mensagem" do RabbitMQ
* Metodo EnviarMensagemCommandHandler *
Monta a mensage, busca o email que vai disparar na tabela de "controle_email" e faz o envio do e-mail para o destinatário.
Após isso, atualiza na API de EmailMarketing o Status (Entregue, Erro ao Enviar)