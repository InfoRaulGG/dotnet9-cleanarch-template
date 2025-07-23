using Domain.Entities;
using Domain.TypedIds;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(UserId id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(UserId id);
    }
}