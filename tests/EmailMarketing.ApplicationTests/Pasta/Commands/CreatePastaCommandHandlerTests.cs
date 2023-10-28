using EmailMarketing.Application.Pasta.Commands.Create;
using EmailMarketing.ApplicationTests.Context;
using EmailMarketing.Infra.Context;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.ApplicationTests.Pasta.Commands
{
    public class CreatePastaCommandHandlerTests : IDisposable
    {
        private DbContextOptions<EmailMarketingContext> _options;
        private EmailMarketingContext _context;

        public CreatePastaCommandHandlerTests()
        {
            _options = new DbContextOptionsBuilder<EmailMarketingContext>()
                .UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5436;Database=test_emailmarketing_db;MaxPoolSize=200;")
                .Options;

            _context = new TestDbContext(_options);
            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task CreateTest()
        {
            var unitOfWork = new TestUnitOfWork(_context);
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
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
