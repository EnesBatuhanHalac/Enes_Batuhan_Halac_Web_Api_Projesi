using BrightAkademi.Data.Abstract;
using BrightAkademi.Data.Concrete.EfCore.Contexts;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightWeb.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BrightAkademi.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCourseRepository : EfCoreGenericRepository<Course>, ICourseRepository
    {
        private readonly BrightAkademiContext _context;
        public EfCoreCourseRepository(BrightAkademiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context
                .Courses
                .AnyAsync(x => x.Id == id);
        }

        public async Task<int> CourseCount()
        {
            return  _context
                .Courses.Count();
        }

        public async Task<List<Course>> GetByStudentIdAsync(int studentId)
        {

            return await _context.Courses.Include(x => x.CourseStudents).Where(w => w.CourseStudents.Select(s=>s.StudentId).Contains(studentId)).ToListAsync();
        }

        public async Task<List<Course>> GetByTeacherId(int teacherId)
        {
            return await _context.Courses
                .Include(x => x.TeacherCourses).Where(w => w.TeacherCourses.Select(s => s.TeacherId).Contains(teacherId)).ToListAsync();
        }

        public async Task<List<Course>> GetCoursesWithDetail(int? categoryId)
        {
            var q =  _context.Courses
                .Include(x => x.Teacher)
                .Include(x => x.Company)
                .Include(x => x.Level)
                .Include(x => x.Category);
            return categoryId== 0? await q.ToListAsync() :await q.Where(x=>x.CategoryId==categoryId.Value).ToListAsync(); 
        }

        public async Task<List<Course>> GetStudentCourseToRegister(int id)
        {
            return await _context.Courses
                .Include(x => x.CourseStudents)
                .Where(w => !w.CourseStudents
                .Select(s => s.StudentId).Contains(id)).ToListAsync();
        }

        public async Task<List<Course>> TopCourses()
        {
            return _context.Courses.Take(5).ToList();
        }
    }
}