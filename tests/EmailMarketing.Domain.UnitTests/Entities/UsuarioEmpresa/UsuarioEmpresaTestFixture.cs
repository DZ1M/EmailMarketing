using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.UsuarioEmpresa
{
    internal class UsuarioEmpresaTestFixture : BaseFixture
    {
        public Entity.UsuarioEmpresa Novo()
        {
            return new Entity.UsuarioEmpresa(
                idUsuario: Faker.Random.Guid(),
                idEmpresa: Faker.Random.Guid()
                );
        }

        [CollectionDefinition(nameof(UsuarioEmpresaTestFixture))]
        public class UsuarioEmpresaTestFixtureCollection : ICollectionFixture<UsuarioEmpresaTestFixture>
        { }
    }
}
