using AutoMapper;
using BrightAkademi.Business.Abstract;
using BrightAkademi.Business.Concrete;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.ControllerBases;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace BrightAkademi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : CustomControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;
        private readonly IStudentService _studentService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IConfiguration configuration, IRoleService roleService, IStudentService studentService, IMapper mapper, IUserRoleService userRoleService)
        {
            _userService = userService;
            _configuration = configuration;
            _roleService = roleService;
            _studentService = studentService;
            _mapper = mapper;
            _userRoleService = userRoleService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLogin)  
        {
            var user = await _userService.GetByUsername(userLogin.Username);

            if (!user.IsSucceeded)
            {
                return BadRequest(new CustomResponse { StatusCode=404, Message="User Not Found"});
            }           
            if (user.Data.Password != userLogin.Password)
            {
                return BadRequest(new CustomResponse { StatusCode = 400, Message = "Password incorrect" });
            }
            var userRoles = await _userService.GetUserRoles(user.Data.Id);

            DateTime expireDate;
            JwtSecurityToken token;
            createToken(user.Data.Username, userRoles.Data.Select(s=>s.Role.Name).ToList(),
                out expireDate, out token, user.Data.Firstname, user.Data.Lastname);

            return Ok(new
            {
                ExpireDate = expireDate,    
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Roles = userRoles.Data.Select(x => x.Role.Name),
                Username = user.Data.Username,
                Name = user.Data.Firstname+" "+user.Data.Lastname
            }); ;



        }
                
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {

            var user = await _userService.GetByUsername(dto.Username);

            if (user.IsSucceeded)
            {
                return BadRequest(new CustomResponse { StatusCode = 404, Message = "User Already Exist" });
            }
            var student = new Student
            {
                User = new User
                {
                    Firstname = dto.FirstName,
                    Lastname = dto.LastName,
                    Username = dto.Username,
                    Password = dto.Password
                }
            };
            var response = _studentService.CreateAsync(_mapper.Map<StudentCreateDto>(student));
            var userRoles = new List<string> {"Trainee"};
            DateTime expireDate;
            JwtSecurityToken token;
            createToken(student.User.Username, userRoles, out expireDate, out token, student.User.Firstname, student.User.Lastname);

            return Ok(new
            {
                ExpireDate = expireDate,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Roles = userRoles,
                Username = dto.Username,
                Name = student.User.Firstname + " " + student.User.Lastname

            }); ;



        }
            
        [Authorize(Roles ="Super Admin")]
        [HttpPut("changeRole")]
        public async Task<IActionResult> ChangeRole(UserRoleDto dto)
        {

            var response =await _userRoleService.UpdateAsync(dto);
            return CreateActionResult(response);

        }

        private void createToken(string username, List<string> userRoles, out DateTime expireDate, out JwtSecurityToken token,string firstname, string lastname)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Name, firstname+" "+lastname),

            };

            userRoles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));


            expireDate = DateTime.Now.AddMinutes(30);
            token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expireDate,
                signingCredentials: credentals);
        }

        [Authorize(Roles="Super Admin")]
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _roleService.GetAllAsync();
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return NotFound();

        }
        
                
        [Authorize(Roles= "Super Admin")]
        [HttpPost("roles")]
        public async Task<IActionResult> CreateRole(RoleDto roleDto)
        {
            var response = await _roleService.CreateAsync(roleDto);
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return BadRequest(response);

        }    
        
        [Authorize(Roles= "Super Admin")]
        [HttpPut("roles")]
        public async Task<IActionResult> UpdateRole(RoleDto roleDto)
        {
            var response = await _roleService.UpdateAsync(roleDto);
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return BadRequest(response);

        } 
        
        [Authorize(Roles= "Super Admin")]
        [HttpDelete("roles")]
        public async Task<IActionResult> DeleteRole(RoleDto roleDto)
        {
            var response = await _roleService.DeleteAsync(roleDto.Id);
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return BadRequest(response);

        }  
        
        [Authorize(Roles= "Super Admin")]
        [HttpGet("roles/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var response = await _roleService.GetByIdAsync(id);
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return BadRequest(response);

        }
        


        }

}
