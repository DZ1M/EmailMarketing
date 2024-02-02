using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.CampanhaContato
{
    internal class CampanhaContatoTestFixture : BaseFixture
    {
        public Entity.CampanhaContato Novo()
        {
            return new Entity.CampanhaContato(Faker.Random.Guid());
        }

        [CollectionDefinition(nameof(CampanhaContatoTestFixture))]
        public class CampanhaContatoTestFixtureCollection : ICollectionFixture<CampanhaContatoTestFixture>
        { }
    }
}
