using BrightWeb.Entity.Concrete;

namespace BrightAkademi.Entity.Concrete
{
    public class CourseStudent
    {
        public int? CourseId { get; set; }
        public Course Course { get; set; }

        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}