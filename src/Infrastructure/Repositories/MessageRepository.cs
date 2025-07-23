using Domain.Entities;
using Domain.Repositories;
using Domain.TypedIds;
using MongoDB.Driver;

namespace Infrastructure.Mongo
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMongoCollection<Message> _collection;

        public MessageRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Message>("messages");
        }

        public async Task<Message?> GetByIdAsync(MessageId id)
        {
            var filter = Builders<Message>.Filter.Eq(m => m.Id.Value, id.Value);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Message message)
        {
            await _collection.InsertOneAsync(message);
        }

        public async Task<IEnumerable<Message>> GetMessagesForUserAsync(UserId userId)
        {
            var filter = Builders<Message>.Filter.Or(
                Builders<Message>.Filter.Eq(m => m.SenderId.Value, userId.Value),
                Builders<Message>.Filter.Eq(m => m.RecipientId.Value, userId.Value)
            );
            return await _collection.Find(filter).ToListAsync();
        }
    }
}