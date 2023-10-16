using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Repositories
{
    public class EfCoreUserRepository : EfCoreGenericRepository<User>, IUserRepository
    {
        private readonly BrightAkademiContext _context;
        public EfCoreUserRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

        public Task<User> GetByUsernameAsync(string username)
        {
            return  _context
               .Users
               .FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<List<User>> LastUsers()
        {
            return _context
           .Users
           .OrderBy(x => x.CreatedDate).Take(5).ToList();
        }

        public Task<int> UserCount()
        {
           return _context.Users.CountAsync();
        }
    }
}