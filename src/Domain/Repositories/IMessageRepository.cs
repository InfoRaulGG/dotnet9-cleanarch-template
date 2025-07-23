using Domain.Entities;
using Domain.TypedIds;

namespace Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<Message?> GetByIdAsync(MessageId id);
        Task AddAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesForUserAsync(UserId userId);
    }
}