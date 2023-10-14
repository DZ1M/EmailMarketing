using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Mappings
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.IdEmpresa)
                .HasColumnName("id_empresa")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Email.Endereco)
                .HasColumnName("email")
                .HasColumnType("varchar(150)");

            builder.Property(x => x.CriadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("criado_em");

            builder.Property(c => c.CriadoPor)
                .HasColumnName("criado_por");

            builder.Property(x => x.AtualizadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("atualizado_em");

            builder.Property(c => c.AtualizadoPor)
                .HasColumnName("atualizado_por");

            builder.ToTable("contatos", "marketing");
        }
    }
}
