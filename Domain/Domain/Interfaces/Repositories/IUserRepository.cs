using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity?> FindByLoginAsync(string login, string password);
    }
}
