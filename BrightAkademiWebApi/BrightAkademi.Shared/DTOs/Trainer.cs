namespace BrightAkademi.Shared.DTOs
{
    public class TrainerDto
    {
        public int TotalStudents { get; set; } 
        public int TotalCourses { get; set; } 
        public int TotalCategories { get; set; } 
        public List<StudentDto> MyStudents { get; set; }
        public List<CourseDto> MyCourses { get; set; }
        public int TotalLevels { get; set; }
    }      
}
