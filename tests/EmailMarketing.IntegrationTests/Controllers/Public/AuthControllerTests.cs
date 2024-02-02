using EmailMarketing.IntegrationTests.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EmailMarketing.IntegrationTests.Controllers.Public
{
    [Collection("Database")]
    public class AuthControllerTests : IClassFixture<IntegrationFactory>
    {
        private readonly IntegrationFactory _factory;
        public AuthControllerTests(IntegrationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Login_Tests_Ok()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var request = new
            {
                Email = "teste@teste.com",
                Senha = "123456",
                IdEmpresa = Guid.Empty
            };

            var response = await client.PostAsJsonAsync("api/auth/autenticar", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
