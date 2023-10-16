using BrightAkademi.Entity.Concrete;

namespace BrightAkademi.Data.Abstract
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<bool> AnyAsync(int id);
        Task<List<Student>> GetByCourseIdAsync(int courseId);
        Task<List<Student>> GetByTeacherId(int id);
        Task<Student> GetByUserIdAsync(int id);
        Task<int> StudentCount();
    }
}