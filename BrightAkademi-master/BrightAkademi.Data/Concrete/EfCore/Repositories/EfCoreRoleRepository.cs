using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Data.Concrete.EfCore.Repositories;
using BrightAkademi.Entity.Concrete;

public class EfCoreRoleRepository : EfCoreGenericRepository<Role>, IRoleRepository
{
        private readonly BrightAkademiContext _context;
        public EfCoreRoleRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

}  
   
