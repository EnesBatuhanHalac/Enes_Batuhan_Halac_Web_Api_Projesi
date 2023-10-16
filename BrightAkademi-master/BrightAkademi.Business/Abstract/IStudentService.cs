using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface IStudentService
    {
        Task<Response<StudentDto>> GetByIdAsync(int id);
        Task<Response<StudentDto>> GetByUserIdAsync(int id);
        Task<Response<List<StudentDto>>> GetAllAsync();
        Task<Response<StudentDto>> CreateAsync(StudentCreateDto studentCreateDto);
        Task<Response<NoContent>> UpdateAsync(StudentUpdateDto studentUpdateeDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<List<StudentDto>>> GetByCourseIdAsync(int courseId);
        Task<int> StudentCount();
        Task<Response<List<StudentDto>>> GetByTeacherId(int id);
    }
}