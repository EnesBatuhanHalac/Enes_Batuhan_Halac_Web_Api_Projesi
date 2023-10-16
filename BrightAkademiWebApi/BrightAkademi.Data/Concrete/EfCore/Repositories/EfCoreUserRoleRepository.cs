using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Data.Concrete.EfCore.Repositories;
using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

public class EfCoreUserRoleRepository : EfCoreGenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly BrightAkademiContext _context;
        public EfCoreUserRoleRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

    public async Task<List<UserRole>> GetUserRoles(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x =>x.Id== userId );
        if (user != null)
        {
            return  _context.UserRoles.Include(x=>x.Role).Where(w=>w.UserId== userId).ToList();

        }
        return null;
    }
}  
