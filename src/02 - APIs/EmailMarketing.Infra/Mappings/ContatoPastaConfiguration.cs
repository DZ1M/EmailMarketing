using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Mappings
{
    public class ContatoPastaConfiguration : IEntityTypeConfiguration<ContatoPasta>
    {
        public void Configure(EntityTypeBuilder<ContatoPasta> builder)
        {
            builder.HasKey(up => new { up.ContatoId, up.PastaId });

            builder.Property(c => c.ContatoId)
                .HasColumnName("id_contato");

            builder.Property(c => c.PastaId)
                .HasColumnName("id_pasta");

            builder.HasOne(up => up.Contato)
                .WithMany(u => u.ContatoPastas)
                .HasForeignKey(up => up.ContatoId);

            builder.HasOne(up => up.Pasta)
                .WithMany(p => p.ContatoPastas)
                .HasForeignKey(up => up.PastaId);

            builder.ToTable("contatos_pastas", "marketing");
        }
    }
}
