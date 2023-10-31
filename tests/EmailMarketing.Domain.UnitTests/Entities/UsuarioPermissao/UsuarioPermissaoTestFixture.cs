using EmailMarketing.Architecture.Core.Utils;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.UnitTests.Entities.UsuarioPermissao
{
    internal class UsuarioPermissaoTestFixture : BaseFixture
    {
        public Entity.UsuarioPermissao Novo()
        {
            return new Entity.UsuarioPermissao(
                idUsuario: Faker.Random.Guid(),
                idPermissao: Faker.Random.Guid()
                );
        }

        [CollectionDefinition(nameof(UsuarioPermissaoTestFixture))]
        public class UsuarioPermissaoTestFixtureCollection : ICollectionFixture<UsuarioPermissaoTestFixture>
        { }
    }
}
