using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Redis
{
    public class RedisCacheService
    {
        private readonly IDatabase _database;

        public RedisCacheService(IConfiguration configuration)
        {
            var redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            _database = redis.GetDatabase();
        }

        public async Task SetAsync(string key, string value)
        {
            await _database.StringSetAsync(key, value);
        }

        public async Task<string?> GetAsync(string key)
        {
            return await _database.StringGetAsync(key);
        }
    }
}