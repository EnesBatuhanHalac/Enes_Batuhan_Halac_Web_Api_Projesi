using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Repositories
{
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        private readonly BrightAkademiContext _context;

        public EfCoreTeacherRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context
                .Teachers
                .AnyAsync(x => x.Id == id);
        }

        public async Task<int> TeacherCount()
        {
            return _context
                .Teachers
                .Count(); 
        }
    }
}