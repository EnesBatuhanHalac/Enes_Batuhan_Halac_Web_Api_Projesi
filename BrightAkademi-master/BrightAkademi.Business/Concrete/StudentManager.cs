using AutoMapper;
using BrightAkademi.Business.Abstract;
using BrightAkademi.Data.Abstract;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightAkademi.Shared.ResponseDTOs;

namespace BrightAkademi.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        private readonly IMapper _mapper;

        public StudentManager(IStudentRepository studentRepository, IMapper mapper, IUserRoleRepository userRoleRepository, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
        }

        public async Task<Response<StudentDto>> CreateAsync(StudentCreateDto dto)
        {
            var student = _mapper.Map<Student>(dto);

            await _userRepository.CreateAsync(student.User);
            await _studentRepository.CreateAsync(student);
            var perm = new UserRole { UserId = student.UserId, RoleId = 4 };
            await _userRoleRepository.CreateAsync(perm);

            return Response<StudentDto>.Success(_mapper.Map<StudentDto>(student), 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var deletedStudent = await _studentRepository.GetByIdAsync(id);
            if (deletedStudent == null)
            {
                return Response<NoContent>.Fail("Böyle bir öğrenci yok", 401);
            }
            _studentRepository.Delete(deletedStudent);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<StudentDto>>> GetAllAsync()
        {
            var studentList = await _studentRepository.GetAllAsync();
            if (studentList == null)
            {
                return Response<List<StudentDto>>.Fail("Hiç öğrenci bulunamadı", 301);
            }
            var studentDtoList = _mapper.Map<List<StudentDto>>(studentList);
            return Response<List<StudentDto>>.Success(studentDtoList, 200);
        }

        public async Task<Response<List<StudentDto>>> GetByCourseIdAsync(int courseId)
        {
            var students = await _studentRepository.GetByCourseIdAsync(courseId);
            if (students == null)
            {
                return Response<List<StudentDto>>.Fail("Böyle bir öğrenci yok!", 301);
            }
            var studentDto = _mapper.Map<List<StudentDto>>(students);
            return Response<List<StudentDto>>.Success(studentDto, 200);
        }

        public async Task<Response<StudentDto>> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return Response<StudentDto>.Fail("Böyle bir öğrenci yok!", 301);
            }
            var studentDto = _mapper.Map<StudentDto>(student);
            return Response<StudentDto>.Success(studentDto, 200);
        }

        public async Task<Response<List<StudentDto>>> GetByTeacherId(int id)
        {
            var student = await _studentRepository.GetByTeacherId(id);
            if (student == null)
            {
                return Response<List<StudentDto>>.Fail("Böyle bir öğrenci yok!", 301);
            }
            var studentDto = _mapper.Map<List<StudentDto>>(student);
            return Response<List<StudentDto>>.Success(studentDto, 200);
        }

        public async Task<Response<StudentDto>> GetByUserIdAsync(int id)
        {
            var student = await _studentRepository.GetByUserIdAsync(id);
            if (student == null)
            {
                return Response<StudentDto>.Fail("Böyle bir öğrenci yok!", 301);
            }
            var studentDto = _mapper.Map<StudentDto>(student);
            return Response<StudentDto>.Success(studentDto, 200);
        }

        public Task<int> StudentCount()
        {
            return _studentRepository.StudentCount();
        }

        public async Task<Response<NoContent>> UpdateAsync(StudentUpdateDto studentUpdateDto)
        {
            var isThere = await _studentRepository.AnyAsync(studentUpdateDto.Id);
            if (isThere)
            {
                var student = _mapper.Map<Student>(studentUpdateDto);
                student.ModifiedDate = DateTime.Now;
                _studentRepository.Update(student);
                return Response<NoContent>.Success(200);
                //return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Böyle bir öğrenci bulunamadı", 401);
        }


    }
}