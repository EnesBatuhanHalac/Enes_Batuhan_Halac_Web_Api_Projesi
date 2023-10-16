using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface ICourseService
    {
        Task<Response<CourseDto>> GetByIdAsync(int id);
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateeDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<List<CourseDto>>> GetByStudentIdAsync(int studentId);
        Task<Response<List<CourseDto>>> GetByTeacherId(int idteacherId);
        Task<Response<List<CourseDto>>> GetCoursesWithDetail(int? categoryId);
        Task<int> CourseCount();
        Task<Response<List<CourseDto>>> TopCourses();
        Task<Response<List<CourseDto>>> GetStudentCourseToRegister(int id);
    }
}