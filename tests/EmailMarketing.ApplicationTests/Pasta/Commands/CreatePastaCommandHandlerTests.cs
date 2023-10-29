using EmailMarketing.Application.Pasta.Commands.Create;
using EmailMarketing.ApplicationTests.Context;
using EmailMarketing.Infra.Context;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.ApplicationTests.Pasta.Commands
{
    public class CreatePastaCommandHandlerTests : IDisposable
    {
        private readonly TestDbContextConfiguration _dbConfig;

        public CreatePastaCommandHandlerTests()
        {
            _dbConfig = new TestDbContextConfiguration();
        }

        [Theory]
        [InlineData("joao")]
        [InlineData("carapato")]
        public async Task CreateTest(string nome)
        {
            var unitOfWork = new TestUnitOfWork(_dbConfig.Context);
            // Arrange
            var command = new CreatePastaCommand
            {
                Nome = nome,
            };

            var handler = new CreatePastaCommandHandler(unitOfWork);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
        }

        public void Dispose()
        {
            _dbConfig.Dispose();
        }
    }
}
