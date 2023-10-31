using Bogus;
using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.CampanhaPasta
{
    internal class CampanhaPastaTestFixture : BaseFixture
    {
        public Entity.CampanhaPasta Novo()
        {
            return new Entity.CampanhaPasta(Faker.Random.Guid());
        }

        [CollectionDefinition(nameof(CampanhaPastaTestFixture))]
        public class CampanhaPastaTestFixtureCollection : ICollectionFixture<CampanhaPastaTestFixture>
        { }
    }
}
