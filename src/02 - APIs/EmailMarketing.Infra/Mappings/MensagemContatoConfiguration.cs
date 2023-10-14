using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Mappings
{
    public class MensagemContatoConfiguration : IEntityTypeConfiguration<MensagemContato>
    {
        public void Configure(EntityTypeBuilder<MensagemContato> builder)
        {
            builder.Ignore(c => c.IdEmpresa);
            builder.Ignore(c => c.CriadoPor);
            builder.Ignore(c => c.AtualizadoPor);
            builder.Ignore(c => c.AtualizadoEm);

            builder.HasKey(x => x.Id);

            builder.HasIndex(c => c.Codigo).IsUnique();

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v1()");

            builder.Property(c => c.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("varchar(150)");

            builder.Property(c => c.IdMensagem)
                .HasColumnName("id_mensagem")
                .IsRequired();

            builder.Property(c => c.IdContato)
                .HasColumnName("id_contato")
                .IsRequired();

            builder.Property(x => x.CriadoEm)
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .HasColumnName("criado_em");

            builder.HasMany(x => x.Acoes)
                .WithOne()
                .HasForeignKey(c => c.IdMensagemContato);


            builder.ToTable("mensagem_contatos", "marketing");
        }
    }
}
