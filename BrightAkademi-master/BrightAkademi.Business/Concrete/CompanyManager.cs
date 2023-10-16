using AutoMapper;
using BrightAkademi.Business.Abstract;
using BrightAkademi.Data.Abstract;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyManager(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Response<CompanyDto>> CreateAsync(CompanyCreateDto companyCreateDto)
        {
            var result = _mapper.Map<Company>(companyCreateDto);
            await _companyRepository.CreateAsync(result);
            return Response<CompanyDto>.Success(_mapper.Map<CompanyDto>(result), 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var result = await _companyRepository.GetByIdAsync(id);
            if (result == null)
            {
                return Response<NoContent>.Fail("Böyle bir şirket yok.", 401);
            }
            _companyRepository.Delete(result);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<CompanyDto>>> GetAllAsync()
        {
            var categoryList = await _companyRepository.GetAllAsync();
            if (categoryList == null)
            {
                return Response<List<CompanyDto>>.Fail("Hiç şirket bulunamadı", 301);
            }
            var categoryDtoList = _mapper.Map<List<CompanyDto>>(categoryList);
            return Response<List<CompanyDto>>.Success(categoryDtoList, 200);
        }

        public async Task<Response<CompanyDto>> GetByIdAsync(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return Response<CompanyDto>.Fail("Böyle bir şirket yok!", 301);
            }
            var companyDto = _mapper.Map<CompanyDto>(company);
            return Response<CompanyDto>.Success(companyDto, 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CompanyUpdateDto companyUpdateDto)
        {
            var isThere = await _companyRepository.AnyAsync(companyUpdateDto.Id);
            if (isThere)
            {
                var company = _mapper.Map<Company>(companyUpdateDto);
                company.ModifiedDate = DateTime.Now;
                _companyRepository.Update(company);
                //return Response<NoContent>.Success(204);
                return Response<NoContent>.Success(200);
            }
            return Response<NoContent>.Fail("Böyle bir şirket bulunamadı", 401);
        }
    }
}