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
    public class TeachersController : CustomControllerBase
    {
        private readonly ITeacherService _teacherManager;

        public TeachersController(ITeacherService teacherManager)
        {
            _teacherManager = teacherManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var response = await _teacherManager.GetAllAsync();
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTeacher(int id)
        {
            var response = await _teacherManager.GetByIdAsync(id);
            if (response.IsSucceeded)
            {
                //var jsonResult = JsonSerializer.Serialize(response);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> CreateTeacher(TeacherCreateDto teacherCreateDto)
        {
            var response = await _teacherManager.CreateAsync(teacherCreateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> UpdateTeacher(TeacherUpdateDto teacherUpdateDto)
        {
            var response = await _teacherManager.UpdateAsync(teacherUpdateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var response = await _teacherManager.DeleteAsync(id);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }
    }
}