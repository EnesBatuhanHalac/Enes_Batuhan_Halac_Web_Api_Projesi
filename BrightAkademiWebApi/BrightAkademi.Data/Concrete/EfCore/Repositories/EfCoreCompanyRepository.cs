using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCompanyRepository : EfCoreGenericRepository<Company>, ICompanyRepository
    {
        private readonly BrightAkademiContext _context;

        public EfCoreCompanyRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context
                .Companies
                .AnyAsync(x => x.Id == id);
        }
    }
}
