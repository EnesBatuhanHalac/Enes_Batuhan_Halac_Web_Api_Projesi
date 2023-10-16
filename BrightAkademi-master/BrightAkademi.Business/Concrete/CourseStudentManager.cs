using AutoMapper;
using BrightAkademi.Business.Abstract;
using BrightAkademi.Data.Abstract;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Concrete
{
    public class CourseStudentManager : ICourseStudentService
    {
        private readonly ICourseStudentRepository _courseStudentRepository;
        private readonly IMapper _mapper;

        public CourseStudentManager(ICourseStudentRepository courseStudentRepository, IMapper mapper)
        {
            _courseStudentRepository = courseStudentRepository;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> Create(CourseStudentDto dto )
        {
            var coursestudent = _mapper.Map<CourseStudent>(dto);
            await _courseStudentRepository.CreateAsync(coursestudent);
            return Response<NoContent>.Success(_mapper.Map<NoContent>(coursestudent), 201);
        }
    }
}
