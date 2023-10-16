using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface IUserService
    {
        Task<Response<UserDto>> GetByIdAsync(int id);
        Task<Response<List<UserDto>>> GetAllAsync();
        Task<Response<UserDto>> CreateAsync(UserCreateDto userCreateDto);
        Task<Response<NoContent>> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<UserDto>> GetByUsername(string username);
        Task<Response<List<UserRole>>> GetUserRoles(int id);
        Task<int> UserCount();
        Task<Response<List<UserDto>>> LastUsers();
    }   
}