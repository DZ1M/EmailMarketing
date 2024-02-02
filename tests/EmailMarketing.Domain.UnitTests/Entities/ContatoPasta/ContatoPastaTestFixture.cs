using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.ContatoPasta
{
    internal class ContatoPastaTestFixture : BaseFixture
    {
        public Entity.ContatoPasta Novo()
        {
            return new Entity.ContatoPasta(Faker.Random.Guid());
        }

        [CollectionDefinition(nameof(ContatoPastaTestFixture))]
        public class ContatoPastaTestFixtureCollection : ICollectionFixture<ContatoPastaTestFixture>
        { }
    }
}
