using Bogus;
using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.Permissao
{
    internal class PermissaoTestFixture : BaseFixture
    {
        public Entity.Permissao Novo()
        {
            return new Entity.Permissao(
                nome: Faker.Lorem.Word(),
                valor: Faker.Lorem.Word()
                );
        }

        [CollectionDefinition(nameof(PermissaoTestFixture))]
        public class PermissaoTestFixtureCollection : ICollectionFixture<PermissaoTestFixture>
        { }
    }
}
