using BrightAkademi.Entity.Concrete;

namespace BrightAkademi.Data.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> AnyAsync(int id);
        Task<int> CategoryCount();
    }
}
