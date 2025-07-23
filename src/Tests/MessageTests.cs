using Xunit;
using Domain.Entities;
using Domain.TypedIds;

namespace Tests
{
    public class MessageTests
    {
        [Fact]
        public void Message_Creation_Sets_Properties()
        {
            var id = new MessageId(Guid.NewGuid());
            var senderId = new UserId(Guid.NewGuid());
            var recipientId = new UserId(Guid.NewGuid());
            var content = "Hello!";
            var sentAt = DateTime.UtcNow;

            var message = new Message(id, senderId, recipientId, content, sentAt);

            Assert.Equal(id, message.Id);
            Assert.Equal(senderId, message.SenderId);
            Assert.Equal(recipientId, message.RecipientId);
            Assert.Equal(content, message.Content);
            Assert.Equal(sentAt, message.SentAt);
        }
    }
}