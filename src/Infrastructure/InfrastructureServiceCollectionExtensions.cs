using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Data;
using Infrastructure.Mongo;
using Infrastructure.Redis;
using Domain.Repositories;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("Postgres")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // MongoDB
            var mongoClient = new MongoClient(config.GetConnectionString("Mongo"));
            var mongoDatabase = mongoClient.GetDatabase("appdb");
            services.AddSingleton<IMongoDatabase>(mongoDatabase);
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Redis
            services.AddSingleton<RedisCacheService>();

            return services;
        }
    }
}