using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmailMarketing.Infra.Mappings
{
    public class MensagemContatoAcaoConfiguration : IEntityTypeConfiguration<MensagemContatoAcao>
    {
        public void Configure(EntityTypeBuilder<MensagemContatoAcao> builder)
        {
            builder.Ignore(c => c.IdEmpresa);
            builder.Ignore(c => c.CriadoPor);
            builder.Ignore(c => c.AtualizadoPor);
            builder.Ignore(c => c.AtualizadoEm);

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.IdMensagemContato)
                .HasColumnName("id_mensagem_contato")
                .IsRequired();

            builder.Property(c => c.Acao)
                .HasColumnName("acao")
                .HasColumnType("varchar(25)")
                .HasConversion(new EnumToStringConverter<AcaoMensagemEnum>())
                .IsRequired();

            builder.Property(x => x.CriadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("criado_em");

            builder.ToTable("mensagem_contatos_acoes", "marketing");
        }
    }
}
