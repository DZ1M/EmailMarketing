using System.ComponentModel.DataAnnotations;

namespace EmailMarketing.Application.DTOs
{
    public class UsuarioLogin
    {
        /// <summary>Email</summary>
        /// <example>teste@teste.com</example>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }
        /// <summary>Senha</summary>
        /// <example>123456</example>
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }
    }
}
