using AutoMapper;
using BrightAkademi.Entity.Concrete;
using BrightAkademi.Shared.DTOs;
using BrightWeb.Entity.Concrete;

namespace BrightAkademi.Business.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();

            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, CompanyCreateDto>().ReverseMap();
            CreateMap<Company, CompanyUpdateDto>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();

            CreateMap<CourseStudent, CourseStudentDto>().ReverseMap();
            CreateMap<CourseStudent, CourseStudentCreateDto>().ReverseMap();
            CreateMap<CourseStudent, CourseStudentUpdateDto>().ReverseMap();

            CreateMap<Level, LevelDto>().ReverseMap();
            CreateMap<Level, LevelCreateDto>().ReverseMap();
            CreateMap<Level, LevelUpdateDto>().ReverseMap();

            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Teacher, TeacherCreateDto>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDto>().ReverseMap();

            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<UserRole, UserRoleDto>().ReverseMap();

            CreateMap<CourseStudent, CourseStudentDto>().ReverseMap();
            }
    }
}
