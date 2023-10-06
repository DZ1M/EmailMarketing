using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Mappings
{
    public class UsuarioEmpresaConfiguration : IEntityTypeConfiguration<UsuarioEmpresa>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.IdEmpresa)
                .HasColumnName("id_empresa");

            builder.Property(c => c.IdUsuario)
                .HasColumnName("id_usuario");

            builder.HasOne(c => c.Usuario)
                .WithMany(x => x.Empresas)
                .HasForeignKey(c => c.IdUsuario);

            builder.HasOne(x => x.Empresa)
                .WithMany()
                .HasForeignKey(c => c.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("usuarios_empresas", "auth");
        }
    }
}
