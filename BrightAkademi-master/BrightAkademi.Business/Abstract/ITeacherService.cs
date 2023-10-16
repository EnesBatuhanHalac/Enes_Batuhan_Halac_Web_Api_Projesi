using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface ITeacherService
    {
        Task<Response<TeacherDto>> GetByIdAsync(int id);
        Task<Response<List<TeacherDto>>> GetAllAsync();
        Task<Response<TeacherDto>> CreateAsync(TeacherCreateDto teacherCreateDto);
        Task<Response<NoContent>> UpdateAsync(TeacherUpdateDto teacherUpdateeDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<int> TeacherCount();
    }
}