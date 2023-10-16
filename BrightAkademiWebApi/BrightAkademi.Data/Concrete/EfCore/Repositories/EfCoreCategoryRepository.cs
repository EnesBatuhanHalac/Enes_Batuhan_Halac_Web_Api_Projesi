using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        private readonly BrightAkademiContext _context;
        public EfCoreCategoryRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context
                .Categories
                .AnyAsync(x => x.Id == id);
        }

        public async Task<int> CategoryCount()
        {
            return _context
                .Categories
                .Count();
        }
    }
}