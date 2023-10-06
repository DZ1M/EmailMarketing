using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Mappings
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Ignore(c => c.IdEmpresa);
            builder.Ignore(c => c.AtualizadoEm);
            builder.Ignore(c => c.CriadoPor);
            builder.Ignore(c => c.AtualizadoPor);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.Senha)
                .HasColumnName("senha")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.Url)
                .HasColumnName("url_perfil")
                .HasMaxLength(250);

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao");

            builder.Property(c => c.Telefone)
                .HasColumnName("telefone")
                .HasMaxLength(50);

            builder.Property(c => c.Ativo)
                .HasColumnName("ativo");

            builder.Property(x => x.CriadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("criado_em");

            builder.HasMany(c => c.Permissoes)
                .WithOne(i => i.Usuario)
                .HasForeignKey(c => c.IdUsuario);

            builder.ToTable("usuarios", "auth");
        }
    }
}
