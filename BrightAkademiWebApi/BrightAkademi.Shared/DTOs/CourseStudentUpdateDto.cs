namespace BrightAkademi.Shared.DTOs
{
    public class CourseStudentUpdateDto
    {
        public int? CourseId { get; set; }
        public CourseDto CourseDto { get; set; }

        public int? StudentId { get; set; }
        public StudentDto StudentDto { get; set; }
    }
}
