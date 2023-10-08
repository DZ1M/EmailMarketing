namespace EmailMarketing.SenderMail.Domain.Entities
{
    public class ControleEmail
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Smtp { get; private set; }
        public int Porta { get; private set; }
        public bool Ssl { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public int LimiteDiario { get; private set; }
        public int EnviadosHoje { get; private set; }
        public DateTime Data { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public ControleEmail() { }
        public ControleEmail(string nome, string email, string smtp, int porta, bool ssl, string usuario, string senha, DateTime data, int limiteDiario, Guid idEmpresa)
        {
            Nome = nome;
            Email = email;
            Smtp = smtp;
            Porta = porta;
            Ssl = ssl;
            Usuario = usuario;
            Senha = senha;
            Data = data;
            LimiteDiario = limiteDiario;
            IdEmpresa = idEmpresa;
        }
        public void AumentarEnviadosHoje()
        {
            EnviadosHoje += 1;
            if (DateTime.Today.Date > Data.Date)
            {
                Data = DateTime.Today.Date;
                EnviadosHoje = 1;
            }
        }
    }
}
