using BrightWeb.Entity.Concrete;

namespace BrightAkademi.Entity.Concrete
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public Teacher Teacher { get; set; }
        public Course Course { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
