using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCourseStudentRepository : EfCoreGenericRepository<CourseStudent>, ICourseStudentRepository
    {

        private readonly BrightAkademiContext _context;
        public EfCoreCourseStudentRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

    }   
} 
