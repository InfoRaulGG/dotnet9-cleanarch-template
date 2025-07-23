using Domain.TypedIds;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Message
    {
        public MessageId Id { get; private set; }
        public UserId SenderId { get; private set; }
        public UserId RecipientId { get; private set; }
        public string Content { get; private set; }
        public DateTime SentAt { get; private set; }

        public Message(MessageId id, UserId senderId, UserId recipientId, string content, DateTime sentAt)
        {
            Id = id;
            SenderId = senderId;
            RecipientId = recipientId;
            Content = content;
            SentAt = sentAt;
        }
    }
}