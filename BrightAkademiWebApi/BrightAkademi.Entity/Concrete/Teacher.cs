using BrightWeb.Entity.Concrete;

namespace BrightAkademi.Entity.Concrete
{
    public class Teacher
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Profession { get; set; }
        public string? Experience { get; set; }
        public string? EducationInfo { get; set; }
        public string? Comment { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public User User { get; set; }
        public List<Course>? Courses { get; set; }
        public List<UserRole>? UserRoles { get; set; }

    }
}