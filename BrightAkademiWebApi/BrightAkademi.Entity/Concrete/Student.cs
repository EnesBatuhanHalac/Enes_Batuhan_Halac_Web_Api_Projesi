namespace BrightAkademi.Entity.Concrete
{
    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string? EducationalStatus { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public User User { get; set; }
        public List<CourseStudent>? CourseStudents { get; set; }
    }
}