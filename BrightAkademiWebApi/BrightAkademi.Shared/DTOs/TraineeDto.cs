namespace BrightAkademi.Shared.DTOs
{
    public class TraineeDto
    {
        public int TotalCourses { get; set; } 
        public int TotalCategories { get; set; } 
        public int TotalLevels { get; set; } 
        public int TotalTeachers { get; set; }
        public List<CourseDto> MyCourses { get; set; }

    }
}
