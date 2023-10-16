using AutoMapper;
using BrightAkademi.Business.Abstract;
using BrightAkademi.Data.Abstract;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;
using BrightWeb.Entity.Concrete;

namespace BrightAkademi.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public CourseManager(ICourseRepository courseRepository, ICompanyRepository companyRepository, ICategoryRepository categoryRepository, ILevelRepository levelRepository, ITeacherRepository teacherRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _companyRepository = companyRepository;
            _categoryRepository = categoryRepository;
            _levelRepository = levelRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public  async Task<int> CourseCount()
        {
           return await  _courseRepository.CourseCount();
        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            try
            {
                var newCourse = _mapper.Map<Course>(courseCreateDto);
                newCourse.CreatedDate = DateTime.Now;
                newCourse.Company = await _companyRepository.GetByIdAsync(newCourse.CompanyId);
                newCourse.Category = await _categoryRepository.GetByIdAsync(newCourse.CategoryId);
                newCourse.Level = await _levelRepository.GetByIdAsync(newCourse.LevelId);
                newCourse.Teacher = await _teacherRepository.GetByIdAsync(newCourse.TeacherId);

                // Diğer özellikleri de doldurun...

                await _courseRepository.CreateAsync(newCourse);
                var courseDto = _mapper.Map<CourseDto>(newCourse);
                return Response<CourseDto>.Success(courseDto, 201);
            }
            catch (Exception ex)
            {
                return Response<CourseDto>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            try
            {
                var deleteCourse = await _courseRepository.GetByIdAsync(id);
                if (deleteCourse == null)
                {
                    return Response<NoContent>.Fail($"Course with ID {id} not found", 404);
                }

                // Kursu silme işlemini gerçekleştirin
                 _courseRepository.Delete(deleteCourse);

                return Response<NoContent>.Success(null, 200);
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            try
            {
                var courses = await _courseRepository.GetAllAsync();
                var courseDtos = _mapper.Map<List<CourseDto>>(courses);
                return Response<List<CourseDto>>.Success(courseDtos, 200);
            }
            catch (Exception ex)
            {
                return Response<List<CourseDto>>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<CourseDto>> GetByIdAsync(int id)
        {
            try
            {
                var course = await _courseRepository.GetByIdAsync(id);
                if (course == null)
                {
                    return Response<CourseDto>.Fail($"Course with ID {id} not found", 404);
                }

                var courseDto = _mapper.Map<CourseDto>(course);
                return Response<CourseDto>.Success(courseDto, 200);
            }
            catch (Exception ex)
            {
                return Response<CourseDto>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<List<CourseDto>>> GetByStudentIdAsync(int studentId)
        {
            try
            {
                var courses = await _courseRepository.GetByStudentIdAsync(studentId);
                var courseDtos = _mapper.Map<List<CourseDto>>(courses);
                return Response<List<CourseDto>>.Success(courseDtos, 200);
            }
            catch (Exception ex)
            {
                return Response<List<CourseDto>>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<List<CourseDto>>> GetByTeacherId(int teacherId)
        {
            try
            {
                var courses = await _courseRepository.GetByTeacherId(teacherId);
                var courseDtos = _mapper.Map<List<CourseDto>>(courses);
                return Response<List<CourseDto>>.Success(courseDtos, 200);
            }
            catch (Exception ex)
            {
                return Response<List<CourseDto>>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<List<CourseDto>>> GetCoursesWithDetail(int? categoryId)
        {
            try
            {
                var courses = await _courseRepository.GetCoursesWithDetail(categoryId);
                var courseDtos = _mapper.Map<List<CourseDto>>(courses);
                return Response<List<CourseDto>>.Success(courseDtos, 200);
            }
            catch (Exception ex)
            {
                return Response<List<CourseDto>>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<List<CourseDto>>> GetStudentCourseToRegister(int id)
        {
            try
            {
                var courses = await _courseRepository.GetStudentCourseToRegister(id);
                var courseDtos = _mapper.Map<List<CourseDto>>(courses);
                return Response<List<CourseDto>>.Success(courseDtos, 200);
            }
            catch (Exception ex)
            {
                return Response<List<CourseDto>>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<List<CourseDto>>> TopCourses()
        {
            try
            {
                var courses = await _courseRepository.TopCourses();
                var courseDtos = _mapper.Map<List<CourseDto>>(courses);
                return Response<List<CourseDto>>.Success(courseDtos, 200);
            }
            catch (Exception ex)
            {
                return Response<List<CourseDto>>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }

        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            try
            {
                var existingCourse = await _courseRepository.GetByIdAsync(courseUpdateDto.Id);
                if (existingCourse == null)
                {
                    return Response<NoContent>.Fail($"Course with ID {courseUpdateDto.Id} not found", 404);
                }

                // Diğer güncelleme işlemlerini burada yapın...
                var mappedDto = _mapper.Map<Course>(courseUpdateDto);
                _courseRepository.Update(mappedDto);
                return Response<NoContent>.Success(null, 200);
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail($"An error occurred: {ex.Message}", 500);
            }
        }
    }
}