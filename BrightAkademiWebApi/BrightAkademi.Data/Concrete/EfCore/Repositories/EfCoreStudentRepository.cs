using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BrightAkademi.Data.Concrete.EfCore.Repositories
{
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        private readonly BrightAkademiContext _context;

        public EfCoreStudentRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context
                .Students
                .AnyAsync(x => x.Id == id);
        }

        public  Task<List<Student>> GetByCourseIdAsync(int courseId)
        {
            return _context
                  .Students.Include(i => i.CourseStudents).Where(w => w.CourseStudents.Select(s => s.CourseId).Contains(courseId))
                  .ToListAsync();
        }

        public async Task<List<Student>> GetByTeacherId(int id)
            {
            var courseIds = await _context.Courses
             .Include(x => x.TeacherCourses)
             .Where(w => w.TeacherCourses.Select(s => s.TeacherId).Contains(id))
             .Select(s => s.Id)
             .ToListAsync();



            var students = _context.CourseStudents
                .Include(i => i.Course)
                .Include(i => i.Student)
                .Where(w => courseIds.Contains(w.CourseId.Value)).Select(s=>s.Student).ToList();

            return students;
        }

        public Task<Student> GetByUserIdAsync(int userId)
        {
            return _context
                 .Students
                 .FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<int> StudentCount()
        {
            return _context
                .Students.Count();
        }
    }
}