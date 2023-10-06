using System.Text.Json.Serialization;

namespace EmailMarketing.Domain.Entities
{
    public class UsuarioEmpresa
    {
        protected UsuarioEmpresa() { }
        public UsuarioEmpresa(Guid idUsuario, Guid idEmpresa)
        {
            IdUsuario = idUsuario;
            IdEmpresa = idEmpresa;
        }

        public Guid Id { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Guid IdEmpresa { get; private set; }
        [JsonIgnore]
        public Usuario Usuario { get; set; }
        [JsonIgnore]
        public Empresa Empresa { get; set; }
    }
}
