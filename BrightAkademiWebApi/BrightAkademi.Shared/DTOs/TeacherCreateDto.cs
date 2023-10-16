namespace BrightAkademi.Shared.DTOs
{
    public class TeacherCreateDto
    {
        public int Id { get; set; }
        public string Profession { get; set; }
        public string Experience { get; set; }
        public string EducationInfo { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public List<CourseDto>? CourseDtos { get; set; }
        public UserDto User { get; set; }
    }
}
