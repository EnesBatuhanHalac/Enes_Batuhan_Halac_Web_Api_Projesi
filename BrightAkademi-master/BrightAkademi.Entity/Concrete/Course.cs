using BrightAkademi.Entity.Concrete;

namespace BrightWeb.Entity.Concrete
{
    public class Course
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
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? LevelId { get; set; }
        public Level Level { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<CourseStudent>? CourseStudents { get; set; }
        public List<TeacherCourse>? TeacherCourses { get; set; }

    }
}
