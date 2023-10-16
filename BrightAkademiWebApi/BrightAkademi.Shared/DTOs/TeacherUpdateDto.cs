namespace BrightAkademi.Shared.DTOs
{
    public class TeacherUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string Experience { get; set; }
        public string EducationInfo { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public List<CourseDto>? CourseDtos { get; set; }
    }
}
