using Xunit;
using Moq;
using Application.Commands;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.Repositories;
using Application.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task Handler_Creates_User_And_Calls_Repository_And_UnitOfWork()
        {
            // Arrange
            var repoMock = new Mock<IUserRepository>();
            repoMock.Setup(r => r.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(u => u.CommitAsync(CancellationToken.None)).Returns(Task.FromResult(1));

            var handler = new CreateUserCommandHandler(repoMock.Object, uowMock.Object);

            var command = new CreateUserCommand("Charlie", "charlie@example.com");

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repoMock.Verify(r => r.AddAsync(It.Is<User>(
                u => u.Name.Value == "Charlie" && u.Email.Value == "charlie@example.com")), Times.Once);

            uowMock.Verify(u => u.CommitAsync(CancellationToken.None), Times.Once);
        }
    }
}