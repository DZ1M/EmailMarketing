using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Infra.Mappings
{
    public class MensagemConfiguration : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
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
                .HasColumnType("varchar(255)");

            builder.Property(c => c.TipoMensagem)
                .HasColumnName("tipo_mensagem")
                .HasColumnType("varchar(25)")
                .HasConversion(new EnumToStringConverter<TipoMensagemEnum>())
                .IsRequired();

            builder.Property(c => c.IdCampanha)
                .HasColumnName("id_campanha")
                .IsRequired();

            builder.Property(c => c.IdModelo)
                .HasColumnName("id_modelo")
                .IsRequired();

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

            builder.HasMany(x => x.Contatos)
                .WithOne()
                .HasForeignKey(c => c.IdMensagem);


            builder.HasOne(x => x.Modelo)
                .WithMany()
                .HasForeignKey(c => c.IdModelo);

            builder.HasOne(x => x.Campanha)
                .WithMany()
                .HasForeignKey(c => c.IdCampanha);

            builder.ToTable("mensagems", "marketing");
        }
    }
}
