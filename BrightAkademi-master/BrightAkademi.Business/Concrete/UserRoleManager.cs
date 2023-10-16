using AutoMapper;
using BrightAkademi.Business.Abstract;
using BrightAkademi.Data.Abstract;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleManager(IUserRoleRepository userRoleService, IMapper mapper)
        {
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> UpdateAsync(UserRoleDto dto)
        {
            var userRole = _mapper.Map<UserRole>(dto);
             _userRoleService.Update(userRole);

            return Response<NoContent>.Success(201);
        }
    }
}
