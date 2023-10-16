using BrightAkademi.Entity.Concrete;

namespace BrightAkademi.Data.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<List<User>> LastUsers();
        Task<int> UserCount();
    }
}