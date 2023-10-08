using EmailMarketing.SenderMail.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.SenderMail.Infra.Mappings
{
    public class ControleEmailConfiguration : IEntityTypeConfiguration<ControleEmail>
    {
        public void Configure(EntityTypeBuilder<ControleEmail> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()")
                .IsRequired();

            builder.Property(c => c.IdEmpresa)
                .HasColumnName("id_empresa")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Smtp)
                .HasColumnName("smtp")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Porta)
                .HasColumnName("porta");

            builder.Property(c => c.Ssl)
                .HasColumnName("ssl");

            builder.Property(c => c.Usuario)
                .HasColumnName("usuario")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Senha)
                .HasColumnName("senha")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.LimiteDiario)
                .HasColumnName("limite_diario");

            builder.Property(c => c.EnviadosHoje)
                .HasColumnName("enviados_hoje");

            builder.Property(x => x.Data)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("data");

            builder.ToTable("controle_emails", "controle");
        }
    }
}
