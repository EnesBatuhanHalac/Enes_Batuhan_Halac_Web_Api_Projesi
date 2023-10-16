using BrightAkademi.Entity.Concrete;

namespace BrightAkademi.Data.Abstract
{
    public interface ILevelRepository : IGenericRepository<Level>
    {
        Task<bool> AnyAsync(int id);
    }     
}