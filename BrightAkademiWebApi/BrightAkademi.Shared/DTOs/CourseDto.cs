namespace BrightAkademi.Shared.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TotalCourseHours { get; set; }
        public string? HowManyMonths { get; set; }
        public DateTime? StartCourseTime { get; set; }
        public DateTime? FinishCourseTime { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? Experience { get; set; }
        public string? Address { get; set; }
        public string? Content { get; set; }
        public string? Comment { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; } 
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public int? CompanyId { get; set; }
        public CompanyDto Company { get; set; }

        public int? CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        public int? LevelId { get; set; }
        public LevelDto Level { get; set; }

        public int? TeacherId { get; set; }
        public TeacherDto Teacher { get; set; }

        public List<CourseStudentDto>? CourseStudentDto { get; set; }
    }
}
