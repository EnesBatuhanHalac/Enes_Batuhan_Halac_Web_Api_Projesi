namespace BrightAkademi.Shared.DTOs
{
    public class AdminDto
    {
        public int TotalStudents { get; set; } 
        public int TotalCourses { get; set; } 
        public int TotalTeachers { get; set; } 
        public int TotalCategories { get; set; }
        public List<CourseDto> TopCourses { get; set; }
    }      
}
