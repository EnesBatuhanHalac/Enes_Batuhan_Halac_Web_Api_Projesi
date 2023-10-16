using BrightAkademi.Entity.Concrete;

namespace BrightAkademi.Data.Abstract
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<bool> AnyAsync(int id);
    }
}
