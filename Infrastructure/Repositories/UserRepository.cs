using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private readonly PdvContext _context;

        public UserRepository(PdvContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserEntity?> FindByLoginAsync(string login, string password)
        {
            var result = await _context.User.FirstOrDefaultAsync(x => x.Login.ToLower() == login.ToLower() && x.Password == password);

            return result;
        }

    }
}
