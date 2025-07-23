using Domain.Entities;
using Domain.Repositories;
using Domain.TypedIds;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(UserId id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id.Value == id.Value);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
        }

        public async Task DeleteAsync(UserId id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
                _context.Users.Remove(user);
        }
    }
}