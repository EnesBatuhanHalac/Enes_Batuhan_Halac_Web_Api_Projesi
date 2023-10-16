using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface ICategoryService
    {
        #region Generic
        Task<Response<CategoryDto>> GetByIdAsync(int id);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<Response<NoContent>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<int> CategoryCount();
        #endregion
    }
}
