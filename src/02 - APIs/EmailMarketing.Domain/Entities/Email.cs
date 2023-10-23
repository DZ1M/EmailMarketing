namespace EmailMarketing.Domain.Entities
{
    public class Email
    {
        public Email(string email) {
            Endereco = email;
        }
        public string Endereco { get; }
    }
}
