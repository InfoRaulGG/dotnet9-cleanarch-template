using Xunit;
using Moq;
using Application.Queries;
using Domain.Repositories;
using Domain.Entities;
using Domain.TypedIds;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Handlers;

namespace Tests
{
    public class GetUserMessagesHandlerTests
    {
        [Fact]
        public async Task Handler_Returns_Messages_For_User()
        {
            // Arrange
            var userId = new UserId(Guid.NewGuid());
            var messages = new List<Message>
            {
                new Message(new MessageId(Guid.NewGuid()), userId, new UserId(Guid.NewGuid()), "Hi!", DateTime.UtcNow)
            };

            var repoMock = new Mock<IMessageRepository>();
            repoMock.Setup(r => r.GetMessagesForUserAsync(It.IsAny<UserId>()))
                .ReturnsAsync(messages);

            var handler = new GetUserMessagesHandler(repoMock.Object);

            // Act
            var result = await handler.Handle(new GetUserMessagesQuery(userId), CancellationToken.None);
            var resultList = result.ToList();

            // Assert
            Assert.Single(resultList);
            Assert.Equal("Hi!", resultList[0].Content);
            repoMock.Verify(r => r.GetMessagesForUserAsync(userId), Times.Once);
        }
    }
}