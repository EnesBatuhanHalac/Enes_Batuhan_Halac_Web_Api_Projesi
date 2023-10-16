using AutoMapper;
using BrightAkademi.Business.Abstract;
using BrightAkademi.Data.Abstract;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Concrete
{
    public class LevelManager : ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public LevelManager(ILevelRepository levelRepository, IMapper mapper)
        {
            _levelRepository = levelRepository;
            _mapper = mapper;
        }

        public async Task<Response<LevelDto>> CreateAsync(LevelCreateDto levelCreateDto)
        {
            var newLevel = _mapper.Map<Level>(levelCreateDto);
            await _levelRepository.CreateAsync(newLevel);
            return Response<LevelDto>.Success(_mapper.Map<LevelDto>(newLevel), 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var deletedLevel = await _levelRepository.GetByIdAsync(id);
            if (deletedLevel == null)
            {
                return Response<NoContent>.Fail("Böyle bir seviye yok", 401);
            }
            _levelRepository.Delete(deletedLevel);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<LevelDto>>> GetAllAsync()
        {
            var levelList = await _levelRepository.GetAllAsync();
            if (levelList == null)
            {
                return Response<List<LevelDto>>.Fail("Hiç seviye bulunamadı", 301);
            }
            var levelDtoList = _mapper.Map<List<LevelDto>>(levelList);
            return Response<List<LevelDto>>.Success(levelDtoList, 200);
        }

        public async Task<Response<LevelDto>> GetByIdAsync(int id)
        {
            var level = await _levelRepository.GetByIdAsync(id);
            if (level == null)
            {
                return Response<LevelDto>.Fail("Böyle bir seviye yok!", 301);
            }
            var levelDto = _mapper.Map<LevelDto>(level);
            return Response<LevelDto>.Success(levelDto, 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(LevelUpdateDto levelUpdateDto)
        {
            var isThere = await _levelRepository.AnyAsync(levelUpdateDto.Id);
            if (isThere)
            {
                var level = _mapper.Map<Level>(levelUpdateDto);
                level.ModifiedDate = DateTime.Now;
                _levelRepository.Update(level);
                return Response<NoContent>.Success(200);
                //return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Böyle bir seviye bulunamadı", 401);
        }
    }
}
