using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Abstract
{
    public interface ICompanyService
    {
        Task<Response<CompanyDto>> GetByIdAsync(int id);
        Task<Response<List<CompanyDto>>> GetAllAsync();
        Task<Response<CompanyDto>> CreateAsync(CompanyCreateDto companyCreateDto);
        Task<Response<NoContent>> UpdateAsync(CompanyUpdateDto companyUpdateDto);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}