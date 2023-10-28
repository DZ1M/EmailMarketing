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

        [Fact]
        public async Task CreateTest()
        {
            var unitOfWork = new TestUnitOfWork(_dbConfig.Context);
            // Arrange
            var command = new CreatePastaCommand
            {
                Nome = "Romildo",
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
