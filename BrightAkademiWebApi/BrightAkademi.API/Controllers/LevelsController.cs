using BrightAkademi.Business.Abstract;
using BrightAkademi.Shared.ControllerBases;
using BrightAkademi.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BrightAkademi.API.Controllers
{
    [ApiController]
    [Route("api/levels")]
    public class LevelsController : CustomControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelsController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLevels()
        {
            var response = await _levelService.GetAllAsync();
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdLevels(int id)
        {
            var response = await _levelService.GetByIdAsync(id);
            if (response.IsSucceeded)
            {
                //var jsonResult = JsonSerializer.Serialize(response);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> CreateLevel(LevelCreateDto levelCreateDto)
        {
            var response = await _levelService.CreateAsync(levelCreateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> UpdateLevel(LevelUpdateDto levelUpdateDto)
        {
            var response = await _levelService.UpdateAsync(levelUpdateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> DeleteCategories(int id)
        {
            var response = await _levelService.DeleteAsync(id);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }
    }
}
