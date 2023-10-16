using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Repositories
{
    public class EfCoreLevelRepository : EfCoreGenericRepository<Level>, ILevelRepository
    {
        private readonly BrightAkademiContext _context;
        public EfCoreLevelRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context
               .Levels
               .AnyAsync(x => x.Id == id);
        }
    }      
} 
