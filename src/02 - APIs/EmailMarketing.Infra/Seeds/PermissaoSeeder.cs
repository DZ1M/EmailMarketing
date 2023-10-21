using EmailMarketing.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailMarketing.Infra.Seeds
{
    public static class PermissaoSeeder
    {
        public static void Seed(EntityTypeBuilder<Permissao> builder)
        {
            builder.HasData(

                new Permissao("Pasta", "Create", true),
                new Permissao("Pasta", "Read", true),
                new Permissao("Pasta", "Update", true),
                new Permissao("Pasta", "Delete", true),

                new Permissao("Modelo", "Create", true),
                new Permissao("Modelo", "Read", true),
                new Permissao("Modelo", "Update", true),
                new Permissao("Modelo", "Delete", true),

                new Permissao("Contato", "Create", true),
                new Permissao("Contato", "Read", true),
                new Permissao("Contato", "Update", true),
                new Permissao("Contato", "Delete", true),

                new Permissao("Campanha", "Create", true),
                new Permissao("Campanha", "Read", true),
                new Permissao("Campanha", "Update", true),
                new Permissao("Campanha", "Delete", true)
                );
        }
    }
}
