using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface ICourseStudentService
    {
        Task<Response<NoContent>> Create(CourseStudentDto dto);
    }
}