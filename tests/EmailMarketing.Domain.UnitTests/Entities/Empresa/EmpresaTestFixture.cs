using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.Empresa
{
    internal class EmpresaTestFixture : BaseFixture
    {
        public Entity.Empresa Novo()
        {
            return new Entity.Empresa(
                    nome: Faker.Company.CompanyName()
                );
        }

        [CollectionDefinition(nameof(EmpresaTestFixture))]
        public class EmpresaTestFixtureCollection : ICollectionFixture<EmpresaTestFixture>
        { }
    }
}
