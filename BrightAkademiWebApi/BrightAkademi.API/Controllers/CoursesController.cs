using BrightAkademi.Business.Abstract;
using BrightAkademi.Shared.ControllerBases;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace BrightAkademi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomControllerBase
    {
        private readonly ICourseService _courseManager;
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseStudentService _courseStudentService;

        public CoursesController(ICourseService courseManager, IUserService userService, IStudentService studentService, ITeacherService teacherService, ICourseStudentService courseStudentService)
        {
            _courseManager = courseManager;
            _userService = userService;
            _studentService = studentService;
            _teacherService = teacherService;
            _courseStudentService = courseStudentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCourses()
        {
            var response = await _courseManager.GetAllAsync();
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return NotFound();
        }         
        
        [HttpGet("detailList/{categoryId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCoursesWithDetail(int? categoryId)
        {
            var response = await _courseManager.GetCoursesWithDetail(categoryId);
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return NotFound();
        }      
        
        [HttpGet("studentCourses/{studentId}")]
        public async Task<IActionResult> GetStudentCourses(int studentId)
        {
            var response = await _courseManager.GetByStudentIdAsync(studentId);
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return NotFound();
        }    
        
        [HttpGet("myCourses")]
        [Authorize(Roles = "Trainee")]
        public async Task<IActionResult> GetMyCourses()
        {

            var username = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            var user = _userService.GetByUsername(username).Result.Data;
            var student = _studentService.GetByIdAsync(user.Id).Result.Data;
            if (user != null)
            {
                var response =await _courseManager.GetByStudentIdAsync(student.Id);
                if (response.IsSucceeded)
                {
                    //return new JsonResult(response);
                    return Ok(response);
                }
            }
      
            return NotFound();
        }
                  
        [HttpGet("toRegister")]
        [Authorize(Roles = "Trainee")]
        public async Task<IActionResult> GetStudentCourseToRegister()
        {

            var username = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            var user = _userService.GetByUsername(username).Result.Data;
            var student = _studentService.GetByIdAsync(user.Id).Result.Data;
            if (user != null)
            {
                var response =await _courseManager.GetStudentCourseToRegister(student.Id);
                if (response.IsSucceeded)
                {
                    //return new JsonResult(response);
                    return Ok(response);
                }
            }
      
            return NotFound();
        }
               
        [HttpGet("teachercourses")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> GetTeacherCourses()
            {

            var username = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
           
            var user = _userService.GetByUsername(username).Result.Data;
            var teacher = _teacherService.GetByIdAsync(user.Id).Result.Data;
            if (user != null)
            {
                var response =await _courseManager.GetByTeacherId(teacher.Id);
                if (response.IsSucceeded)
                {
                    //return new JsonResult(response);
                    return Ok(response);
                }
            }
      
            return NotFound();
        }
                
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCourse(int id)
        {
            var response = await _courseManager.GetByIdAsync(id);
            if (response.IsSucceeded)
            {
                //var jsonResult = JsonSerializer.Serialize(response);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> CreateCourse(CourseCreateDto courseCreateDto)
        {
            var response = await _courseManager.CreateAsync(courseCreateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> UpdateCourse(CourseUpdateDto courseUpdateDto)
        {
            var response = await _courseManager.UpdateAsync(courseUpdateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var response = await _courseManager.DeleteAsync(id);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }       
        
        [HttpGet("register/{courseId}")]
        [Authorize(Roles = "Super Admin,Admin,Trainee")]
        public async Task<IActionResult> RegisterToCourse(int courseId)
        {

            var username = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = _userService.GetByUsername(username).Result.Data;
            var student = _studentService.GetByIdAsync(user.Id).Result.Data;

            var dto = new CourseStudentDto
            {
                CourseId = courseId,
                StudentId = student.Id,
            };
            var response = await _courseStudentService.Create(dto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }


      
    }
}