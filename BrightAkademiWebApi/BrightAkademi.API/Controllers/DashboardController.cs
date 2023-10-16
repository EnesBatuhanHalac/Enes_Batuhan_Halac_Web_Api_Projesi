using BrightAkademi.Business.Abstract;
using BrightAkademi.Shared.ControllerBases;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BrightAkademi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : CustomControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly ICategoryService _categoryService;
        private readonly ILevelService _levelService;
        private readonly IConfiguration _configuration;

        public DashboardController(IUserService userService,
            IConfiguration configuration, ITeacherService teacherService, IStudentService studentService, ICourseService courseService, ICategoryService categoryService, ILevelService levelService)
        {
            _userService = userService;
            _configuration = configuration;
            _teacherService = teacherService;
            _studentService = studentService;
            _courseService = courseService;
            _categoryService = categoryService;
            _levelService = levelService;
        }



        [Authorize(Roles= "Super Admin")]
        [HttpGet("SuperAdmin")]
        public async Task<IActionResult> SuperAdmin()
        {
            var totalCourse = await _courseService.CourseCount();
            var totalStudent = await _studentService.StudentCount();
            var totalTeacher = await _teacherService.TeacherCount();
            var totalUser = await _userService.UserCount();
            var lastUsers = await _userService.LastUsers();


            var dashboard = new SuperAdminDto
            {
                TotalCourses = totalCourse,
                TotalStudent = totalStudent,
                TotalTeachers = totalTeacher,
                TotalUsers = totalUser,
                LastUsers = lastUsers.Data
            };

            return Ok(dashboard);

        }
        
                
        [Authorize(Roles= "Admin")]
        [HttpGet("Admin")]
        public async Task<IActionResult> Admin()
        {
            var totalCourse = await _courseService.CourseCount();
            var totalStudent = await _studentService.StudentCount();
            var totalTeachers = await _teacherService.TeacherCount();
            var totalCategories = await _categoryService.CategoryCount();

            var topCourses = await _courseService.TopCourses();


            var dashboard = new AdminDto
            {
                TotalCourses = totalCourse,
                TotalStudents = totalStudent,
                TotalTeachers = totalTeachers,
                TotalCategories = totalCategories,
                TopCourses = topCourses.Data
            };

            return Ok(dashboard);

        }
        
                
        [Authorize(Roles= "Trainer")]
        [HttpGet("Trainer")]
        public async Task<IActionResult> Trainer()
        {

            var username = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = _userService.GetByUsername(username).Result.Data;
            var teacher = _teacherService.GetByIdAsync(user.Id).Result.Data;

            var totalCourse = await _courseService.CourseCount();
            var totalStudent = await _studentService.StudentCount();
            var totalCategories = await _categoryService.CategoryCount();
            var totalLevels = await _levelService.GetAllAsync();

            var myCourses = await _courseService.GetByTeacherId(teacher.Id);
            var myStudent = await _studentService.GetByTeacherId(teacher.Id);


            var dashboard = new TrainerDto
            {
                TotalCourses = totalCourse,
                TotalStudents = totalStudent,
                TotalCategories = totalCategories,
                TotalLevels = totalLevels.Data.Count,
                MyCourses = myCourses.Data,
                MyStudents = myStudent.Data
            };

            return Ok(dashboard);

        }


        [Authorize(Roles= "Trainee")]
        [HttpGet("Trainee")]
        public async Task<IActionResult> Trainee()
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = _userService.GetByUsername(username).Result.Data;
            var student = _studentService.GetByUserIdAsync(user.Id).Result.Data;


            var totalCourse = await _courseService.CourseCount();
            var totalStudent = await _studentService.StudentCount();
            var totalCategories = await _categoryService.CategoryCount();
            var totalTeachers = await _teacherService.TeacherCount();
            var totalLevels = await _levelService.GetAllAsync();

            var myCourses = await _courseService.GetByStudentIdAsync(student.Id);


            var dashboard = new TraineeDto
            {
                TotalCourses = totalCourse,
                TotalTeachers = totalStudent,
                TotalCategories = totalCategories,
                TotalLevels = totalLevels.Data.Count,
                MyCourses = myCourses.Data,
            };

            return Ok(dashboard);


        }



    }

}
