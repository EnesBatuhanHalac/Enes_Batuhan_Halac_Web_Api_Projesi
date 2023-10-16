using AutoMapper;
using BrightAkademi.Business.Abstract;
using BrightAkademi.Data.Abstract;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleManager(IMapper mapper, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Response<RoleDto>> CreateAsync(RoleDto dto)
        {
            var newDto = _mapper.Map<Role>(dto);
            await _roleRepository.CreateAsync(newDto);
            return Response<RoleDto>.Success(_mapper.Map<RoleDto>(newDto), 201);
        }

        public Task<Response<NoContent>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<RoleDto>>> GetAllAsync()
        {
            var rolelist = await _roleRepository.GetAllAsync();
            if (rolelist == null)
            {
                return Response<List<RoleDto>>.Fail("Hiç seviye bulunamadı", 301);
            }
            var roles = _mapper.Map<List<RoleDto>>(rolelist);
            return Response<List<RoleDto>>.Success(roles, 200);
        }

        public async Task<Response<RoleDto>> GetByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return Response<RoleDto>.Fail("Böyle bir seviye yok!", 301);
            }
            var roleDto = _mapper.Map<RoleDto>(role);
            return Response<RoleDto>.Success(roleDto, 200);
        }


        public async Task<Response<List<UserRole>>> GetUserRoles(int userId)
        {
            var userRoles =await _userRoleRepository.GetUserRoles(userId);
            return Response<List<UserRole>>.Success(userRoles, 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(RoleDto roleDto)
        {
            var isThere = await _roleRepository.GetByIdAsync(roleDto.Id);
            if (isThere != null)
            {
                var role = _mapper.Map<Role>(roleDto);
                role.ModifiedDate = DateTime.Now;
                _roleRepository.Update(role);
                return Response<NoContent>.Success(200);
                //return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Böyle bir seviye bulunamadı", 401);
        }
    }
}
