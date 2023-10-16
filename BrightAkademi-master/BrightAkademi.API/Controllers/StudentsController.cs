using BrightAkademi.Business.Abstract;
using BrightAkademi.Shared.ControllerBases;
using BrightAkademi.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BrightAkademi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : CustomControllerBase
    {
        private readonly IStudentService _studentManager;

        public StudentsController(IStudentService studentManager)
        {
            _studentManager = studentManager;
        }

        [HttpGet]
        [Authorize(Roles = "Super Admin,Admin,Trainer")]
        public async Task<IActionResult> GetStudents()
        {
            var response = await _studentManager.GetAllAsync();
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdStudent(int id)
        {
            var response = await _studentManager.GetByIdAsync(id);
            if (response.IsSucceeded)
            {
                //var jsonResult = JsonSerializer.Serialize(response);
                return Ok(response);
            }
            return NotFound();
        }      
        
        [HttpGet("getByCourseId/{id}")]
        [Authorize(Roles ="Trainer")]
        public async Task<IActionResult> GetByCourseId(int id)
            {
            var response = await _studentManager.GetByCourseIdAsync(id);
            if (response.IsSucceeded)
            {
                //var jsonResult = JsonSerializer.Serialize(response);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var response = await _studentManager.CreateAsync(studentCreateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> UpdateStudent(StudentUpdateDto studentUpdateDto)
        {
            var response = await _studentManager.UpdateAsync(studentUpdateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var response = await _studentManager.DeleteAsync(id);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }
    }
}