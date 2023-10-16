using BrightAkademi.Business.Abstract;
using BrightAkademi.Shared.ControllerBases;
using BrightAkademi.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BrightAkademi.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryManager.GetAllAsync();
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategories(int id)
        {
            var response = await _categoryManager.GetByIdAsync(id);
            if (response.IsSucceeded)
            {
                //var jsonResult = JsonSerializer.Serialize(response);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> CreateCategories(CategoryCreateDto categoryCreate)
        {
            var response = await _categoryManager.CreateAsync(categoryCreate);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> UpdateCategories(CategoryUpdateDto categoryUpdateDto)
        {
            var response = await _categoryManager.UpdateAsync(categoryUpdateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> DeleteCategories(int id)
        {
            var response = await _categoryManager.DeleteAsync(id);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }
    }
}
