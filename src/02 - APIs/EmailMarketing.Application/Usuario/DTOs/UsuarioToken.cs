namespace EmailMarketing.Application.DTOs
{
    public class UsuarioToken
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
    }
}
