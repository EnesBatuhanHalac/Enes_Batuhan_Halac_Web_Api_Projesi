using BrightAkademi.Entity.Concrete;

namespace BrightAkademi.Data.Abstract
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        Task<List<UserRole>> GetUserRoles(int userId);
    }     
}