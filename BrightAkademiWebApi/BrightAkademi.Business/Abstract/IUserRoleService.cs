using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface IUserRoleService
    {
 
        Task<Response<NoContent>> UpdateAsync(UserRoleDto dto);
    }  
}