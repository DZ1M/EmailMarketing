using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmailMarketing.Infra.Mappings
{
    public class CampanhaContatoAcaoConfiguration : IEntityTypeConfiguration<CampanhaContatoAcao>
    {
        public void Configure(EntityTypeBuilder<CampanhaContatoAcao> builder)
        {
            builder.Ignore(c => c.IdEmpresa);
            builder.Ignore(c => c.CriadoPor);
            builder.Ignore(c => c.AtualizadoPor);
            builder.Ignore(c => c.AtualizadoEm);

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.IdCampanhaContato)
                .HasColumnName("id_campanha_contato")
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

            builder.HasOne(c => c.CampanhaContato)
                .WithMany(v => v.Acoes)
                .HasForeignKey(c => c.IdCampanhaContato);

            builder.ToTable("campanhas_contatos_acoes", "marketing");
        }
    }
}
