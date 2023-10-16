using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface IRoleService
    {
        Task<Response<RoleDto>> GetByIdAsync(int id);
        Task<Response<List<RoleDto>>> GetAllAsync();
        Task<Response<RoleDto>> CreateAsync(RoleDto roleDto);
        Task<Response<NoContent>> UpdateAsync(RoleDto roleDto);
        Task<Response<NoContent>> DeleteAsync(int id);
    }     
}