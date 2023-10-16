using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface ILevelService
    {
        Task<Response<LevelDto>> GetByIdAsync(int id);
        Task<Response<List<LevelDto>>> GetAllAsync();
        Task<Response<LevelDto>> CreateAsync(LevelCreateDto levelCreateDto);
        Task<Response<NoContent>> UpdateAsync(LevelUpdateDto levelUpdateeDto);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}