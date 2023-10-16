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
    public class CompaniesController : CustomControllerBase
    {
        private readonly ICompanyService _companyManager;

        public CompaniesController(ICompanyService companyManager)
        {
            _companyManager = companyManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var response = await _companyManager.GetAllAsync();
            if (response.IsSucceeded)
            {
                //return new JsonResult(response);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCompany(int id)
        {
            var response = await _companyManager.GetByIdAsync(id);
            if (response.IsSucceeded)
            {
                //var jsonResult = JsonSerializer.Serialize(response);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> CreateCompany(CompanyCreateDto companyCreateDto)
        {
            var response = await _companyManager.CreateAsync(companyCreateDto);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> UpdateCompany(CompanyUpdateDto companyUpdateDto)
            {
            var response = await _companyManager.UpdateAsync(companyUpdateDto);
            if (response.IsSucceeded)
            {
                //return CreateActionResult(response);
               return Ok(response);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Super Admin,Admin")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var response = await _companyManager.DeleteAsync(id);
            if (response.IsSucceeded)
            {
                return CreateActionResult(response);
            }
            return BadRequest();
        }
    }
}